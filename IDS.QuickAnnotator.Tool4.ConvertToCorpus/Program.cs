using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Extern.Json.SimpleStandoff;
using CorpusExplorer.Sdk.Extern.Json.SimpleStandoff.Model;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using IDS.QuickAnnotator.API.Model.Request;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Tool4.ConvertToCorpus
{
  class Program
  {
    static void Main(string[] args)
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      var docs = Directory.GetFiles(Path.Combine(args[0], "docs"), "*.json");
      foreach (var doc in docs)
      {
        var output = Path.Combine(args[0], Path.GetFileName(doc));
        JsonConversion(args, doc, output);
      }

      SaveCorpus(args);
    }

    private static void SaveCorpus(string[] args)
    {
      var importer = new SimpleJsonStandoffImporter();
      var corpus = CorpusMerger.Merge(importer.Execute(Directory.GetFiles(args[0], "*.json", SearchOption.TopDirectoryOnly)));
      corpus.Save(Path.Combine(args[0], "corpus.cec6"), false);
    }

    private static void JsonConversion(string[] args, string doc, string output)
    {
      var textToken = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(doc, Encoding.UTF8));
      var history = Directory.GetFiles(Path.Combine(args[0], "history", Path.GetFileNameWithoutExtension(doc)), "*.json");
      var qAnnos = history.Select(x => JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(x, Encoding.UTF8)));

      var cAnnos = (from a in qAnnos
                    from x in a.Annotation
                    select new Annotation
                    {
                      From = a.From,
                      Layer = $"{x.Key} ({a.UserName})",
                      LayerValue = x.Value.ToString(),
                      To = a.To
                    }).ToArray();
      var nDoc = new Document
      {
        Annotations = cAnnos,
        TextToken = textToken
      };

      File.WriteAllText(output, JsonConvert.SerializeObject(nDoc));
    }
  }
}
