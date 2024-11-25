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
      var project = CorpusExplorerEcosystem.InitializeMinimal(new CacheStrategyDisableCaching());

      var qafFile = args[0];
      var QafData = GetQafData(qafFile);

      var basePath = Path.GetDirectoryName(qafFile);
      var outputPath = Path.Combine(basePath, "output");
      if (!Directory.Exists(outputPath))
        Directory.CreateDirectory(outputPath);

      var corpora = GetCorpusInfo(basePath);
      foreach (var corpus in corpora)
      {
        Console.WriteLine($"corpus: {corpus.Key}");
        var loadLock = new object();

        Parallel.ForEach(corpus.Value, year =>
        {
          var file = Path.Combine(basePath, $"{corpus.Key}{year}.cec6");
          Console.WriteLine($"load: {file}");
          var cec6 = CorpusAdapterWriteDirect.Create(file);
          lock (loadLock)
            project.Add(cec6);
          Console.WriteLine($"load: {file} - ok!");
        });

        var all = project.SelectAll;

        foreach (var qaf in QafData)
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
            var outputFile = Path.Combine(outputPath, $"{corpus.Key}-{qaf.Item1.First()}.cec6");
            output.ToCorpus().Save(outputFile, false);
          }
          catch
          {
            // ignore
          }
        }

        project.Clear();
      }
    }

    private static Selection Remove(Selection tmp, List<Guid> remove)
    {
      var res = new HashSet<Guid>(tmp.DocumentGuids);
      foreach (var x in remove)
        res.Remove(x);
      return tmp.CreateTemporary(res);
    }

    private static Dictionary<string, List<string>> GetCorpusInfo(string basePath)
    {
      var files = Directory.GetFiles(basePath, "*.cec6", SearchOption.TopDirectoryOnly);

      var res = new Dictionary<string, List<string>>();
      foreach (var file in files)
      {
        var name = Path.GetFileNameWithoutExtension(file);
        var year = name.Substring(name.Length - 2);
        var sigle = name.Substring(0, name.Length - 2);

        if (!res.ContainsKey(sigle))
          res.Add(sigle, new List<string>());

        res[sigle].Add(year);
      }
      return res;
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