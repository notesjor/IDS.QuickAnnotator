using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Cache;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using System.Text;

namespace IDS.QuickAnnotator.QafSampler
{
  internal class Program
  {
    private static Random _random = new Random();

    static void Main(string[] args)
    {
      if (args.Length != 3)
      {
        Console.WriteLine("Usage: IDS.QuickAnntator.QafSampler <source> <qaf-file> <output>");
        Console.WriteLine("if <source> is a single CEC6-File, use this file as source");
        Console.WriteLine("if <source> is a directory, use all CEC6-File in it as one source");
        return;
      }

      var source = args[0];
      var qafFile = args[1];
      var output = args[2];

      var QafData = GetQafData(qafFile);

      if (!Directory.Exists(output))
        Directory.CreateDirectory(output);

      if (source.ToLower().EndsWith(".cec6"))
        ModeSingleFile(source, QafData, output);
      else
        ModeFolder(source, QafData, output);
    }

    private static void ModeFolder(string source, List<Tuple<List<string>, int, int, int>> qafData, string output)
    {
      var files = Directory.GetFiles(source, "*.cec6", SearchOption.TopDirectoryOnly);
      var project = CorpusExplorerEcosystem.InitializeMinimal(new CacheStrategyDisableCaching());
      var loadLock = new object();
      Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 20 }, path =>
      {
        Console.WriteLine($"load: {path}...");
        var cec6 = CorpusAdapterWriteDirect.Create(path);
        lock (loadLock)
          project.Add(cec6);
        Console.WriteLine($"load: {path}...ok!");
      });
      Console.WriteLine("all files loaded!");
      StartSamplingProcess(project.SelectAll, qafData, Path.Combine(output, new DirectoryInfo(source).Name));
    }

    private static void ModeSingleFile(string path, List<Tuple<List<string>, int, int, int>> qafData, string output)
    {
      Console.Write($"load: {path}...");
      var cec6 = CorpusAdapterWriteDirect.Create(path);
      var project = CorpusExplorerEcosystem.InitializeMinimal(new CacheStrategyDisableCaching());
      project.Add(cec6);
      Console.WriteLine("ok!");

      StartSamplingProcess(project.SelectAll, qafData, Path.Combine(output, Path.GetFileNameWithoutExtension(path)));
    }

    private static void StartSamplingProcess(Selection all, List<Tuple<List<string>, int, int, int>> qafData, string pathTemplate)
    {
      foreach (var qaf in qafData)
      {
        try
        {
          var tmp = all.CreateTemporary(new[]
          {
            new FilterQuerySingleLayerAnyMatch
            {
              LayerDisplayname = "Wort",
              LayerQueries = qaf.Item1
            }
          });
          if (tmp == null || tmp.CountDocuments < 1)
            continue;

          var docs = GetSample(tmp, qaf.Item4); // extra docs
          tmp = Remove(tmp, docs);

          var cntToken = qaf.Item2;
          var cntDoc = qaf.Item3;

          while (cntToken > 0 && cntDoc > 0)
          {
            var guid = GetSample(tmp, 1);
            cntDoc--;

            var dSel = tmp.CreateTemporary(guid);
            var block = dSel.CreateBlock<Frequency1LayerBlock>();
            block.LayerDisplayname = "Wort";
            block.Calculate();
            cntToken -= (int)qaf.Item1.Sum(x => block.Frequency.ContainsKey(x) ? block.Frequency[x] : 0);

            docs.AddRange(guid);

            tmp = Remove(tmp, guid);
          }

          var output = all.CreateTemporary(docs);
          output.ToCorpus().Save($"{pathTemplate}-{qaf.Item1.First()}.cec6", false);
        }
        catch
        {
          // ignore
        }
      }
    }

    private static Selection Remove(Selection tmp, List<Guid> remove)
    {
      var res = new HashSet<Guid>(tmp.DocumentGuids);
      foreach (var x in remove)
        res.Remove(x);
      return tmp.CreateTemporary(res);
    }

    private static List<Guid> GetSample(Selection tmp, int cnt)
    {
      var res = tmp.DocumentGuids.ToList();
      if (res.Count < cnt)
        return res;

      var tDocs = new List<Guid>();
      while (res.Count > 0)
      {
        var idx = _random.Next(0, res.Count);
        tDocs.Add(res[idx]);
        res.RemoveAt(idx);
      }

      while (tDocs.Count > 0)
      {
        var idx = _random.Next(0, tDocs.Count);
        res.Add(tDocs[idx]);
        if (res.Count >= cnt)
          break;
        tDocs.RemoveAt(idx);
      }

      return res;
    }

    private static List<Tuple<List<string>, int, int, int>> GetQafData(string qafFile)
    {
      var res = new List<Tuple<List<string>, int, int, int>>();

      var lines = File.ReadAllLines(qafFile, Encoding.UTF8);
      foreach (var line in lines)
      {
        var split = line.Split('\t').ToList();
        if (split.Count < 4)
          continue;

        var extra = int.Parse(split.Last());
        split.RemoveAt(split.Count - 1);
        var documents = int.Parse(split.Last());
        split.RemoveAt(split.Count - 1);
        var tokens = int.Parse(split.Last());
        split.RemoveAt(split.Count - 1);

        res.Add(new Tuple<List<string>, int, int, int>(split, tokens, documents, extra));
      }

      return res;
    }
  }
}