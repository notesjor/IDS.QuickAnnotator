using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using System.Collections;
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
      var results = GetResult(select, queue.Dequeue(), value);

      while (queue.Count > 0)
      {
        var tmp = GetResult(select, queue.Dequeue(), value);

        foreach (var dsel in tmp)
        {
          if (results.ContainsKey(dsel.Key))
          {
            foreach (var s in dsel.Value)
            {
              if (results[dsel.Key].ContainsKey(s.Key))
              {
                foreach (var r in s.Value)
                {
                  if (results[dsel.Key][s.Key].ContainsKey(r.Key))
                    results[dsel.Key][s.Key][r.Key] += r.Value;
                  else
                    results[dsel.Key][s.Key].Add(r.Key, r.Value);
                }
              }
              else
                results[dsel.Key].Add(s.Key, s.Value);
            }
          }
          else
            results.Add(dsel.Key, dsel.Value);
        }
      }

      using (var fs = new FileStream("output.tsv", FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.WriteLine("ID\tSigle\tSatzID\tPrefix\tMatch\tSuffix\tAnnotiert?");

        foreach (var dsel in results)
          foreach (var s in dsel.Value)
          {
            var sigle = select.GetDocumentMetadata(dsel.Key, "Sigle", "");

            var addPre = GetAdditionalSent(select, dsel.Key, s.Key - 1);
            var sent = select.GetReadableDocumentSnippet(dsel.Key, "Wort", s.Key, s.Key).ReduceDocumentToStreamDocument().ToArray();
            var addPost = GetAdditionalSent(select, dsel.Key, s.Key + 1);

            foreach (var r in s.Value)
            {
              var prefix = sent.Take(r.Key.From).ToArray();
              var match = sent.Skip(r.Key.From).Take(r.Key.To - r.Key.From).ToArray();
              var suffix = sent.Skip(r.Key.To).ToArray();

              writer.WriteLine($"{dsel.Key}\t{sigle}\t{s.Key}\t{addPre} {Stringfy(prefix)}\t{Stringfy(match)}\t{Stringfy(suffix)} {addPost}\t{r.Value}");
            }
          }
      }

      Console.WriteLine();
    }

    private static string GetAdditionalSent(Selection select, Guid dsel, int s)
    {
      try
      {
        return select.GetReadableDocumentSnippet(dsel, "Wort", s, s).ReduceDocumentToText();
      }
      catch
      {
        return "";
      }
    }

    private static Dictionary<Guid, Dictionary<int, Dictionary<CeRange, int>>> GetResult(Selection select, string layerName, string value)
    {
      var tmp = QuickQuery.AndSearchOnWordLevel(select, new[]
      {
        new FilterQuerySingleLayerAnyMatch{
          LayerDisplayname = layerName,
          LayerQueries = new[]{ value },
        }
      });

      var res = new Dictionary<Guid, Dictionary<int, Dictionary<CeRange, int>>>();
      foreach (var csel in tmp)
        foreach (var dsel in csel.Value)
        {
          var t1 = new Dictionary<int, Dictionary<CeRange, int>>();
          foreach (var s in dsel.Value)
          {
            var t2 = new Dictionary<CeRange, int>();
            foreach (var r in s.Value)
              t2.Add(r, 1);
            t1.Add(s.Key, t2);
          }
          res.Add(dsel.Key, t1);
        }

      return res;
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