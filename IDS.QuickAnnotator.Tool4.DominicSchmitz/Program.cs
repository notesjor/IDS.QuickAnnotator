using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Model.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.QuickAnnotator.Tool4.DominicSchmitz
{
  internal class Program
  {
    static void Main(string[] args)
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      if (Directory.Exists("output"))
        Directory.Delete("output", true);

      Directory.CreateDirectory("output");
      Directory.CreateDirectory("output/docs");

      var corpus = CorpusAdapterWriteDirect.Create(args[0]);

      if (args[0].Contains("_18"))
        Version18(corpus);
      else if (args[0].Contains("_19"))
        Version19(corpus);
      else
        Console.WriteLine("Unknown version");
    }

    private static void Version18(AbstractCorpusAdapter corpus)
    {
      var layer_wort = corpus.GetLayers("Wort").Single();

      var layer_lk = GetLayers(corpus, "Linguistische Klasse");

      // generische Maskulina
      var layer_gm = GetLayers(corpus, "Generisches Maskulinum");

      // spezifische Maskulina
      var layer_wg = GetLayers(corpus, "Welches Geschlecht ist aus Kontext erkennbar?");
      var layer_gs = GetLayers(corpus, "Geschlechtsabstrahierendes Substantiv");
      var layer_sg = GetLayers(corpus, "Lexem mit Genus-Sexus-Kongruenz?");

      // spezifische Feminina
      var layer_bm = GetLayers(corpus, "Bereits gegendert/moviert?");

      using (var fs = new FileStream("output/data.tsv", FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.WriteLine("GUID\tSatzId\tWort\tGenerisches Maskulinum\tSpezifisches Maskulinum\tSpezifisches Femininum");

        foreach (var dsel in corpus.DocumentGuids)
        {
          var outputFile = dsel.ToString("N") + ".txt";
          var doc = layer_wort.GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();
          var positions = FindMatchingPositons(layer_lk, dsel);

          var match = false;
          Print(writer, 0, Filter(positions, layer_gm, dsel, "true"), doc, outputFile, ref match);

          var subSelection = Filter(positions, layer_wg, dsel, "male");
          subSelection = FilterNot(subSelection, layer_gs, dsel, "true");
          subSelection = FilterNot(subSelection, layer_sg, dsel, "true");
          Print(writer, 1, subSelection, doc, outputFile, ref match);

          Print(writer, 2, Filter(positions, layer_bm, dsel, "true"), doc, outputFile, ref match);

          if (match)
            File.WriteAllText($"output/docs/{outputFile}", string.Join("\r\n", doc.Select(x => string.Join(" ", x))));
        }
      }
    }

    private static void Version19(AbstractCorpusAdapter corpus)
    {
      var layer_wort = corpus.GetLayers("Wort").Single();

      var layer_lk = GetLayers(corpus, "Linguistische Klasse");

      // generische Maskulina
      var layer_gm = GetLayers(corpus, "Generisches Maskulinum");

      // spezifische Maskulina
      var layer_wg = GetLayers(corpus, "Welches Geschlecht ist aus Kontext erkennbar?");

      // spezifische Feminina
      var layer_bm = GetLayers(corpus, "Bereits gegendert/moviert?");

      using (var fs = new FileStream("output/data.tsv", FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.WriteLine("GUID\tSatzId\tWort\tGenerisches Maskulinum\tSpezifisches Maskulinum\tSpezifisches Femininum");

        foreach (var dsel in corpus.DocumentGuids)
        {
          var outputFile = dsel.ToString("N") + ".txt";
          var doc = layer_wort.GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();
          var positions = FindMatchingPositons(layer_lk, dsel);

          var match = false;
          Print(writer, 0, Filter(positions, layer_gm, dsel, "true"), doc, outputFile, ref match);

          Print(writer, 1, Filter(positions, layer_wg, dsel, "male"), doc, outputFile, ref match);

          Print(writer, 2, Filter(positions, layer_bm, dsel, "true"), doc, outputFile, ref match);

          if (match)
            File.WriteAllText($"output/docs/{outputFile}", string.Join("\r\n", doc.Select(x => string.Join(" ", x))));
        }
      }
    }

    private static void Print(StreamWriter writer, int prependColumns, Dictionary<int, List<int>> positions, string[][] doc, string outputFile, ref bool match)
    {
      if (positions.Count == 0)
        return;

      foreach (var s in positions)
        foreach (var w in s.Value)
        {
          var data = new List<string>();

          data.Add(outputFile);
          data.Add(s.Key.ToString());
          data.Add(doc[s.Key][w]);
          for(var i = 0; i < prependColumns; i++)
            data.Add("0");
          data.Add("1");
          for (var i = prependColumns; i < 2; i++)
            data.Add("0");

          writer.WriteLine(string.Join("\t", data));
        }

      match = true;
    }

    private static Dictionary<int, List<int>> Filter(Dictionary<int, List<int>> positions, AbstractLayerAdapter[] layers, Guid dsel, string value)
    {
      var d1 = layers[0].GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();
      var d2 = layers[1].GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();

      var res = new Dictionary<int, List<int>>();
      foreach (var s in positions.Keys)
      {
        var ws = positions[s];
        foreach (var w in ws)
          if (d1[s][w] == value && d2[s][w] == value)
          {
            if (!res.ContainsKey(s))
              res.Add(s, new List<int>());
            res[s].Add(w);
          }
      }
      return res;
    }

    private static Dictionary<int, List<int>> FilterNot(Dictionary<int, List<int>> positions, AbstractLayerAdapter[] layers, Guid dsel, string value)
    {
      var d1 = layers[0].GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();
      var d2 = layers[1].GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();

      var res = new Dictionary<int, List<int>>();
      foreach (var s in positions.Keys)
      {
        var ws = positions[s];
        foreach (var w in ws)
          if (d1[s][w] == d2[s][w] && d2[s][w] != value)
          {
            if (!res.ContainsKey(s))
              res.Add(s, new List<int>());
            res[s].Add(w);
          }
      }
      return res;
    }

    private static Dictionary<int, List<int>> FindMatchingPositons(AbstractLayerAdapter[] layer_lk, Guid dsel)
    {
      var d1 = layer_lk[0].GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();
      var d2 = layer_lk[1].GetReadableDocumentByGuid(dsel)?.Select(x => x.ToArray()).ToArray();

      if (d1 == null || d2 == null)
        return new Dictionary<int, List<int>>();

      var res = new Dictionary<int, List<int>>();
      for (var s = 0; s < d1.Length; s++)
        for (var w = 0; w < d1[s].Length; w++)
          try
          {
            if (d1[s][w] == "1" && d2[s][w] == "1")
            {
              if (!res.ContainsKey(s))
                res.Add(s, new List<int>());
              res[s].Add(w);
            }
          }
          catch
          {
            return new Dictionary<int, List<int>>();
          }

      return res;
    }

    static AbstractLayerAdapter[] GetLayers(AbstractCorpusAdapter corpus, string layerName)
      => corpus.Layers.Where(x => x.Displayname != layerName && x.Displayname.StartsWith(layerName)).ToArray();
  }
}
