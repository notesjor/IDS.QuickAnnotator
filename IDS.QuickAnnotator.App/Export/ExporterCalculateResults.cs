using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterCalculateResults : AbstractSimpleExporter
  {
    private static List<string> _res = new List<string>();
    private string _path;

    protected override void PreProcessing(string path)
    {
      _res.Add("documentID\tT\tannotator\tlayer\tvalue\tcount");
      _path = path;
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, Dictionary<string, string[]>> annotatorLayerDocuments, string[] annotators, string[] layers,
                                       string path)
    {
      var docId = model.SelectDocument;
      var length = model.EditorDocument.Length;
      foreach (var annotator in annotators)
      {
        foreach (var layer in layers)
        {
          var count = new Dictionary<string, int>();
          foreach (var t in annotatorLayerDocuments[annotator][layer])
            if (count.ContainsKey(t))
              count[t]++;
            else
              count.Add(t, 1);

          foreach (var x in count)
            _res.Add(string.Join("\t", docId, length, annotator, layer, x.Key, x.Value));
        }
      }
    }

    protected override void PostProcessing()
    {
      File.WriteAllLines(_path, _res, Encoding.UTF8);
    }
  }
}
