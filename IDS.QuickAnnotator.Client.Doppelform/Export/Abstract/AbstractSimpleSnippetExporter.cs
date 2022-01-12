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

        if (ald == null || ald.Count == 0)
          continue;
        if (a == null || a.Length == 0)
          continue;

        Processing(model, ald, a, d);
      }
      PostProcessing();
    }

    private void ConvertModel(IAnnotationModel model, out Dictionary<string, List<SnippetExportSequence>> annotatorSnippets, out string[] annotators, out string[] layers)
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
        annotatorSnippets = null;
        annotators = null;
        layers = null;
        return;
      }

      var document = model.EditorDocument;
      annotators = annotatorsTmp.OrderBy(x => x).ToArray();
      layers = layersTmp.OrderBy(x => x).ToArray();

      // init
      annotatorSnippets = annotators.ToDictionary(a => a, a => new List<SnippetExportSequence>());

      // Befüllen
      foreach (var d in model.GetDocumentHistory(false).OrderBy(x => x.Timestamp))
      {
        var snippet = new SnippetExportSequence(ref document, d);

        var compare = annotatorSnippets[d.UserName];
        var matchIndices = new List<int>();
        for (var i = 0; i < compare.Count; i++)
        {
          if (compare[i].IsChange(snippet))
            matchIndices.Add(i);
        }

        foreach (var i in matchIndices.OrderByDescending(x => x))
          annotatorSnippets[d.UserName].RemoveAt(i);
        annotatorSnippets[d.UserName].Add(snippet);
      }
    }

    protected abstract void PreProcessing(string path);

    protected abstract void Processing(IAnnotationModel model, Dictionary<string, List<SnippetExportSequence>> annotatorSnippets, string[] annotators, string[] layers);

    protected abstract void PostProcessing();
  }
}
