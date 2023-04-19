using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.ViewModel;
using System.Text;

namespace IDS.QuickAnnotator.CorpusPreSampler
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var queries = new HashSet<string>(File.ReadLines("query.txt", Encoding.UTF8).Where(x => !string.IsNullOrWhiteSpace(x)));
      var limits = LoadLimits();

      CorpusExplorerEcosystem.InitializeMinimal();
      if (File.Exists("report.log"))
        File.Delete("report.log");

      var myLock = new object();

      Parallel.ForEach(Directory.GetFiles(args[0], "*.cec6"), new ParallelOptions { MaxDegreeOfParallelism = 10 }, file =>
      {
        var limit = GetLimit(limits, file);

        var log = new List<string> { file };
        var corpus = CorpusAdapterWriteDirect.Create(file);
        var select = corpus.ToSelection();
        log.Add($"ORIGINAL\t{select.CountDocuments}");

        var vmSHA = new DocumentCloneDetectionViewModel
        {
          Selection = select,
          UseSpeedDetection = true
        };
        vmSHA.Execute();

        select = select.CreateTemporary(vmSHA.IndividualDocuments);
        log.Add($"NO CLONES\t{select.CountDocuments}");

        var toShort = new List<Guid>();
        var toLong = new List<Guid>();
        var valid = new List<Guid>();

        var layer = select.GetLayers("Wort").First();
        foreach (var dsel in select.DocumentGuids)
        {
          var doc = layer[dsel];
          var len = doc.Sum(x => x.Length);
          if (len <= limit.Min)
          {
            toShort.Add(dsel);
            continue;
          }
          if (len >= limit.Max)
          {
            toLong.Add(dsel);
            continue;
          }          

          valid.Add(dsel);
        }

        select = select.CreateTemporary(valid);

        log.Add($"SHORT DOCS\t{toShort.Count}");
        log.Add($"LONG DOCS\t{toLong.Count}");
        log.Add($"VALID DOCS\t{select.CountDocuments}");

        lock (myLock)
          File.AppendAllLines("report.log", log);

        select.ToCorpus().Save(file.Replace(".cec6", ".out.cec6"), false);
      });
    }

    private struct Limit
    {
      public int Min { get; set; }
      public int Max { get; set; }
    }

    private static Limit GetLimit(Dictionary<string, Limit> limits, string file)
    {
      var name = Path.GetFileNameWithoutExtension(file);
      foreach (var item in limits)
      {
        if (name.StartsWith(item.Key))
          return item.Value;
      }

      throw new IndexOutOfRangeException();
    }

    private static Dictionary<string, Limit> LoadLimits()
    {
      var res = new Dictionary<string, Limit>();

      var lines = File.ReadAllLines("corpusLimit.txt", Encoding.UTF8);
      foreach (var line in lines)
      {
        if (string.IsNullOrEmpty(line))
          continue;

        var split = line.Split('\t');
        res.Add(split[0], new Limit { Min = int.Parse(split[1]), Max = int.Parse(split[2]) });
      }

      return res;
    }
  }
}