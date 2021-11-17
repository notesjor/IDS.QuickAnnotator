using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;

namespace IDS.QuickAnnotator.Tool4.ConvertToJournal
{
  class Program
  {
    static void Main(string[] args)
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      var corpus = CorpusAdapterWriteDirect.Create(args[0]);
      var output = args[0] + ".journal";

      var layerNames = corpus.Layers.Select(x=>x.Displayname).Where(x => x.Contains("(") || x == "Wort").OrderBy(x => x).ToArray();

      Console.WriteLine("Layers found:");
      foreach (var name in layerNames)
        Console.WriteLine(name);
      
      using (var fs = new FileStream(output, FileMode.Create, FileAccess.Write))
      using (var buffer = new BufferedStream(fs, 4096))
      using (var writer = new StreamWriter(buffer, Encoding.UTF8))
      {
        writer.WriteLine($"SIGLE\tSentence ID\tToken ID\t{string.Join("\t", layerNames)}");
        foreach (var dsel in corpus.DocumentGuids)
        {
          var mdoc = corpus.GetReadableMultilayerDocument(dsel).ToDictionary(x=>x.Key, x=>x.Value.Select(y=>y.ToArray()).ToArray());
          var sigle = corpus.GetDocumentMetadata(dsel, "Sigle", "");
          var first = mdoc.First().Value;

          for (var s = 0; s < first.Length; s++)
          {
            for (var w = 0; w < first[s].Length; w++)
            {
              var values = new List<string> { sigle, s.ToString(), w.ToString() };
              values.AddRange(layerNames.Select(name => mdoc.ContainsKey(name) ? FixEmptyValue(mdoc[name][s][w]) : "?NA?"));
              writer.WriteLine(string.Join("\t", values));
            }
          }
        }
      }
    }

    private static string FixEmptyValue(string val)
    {
      return string.IsNullOrWhiteSpace(val) ? "-?-" : val;
    }
  }
}
