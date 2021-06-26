using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterCalculateCrossSnippetsResults : AbstractSimpleSnippetExporter
  {
    private FileStream _fs;
    private StreamWriter _writer;

    protected override void PreProcessing(string path)
    {
      _fs = new FileStream(path, FileMode.Create, FileAccess.Write);
      _writer = new StreamWriter(_fs, Encoding.UTF8);
      _writer.WriteLine("documentId\tannotator\tlayer1\tvalue1\tlayer2\tvalue2\tsnippet\tcount");
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, List<SnippetExportSequence>> annotatorLayerSnippets, string[] annotators, string[] layers)
    {
      var dId = model.SelectDocument;

      foreach (var a in annotatorLayerSnippets)
      {
        // LAYER1/V > LAYER2/V > SNIPPET > FREQUENCY
        var count = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();

        foreach (var s in a.Value)
        {
          var snip = s.Snippet;
          for (var i = 0; i < layers.Length; i++)
          {
            var l1 = layers[i];
            var v1 = s.Annotation[l1].ToString();
            if (v1.StartsWith("?"))
              v1 = v1.Substring(1);
            var k1 = $"{l1}\t{v1}";
            if(!count.ContainsKey(k1))
              count.Add(k1, new Dictionary<string, Dictionary<string, int>>());

            for (var j = i + 1; j < layers.Length; j++)
            {
              var l2 = layers[j];
              var v2 = s.Annotation[l2].ToString();
              if (v2.StartsWith("?"))
                v2 = v2.Substring(1);
              var k2 = $"{l2}\t{v2}";
              if(!count[k1].ContainsKey(k2))
                count[k1].Add(k2, new Dictionary<string, int>());

              if (count[k1][k2].ContainsKey(snip))
                count[k1][k2][snip]++;
              else
                count[k1][k2].Add(snip, 1);
            }
          }
        }

        // STORE
        foreach (var l1 in count)
          foreach (var l2 in l1.Value)
            foreach (var s in l2.Value)
              _writer.WriteLine($"{dId}\t{a.Key}\t{l1.Key}\t{l2.Key}\t{s.Key.Replace("\t", " ")}\t{s.Value}");
      }
    }

    protected override void PostProcessing()
    {
      _writer.Close();
      _fs?.Close();
    }
  }
}
