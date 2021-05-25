using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Tokenizer;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Processor
{
  class Program
  {
    static void Main(string[] args)
    {
      var tokenizer = new HighSpeedSpaceTokenizer();
      var files = Directory.GetFiles("/home/ruediger/PROJECTS/GENDER/TAGGER/input/", "*.txt");
      foreach (var file in files)
      {
        File.WriteAllLines(file.Replace(".txt",".token"), tokenizer.ExecuteToArray(File.ReadAllText(file, Encoding.UTF8)));
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
  }
}
