using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using System.Text;

namespace IDS.QuickAnnotator.QafSampler
{
  internal class Program
  {
    private static Random _random = new Random();

    static void Main(string[] args)
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      var qafFile = args[0];
      var QafData = GetQafData(qafFile);

      var basePath = Path.GetDirectoryName(qafFile);

      var files = Directory.GetFiles(basePath, "*.cec6", SearchOption.TopDirectoryOnly);
      Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 10 }, file =>
      {
        var corpus = CorpusAdapterWriteDirect.Create(file);
        var select = corpus.ToSelection();

        var docs = new List<Guid>();

        foreach (var q in QafData)
        {
          foreach (var x in q.Key)
          {
            try
            {
              var tmp = select.CreateTemporary(new[] {
                new FilterQuerySingleLayerAnyMatch {
                  LayerDisplayname = "Wort",
                  LayerQueries = new[] { x }
                }
              });

              if (tmp == null || tmp.CountDocuments < 1)
                continue;

              docs.AddRange(GetSample(tmp, q.Value * 2));
            }
            catch 
            {
              // ignore
            }
          }
        }

        var output = select.CreateTemporary(docs);
        var outputFile = file.Replace(".cec6", ".qac.cec6");
        output.ToCorpus().Save(outputFile, false);

        File.Move(outputFile, outputFile.Replace(".qac.cec6", ".qac"));
      });
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
        tDocs.RemoveAt(idx);
      }

      return res;
    }

    private static List<KeyValuePair<List<string>, int>> GetQafData(string qafFile)
    {
      var res = new List<KeyValuePair<List<string>, int>>();

      var lines = File.ReadAllLines(qafFile, Encoding.UTF8);
      foreach (var line in lines)
      {
        var split = line.Split('\t').ToList();
        if (split.Count < 2)
          continue;
        var count = int.Parse(split.Last());
        split.RemoveAt(split.Count - 1);
        res.Add(new KeyValuePair<List<string>, int>(split, count));
      }

      return res;
    }
  }
}