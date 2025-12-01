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
  public class ExporterCalculateCrossResults : AbstractSimpleExporter
  {
    private static List<string> _res = new List<string>();
    private string _path;

    protected override void PreProcessing(string path)
    {
      _res.Add("documentID\tT\tannotator\tlayer1\tvalue1\tlayer2\tvalue2\tcount");
      _path = path;
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, Dictionary<string, string[]>> annotatorLayerDocuments, string[] annotators, string[] layers,
                                       string path)
    {
      var docId = model.SelectDocument;
      var length = model.EditorDocument.Length;
      foreach (var annotator in annotators)
      {
        var count = new Dictionary<string, Dictionary<string, int>>();
        foreach (var layer1 in layers)
        {                    
          foreach(var layer2 in layers)
          {
            if(layer1 == layer2)
              continue;

            for (int i = 0; i < length; i++)
            {
              var k1 = $"{layer1}\t{annotatorLayerDocuments[annotator][layer1][i]}";
              var k2 = $"{layer2}\t{annotatorLayerDocuments[annotator][layer2][i]}";

              if (count.ContainsKey(k1))
              {
                if(count[k1].ContainsKey(k2))
                  count[k1][k2]++;
                else
                  count[k1].Add(k2, 1);
              }
              else 
                count.Add(k1, new Dictionary<string, int> { { k2, 1} });
            }
          }      
        }
        foreach (var x in count)
          foreach (var y in x.Value)
            _res.Add(string.Join("\t", docId, length, annotator, x.Key, y.Key, y.Value));
      }
    }

    protected override void PostProcessing()
    {
      File.WriteAllLines(_path, _res, Encoding.UTF8);
    }
  }
}
