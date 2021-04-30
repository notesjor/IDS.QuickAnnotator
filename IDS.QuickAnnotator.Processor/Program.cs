using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tagger.TreeTagger;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Processor
{
  class Program
  {
    static void Main(string[] args)
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      var files = Directory.GetFiles("input", "*.txt");

      var scraper = new TxtScraper();
      scraper.Input.Enqueue(files);
      scraper.Execute();

      var tagger = new SimpleTreeTagger { LanguageSelected = "Deutsch", Input = scraper.Output };
      tagger.Execute();
      var corpus = tagger.Output.First();

      corpus.Save("corpus.cec6", false);
      foreach (var dsel in corpus.DocumentGuids)
      {
        var doc = corpus.GetReadableDocument(dsel, "Wort").Select(x => x.ToArray()).ToArray();
        File.WriteAllText(Path.Combine("output", Path.GetFileNameWithoutExtension(corpus.GetDocumentMetadata(dsel, "Datei", "")) + ".json"), JsonConvert.SerializeObject(doc), Encoding.UTF8);
      }
    }
  }
}
