using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using System.Collections.Generic;
using System.IO;
using IDS.QuickAnnotator.Client.Helper;
using IDS.QuickAnnotator.Client.Properties;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterHtml : AbstractSimpleExporter
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
      var tags = new []{"a", "b", "c"};
      var idx = 0;
      var names = new List<string>();

      foreach (var annotator in annotators)
      {
        var adoc = ReduceHelper.Reduce(annotatorLayerDocuments[annotator]);
        string last = null;
        names.Add($"<li><div class=\"{tags[idx]}\"><strong>{tags[idx]}</strong>: {annotator}</div></li>");

        for (var i = 0; i < adoc.Length; i++)
        {
          var val = adoc[i];
          if (string.IsNullOrWhiteSpace(val))
            val = null;

          if (val != last)
          {
            if (last != null)
              doc[i - 1] += "</div></div>";
            last = val;
            if (last != null)
              doc[i] = $"<div class=\"{tags[idx]}\"><div class=\"lbl\">{val}</div><div class=\"txt\">{doc[i]}";
          }
        }

        idx++;
      }

      var name = $"<ul>{string.Join("", names)}</ul>";
      File.WriteAllText(Path.Combine(path, $"{model.SelectDocument}.html"), Resources.ExporterHtmlTemplate.Replace("<!--NAME-->", name).Replace("<!--BODY-->", string.Join(" ", doc)));
    }

    protected override void PostProcessing()
    {
    }
  }
}
