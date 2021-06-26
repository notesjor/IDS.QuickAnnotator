using System;
using System.Collections.Generic;
using System.Linq;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export.Abstract
{
  public abstract class AbstractSimpleSnippetExporter : AbstractExporter
  {
    public override void Export(IAnnotationModel model, string path)
    {
      PreProcessing(path);
      foreach (var documentId in model.AvailableDocumentIds)
      {
        model.SelectDocument = documentId;
        ConvertModel(model, out var ald, out var a, out var d);
        Processing(model, ald, a, d);
      }
      PostProcessing();
    }

    private void ConvertModel(IAnnotationModel model, out Dictionary<string, Dictionary<string, List<SnippetExportSequence>>> annotatorLayerDocuments, out string[] annotators, out string[] layers)
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

      var document = model.EditorDocument;
      annotators = annotatorsTmp.OrderBy(x => x).ToArray();
      layers = layersTmp.OrderBy(x => x).ToArray();

      // init
      annotatorLayerDocuments = new Dictionary<string, Dictionary<string, List<SnippetExportSequence>>>();
      foreach (var a in annotators)
      {
        annotatorLayerDocuments.Add(a, new Dictionary<string, List<SnippetExportSequence>>());
        foreach (var l in layers)
          annotatorLayerDocuments[a].Add(l, new List<SnippetExportSequence>());
      }

      // Befüllen
      foreach (var d in model.GetDocumentHistory(false).OrderBy(x => x.Timestamp))
      {
        foreach (var a in d.Annotation)
        {
          var snippet = new SnippetExportSequence(ref document, d, a.Value.ToString());

          var compare = annotatorLayerDocuments[d.UserName][a.Key];
          var matchIndices = new List<int>();
          for (var i = 0; i < compare.Count; i++)
          {
            if (compare[i].IsChange(snippet))
              matchIndices.Add(i);
          }

          foreach (var i in matchIndices.OrderByDescending(x => x))
            annotatorLayerDocuments[d.UserName][a.Key].RemoveAt(i);
          annotatorLayerDocuments[d.UserName][a.Key].Add(snippet);
        }
      }
    }

    protected abstract void PreProcessing(string path);

    protected abstract void Processing(IAnnotationModel model, Dictionary<string, Dictionary<string, List<SnippetExportSequence>>> annotatorLayerSnippets, string[] annotators, string[] layers);

    protected abstract void PostProcessing();
  }
}
