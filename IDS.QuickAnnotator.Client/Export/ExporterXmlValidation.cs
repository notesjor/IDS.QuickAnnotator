using System.Collections.Generic;
using System.IO;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Helper;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterXmlValidation : AbstractSimpleExporter
  {
    protected override void PreProcessing(string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
    }

    protected override void Processing(IAnnotationModel model,
                                       Dictionary<string, Dictionary<string, string[]>> annotatorLayerDocuments,
                                       string[] annotators, string[] layers,
                                       string path)
    {
      foreach (var annotator in annotators)
      {
        var doc = model.EditorDocument;
        var adoc = ReduceHelper.Reduce(annotatorLayerDocuments[annotator]);
        string last = null;

        for (var i = 0; i < adoc.Length; i++)
        {
          var val = adoc[i];
          if (string.IsNullOrWhiteSpace(val))
            val = null;

          if (val != last)
          {
            if (last != null)
              doc[i - 1] += "</span>";
            last = val;
            if (last != null)
              doc[i] = $"<span value=\"{val}\">{doc[i]}";
          }
        }

        File.WriteAllText(Path.Combine(path, $"{model.SelectDocument}_{annotator}.xml"), $"<xml>{string.Join("\r\n", doc)}</xml>");
      }
    }

    protected override void PostProcessing()
    {
    }
  }
}