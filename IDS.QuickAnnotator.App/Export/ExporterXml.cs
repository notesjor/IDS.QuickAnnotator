using System.Collections.Generic;
using System.IO;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Helper;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterXml : AbstractSimpleExporter
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
      var doc = model.EditorDocument;
      var tags = new[] { "a", "b", "c" };
      var idx = 0;

      foreach (var annotator in annotators)
      {
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
              doc[i] = $"<span user=\"{tags[idx]}\" value=\"{val}\">{doc[i]}";
          }
        }

        idx++;
      }

      File.WriteAllText(Path.Combine(path, $"{model.SelectDocument}.xml"), $"<xml>{string.Join(" ", doc)}</xml>");
    }

    protected override void PostProcessing()
    {
    }
  }
}