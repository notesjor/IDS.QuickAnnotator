using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterCalculateSnippetsResults : AbstractSimpleSnippetExporter
  {
    private FileStream _fs;
    private StreamWriter _writer;

    protected override void PreProcessing(string path)
    {
      _fs = new FileStream(path, FileMode.Create, FileAccess.Write);
      _writer = new StreamWriter(_fs, Encoding.UTF8);
      _writer.WriteLine("documentId\tannotator\tlayer\tvalue\tsnippet\tcount");
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, List<SnippetExportSequence>> annotatorLayerSnippets, string[] annotators, string[] layers)
    {
      var dId = model.SelectDocument;

      foreach (var a in annotatorLayerSnippets)
      {
        // LAYER > VALUE > SNIPPET > FREQUENCY
        var count = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();

        // FILL
        foreach (var s in a.Value)
        {
          foreach (var x in s.Annotation)
          {
            if (!count.ContainsKey(x.Key))
              count.Add(x.Key, new Dictionary<string, Dictionary<string, int>>());

            var key = x.Value.ToString();
            if (key.StartsWith("?"))
              key = key.Substring(1);
            if (!count[x.Key].ContainsKey(key))
              count[x.Key].Add(key, new Dictionary<string, int>());

            if (count[x.Key][key].ContainsKey(s.Snippet))
              count[x.Key][key][s.Snippet]++;
            else
              count[x.Key][key].Add(s.Snippet, 1);
          }
        }

        // STORE
        foreach (var l in count)
          foreach (var v in l.Value)
            foreach (var s in v.Value)
              _writer.WriteLine($"{dId}\t{a.Key}\t{l.Key}\t{v.Key}\t{s.Key.Replace("\t", " ")}\t{s.Value}");
      }
    }

    protected override void PostProcessing()
    {
      _writer.Close();
      _fs?.Close();
    }
  }
}
