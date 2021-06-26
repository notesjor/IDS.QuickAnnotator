using System.Collections.Generic;
using System.IO;
using System.Text;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterCalculateSnippetsResults : AbstractSimpleSnippetExporter
  {
    private static Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>> _res =
      new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>>();
    private string _path;

    protected override void PreProcessing(string path)
    {
      _path = path;
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, Dictionary<string, List<SnippetExportSequence>>> annotatorLayerSnippets, string[] annotators, string[] layers)
    {
      var dId = model.SelectDocument;
      _res.Add(dId, new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>());

      foreach (var a in annotatorLayerSnippets)
      {
        if (!_res[dId].ContainsKey(a.Key))
          _res[dId].Add(a.Key, new Dictionary<string, Dictionary<string, Dictionary<string, int>>>());

        foreach (var l in a.Value)
        {
          if (!_res[dId][a.Key].ContainsKey(l.Key))
            _res[dId][a.Key].Add(l.Key, new Dictionary<string, Dictionary<string, int>>());

          foreach (var v in l.Value)
          {
            if (_res[dId][a.Key][l.Key].ContainsKey(v.Value))
            {
              if (_res[dId][a.Key][l.Key][v.Value].ContainsKey(v.Snippet))
                _res[dId][a.Key][l.Key][v.Value][v.Snippet]++;
              else
                _res[dId][a.Key][l.Key][v.Value].Add(v.Snippet, 1);
            }
            else
            {
              _res[dId][a.Key][l.Key].Add(v.Value, new Dictionary<string, int> { { v.Snippet, 1 } });
            }
          }
        }
      }
    }

    protected override void PostProcessing()
    {
      using (var fs = new FileStream(_path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.WriteLine("documentId\tannotator\tlayer\tvalue\tsnippet\tcount");

        foreach (var d in _res)
          foreach (var a in d.Value)
            foreach (var l in a.Value)
              foreach (var s in l.Value)
                foreach (var c in s.Value)
                {
                  writer.WriteLine($"{d.Key}\t{a.Key}\t{l.Key}\t{s.Key}\t{c.Key.Replace("\t", " ")}\t{c.Value}");
                }
      }
    }
  }
}
