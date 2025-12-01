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
  public class ExporterCalculateMergedAgreedBothResults : AbstractSimpleExporter
  {
    private static List<string> _res = new List<string>();
    private string _path;

    protected override void PreProcessing(string path)
    {
      _res.Add("documentID\tT\tlayer\tvalue\tcount");
      _path = path;
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, Dictionary<string, string[]>> annotatorLayerDocuments, string[] annotators, string[] layers,
                                       string path)
    {
      var docId = model.SelectDocument;
      var length = model.EditorDocument.Length;

      var dict = new Dictionary<string, Dictionary<string, int>>();
      var first = annotators.First();

      for (var i = 0; i < length; i++)
        foreach (var layer in layers)
        {
          if (!dict.ContainsKey(layer))
            dict.Add(layer, new Dictionary<string, int>());

          if (!annotators.All(annotator => annotators.All(annotator2 =>
                                                            annotatorLayerDocuments[annotator][layer][i] ==
                                                            annotatorLayerDocuments[annotator2][layer][i])))
            continue;

          var val = annotatorLayerDocuments[first][layer][i];
          if (dict[layer].ContainsKey(val))
            dict[layer][val] += 1;
          else
            dict[layer].Add(val, 1);
        }

      foreach (var x in dict)
        foreach (var y in x.Value)
          _res.Add(string.Join("\t", docId, length, x.Key, y.Key, y.Value));
    }

    protected override void PostProcessing()
    {
      File.WriteAllLines(_path, _res, Encoding.UTF8);
    }
  }
}
