using System.Collections.Generic;
using System.Linq;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export.Abstract
{
  public abstract class AbstractSimpleExporter : AbstractExporter
  {
    public override void Export(IAnnotationModel model, string path)
    {
      PreProcessing(path);
      foreach (var documentId in model.AvailableDocumentIds)
      {
        model.SelectDocument = documentId;
        ConvertModel(model, out var ald, out var a, out var d);

        if (ald == null || ald.Count == 0)
          continue;
        if (a == null || a.Length == 0)
          continue;

        Processing(model, ald, a, d, path);
      }
      PostProcessing();
    }

    private void ConvertModel(IAnnotationModel model, out Dictionary<string, Dictionary<string, string[]>> annotatorLayerDocuments, out string[] annotators, out string[] layers)
    {
      // Annotatoren und layer identifizieren
      var annotatorsTmp = new HashSet<string>();
      var layersTmp = new HashSet<string>();
      foreach (var d in model.GetDocumentHistory(false))
      {
        annotatorsTmp.Add(d.UserName);
        foreach (var k in d.Annotation.Keys)
          layersTmp.Add(k);
      }

      if (annotatorsTmp.Count == 0 || layersTmp.Count == 0)
      {
        annotatorLayerDocuments = null;
        annotators = null;
        layers = null;
        return;
      }

      annotators = annotatorsTmp.OrderBy(x => x).ToArray();
      layers = layersTmp.OrderBy(x => x).ToArray();

      // init
      annotatorLayerDocuments = new Dictionary<string, Dictionary<string, string[]>>();
      foreach (var a in annotators)
      {
        annotatorLayerDocuments.Add(a, new Dictionary<string, string[]>());
        foreach (var l in layers)
        {
          var arr = new string[model.EditorDocument.Length];
          for (int i = 0; i < arr.Length; i++)
            arr[i] = "";
          annotatorLayerDocuments[a].Add(l, arr);
        }
      }

      // Befüllen
      foreach (var d in model.GetDocumentHistory(false).OrderBy(x => x.Timestamp))
      foreach (var x in d.Annotation)
        for (var i = d.From; i < d.To; i++)
        {
          var val = x.Value.ToString();
          if (val.StartsWith("?"))
            val = val.Substring(1);
          annotatorLayerDocuments[d.UserName][x.Key][i] = val;
        }
    }

    protected abstract void PreProcessing(string path);

    protected abstract void Processing(IAnnotationModel model, Dictionary<string, Dictionary<string, string[]>> annotatorLayerDocuments, string[] annotators, string[] layers, string path);

    protected abstract void PostProcessing();
  }
}
