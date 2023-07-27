using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace IDS.QuickAnnotator.Tool4.FindMatchSentences
{
  internal class Program
  {
    static void Main(string[] args)
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      var corpus = CorpusAdapterWriteDirect.Create(args[0]);
      var select = corpus.ToSelection();

      var cleanLayerNames = GetCleanLayerNames(select.LayerDisplaynames);
      var keys = cleanLayerNames.Where(x => x.Value.Count > 1).Select(x => x.Key).ToArray();

      for (int i = 0; i < keys.Length; i++)
      {
        var key = keys[i];
        Console.WriteLine($"{i:D2}: {key}");
      }

      Console.Write("Bitte ID eingeben: ");
      var id = int.Parse(Console.ReadLine());
      Console.Write("Bitte Wert angeben, den beide vergeben müssen (z. B. true/false): ");
      var value = Console.ReadLine();

      var queue = new Queue<string>(cleanLayerNames[keys[id]]);
      var results = QuickQuery.AndSearchOnWordLevel(select, new[]
      {
        new FilterQuerySingleLayerAnyMatch{
          LayerDisplayname = queue.Dequeue(),
          LayerQueries = new[]{ value },
        }
      });

      while (queue.Count > 0)
      {
        var layer = queue.Dequeue();
        var tmp = QuickQuery.AndSearchOnWordLevel(select, new[]
        {
          new FilterQuerySingleLayerAnyMatch
          {
            LayerDisplayname = layer,
            LayerQueries = new[]{ value },
          }
        });

        var csels = results.Keys.ToArray();
        foreach (var csel in csels)
        {
          if (!tmp.ContainsKey(csel))
          {
            results.Remove(csel);
            continue;
          }

          var dsels = results[csel].Keys.ToArray();
          foreach (var dsel in dsels)
          {
            if (!tmp[csel].ContainsKey(dsel))
            {
              results[csel].Remove(dsel);
              continue;
            }

            var ssels = results[csel][dsel].Keys.ToArray();
            foreach (var ssel in ssels)
            {
              if (!tmp[csel][dsel].ContainsKey(ssel))
              {
                results[csel][dsel].Remove(ssel);
                continue;
              }

              var wsels = results[csel][dsel][ssel];
              foreach (var wsel in wsels)
                if (!tmp[csel][dsel][ssel].Contains(wsel))
                  results[csel][dsel][ssel].Remove(wsel);
            }
          }
        }
      }

      using (var fs = new FileStream("output.tsv", FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.WriteLine("ID\tSigle\tSatzID\tPrefix\tMatch\tSuffix");

        foreach (var csel in results)
          foreach (var dsel in csel.Value)
            foreach (var ssel in dsel.Value)
            {
              if (ssel.Value.Count == 0)
                continue;

              var sigle = select.GetDocumentMetadata(dsel.Key, "Sigle", "");
              var sent = select.GetReadableDocumentSnippet(dsel.Key, "Wort", ssel.Key, ssel.Key).ReduceDocumentToStreamDocument().ToArray();

              foreach (var mark in ssel.Value)
              {                
                var prefix = sent.Take(mark).ToArray();
                var match = sent.Skip(mark).Take(1).ToArray();
                var suffix = sent.Skip(mark + 1).ToArray();

                writer.WriteLine($"{dsel.Key}\t{sigle}\t{ssel.Key}\t{Stringfy(prefix)}\t{Stringfy(match)}\t{Stringfy(suffix)}");
              }
            }
      }

      Console.WriteLine();
    }

    private static object Stringfy(string[] data)
    {
      return string.Join(" ", data).Replace("\t", " ").Replace("  ", " ");
    }

    private static Dictionary<string, List<string>> GetCleanLayerNames(IEnumerable<string> layerDisplaynames)
    {
      var res = new Dictionary<string, List<string>>();

      foreach (var layerName in layerDisplaynames)
      {
        var cleanName = layerName;
        var index = layerName.IndexOf(" (", StringComparison.Ordinal);
        if (index > 0)
          cleanName = layerName.Substring(0, index);

        if (!res.ContainsKey(cleanName))
          res[cleanName] = new List<string>();

        res[cleanName].Add(layerName);
      }

      foreach (var key in res.Keys.ToArray())
      {
        if (res[key].Count == 1)
          continue;

        if (res[key].Contains(key))
          res[key].Remove(key);
      }

      return res;
    }
  }
}