using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Processor
{
  class Program
  {
    static void Main(string[] args)
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      if (args.Length == 1)
        PreprocessCec6Files(args[0]);

      var tokenizer = new HighSpeedSpaceTokenizer();
      var files = Directory.GetFiles("/home/ruediger/PROJECTS/GENDER/TAGGER/input/", "*.txt");
      foreach (var file in files)
      {
        File.WriteAllLines(file.Replace(".txt", ".token"), tokenizer.ExecuteToArray(File.ReadAllText(file, Encoding.UTF8)));
      }

      files = Directory.GetFiles("/home/ruediger/PROJECTS/GENDER/TAGGER/input/", "*.token");
      foreach (var file in files)
      {
        var process = new Process
        {
          StartInfo =
          {
            FileName = "/home/ruediger/PROJECTS/GENDER/TAGGER/XDependencies/RFTagger/bin/rft-annotate",
            Arguments = $"/home/ruediger/PROJECTS/GENDER/TAGGER/XDependencies/RFTagger/lib/german.par {file} {file.Replace("input/", "output/").Replace(".token", ".txt")}",
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
          }
        };
        process.Start();
        process.WaitForExit();
      }

      files = Directory.GetFiles("output", "*.txt");
      foreach (var file in files)
      {
        var lines = File.ReadAllLines(file, Encoding.UTF8);
        var token = (from line in lines select line.Split('\t') into split where split.Length == 2 select split[0]).ToArray();
        File.WriteAllText(file.Replace(".txt", ".json"), JsonConvert.SerializeObject(token));
      }
    }

    private static void PreprocessCec6Files(string path)
    {
      var outputPath = "/home/ruediger/PROJECTS/GENDER/TAGGER/input/";
      var delete = Directory.GetFiles(outputPath, "*.txt");
      foreach (var x in delete)
        File.Delete(x);

      var basePath = "/home/ruediger/CEC6/";

      var lines = File.ReadAllLines(path, Encoding.UTF8);
      var files = new Dictionary<string, List<string>>();

      foreach (var line in lines) // Ermittle benötigte CEC6-Dateien
      {
        var split = line.Split("/", StringSplitOptions.RemoveEmptyEntries);
        if (split.Length != 2)
          continue;

        var key = $"{split[0].ToLower()}.cec6.gz";
        if (files.ContainsKey(key))
          files[key].Add(line);
        else
          files.Add(key, new List<string> { line });
      }

      foreach (var file in files) // Extrahiere TXT-Daten aus CEC6
      {
        var corpus = CorpusAdapterWriteDirect.Create(Path.Combine(basePath, file.Key));
        var select = corpus.ToSelection();

        foreach (var doc in file.Value)
        {
          var sub = select.CreateTemporary(new AbstractFilterQuery[]
          {
            new FilterQueryMetaExactMatch
            {
              MetaLabel = "Sigle",
              MetaValues = new object[] {doc}
            }
          });

          var dsel = sub.DocumentGuids.Single();
          var layer = sub.GetLayers("Wort").Single();

          File.WriteAllText(Path.Combine(outputPath, $"{doc.Replace("/", "_")}.txt"), layer.GetReadableDocumentByGuid(dsel).ReduceDocumentToText(), Encoding.UTF8);
        }
      }

      Console.WriteLine($"INPUT FILE: {lines.Length} > TXT FILES: {Directory.GetFiles(outputPath, "*.txt").Length}");
    }
  }
}
