using System;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IDS.QuickAnnotator.Client.Helper;
using IDS.QuickAnnotator.Client.Doppelform.Properties;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterHtmlDiff : AbstractSimpleExporter
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
      var names = new List<string>();

      if (annotators.Length < 2)
        return;

      for (var aId = 0; aId < annotators.Length; aId++)
      {
        var adoc = ReduceHelper.Reduce(annotatorLayerDocuments[annotators[aId]]);
        string last = null;
        names.Add($"<li><div class=\"{tags[idx]}\"><strong>{tags[idx]}</strong>: {annotators[aId]}</div></li>");

        for (var i = 0; i < adoc.Length; i++)
        {
          var val = adoc[i];
          if (string.IsNullOrWhiteSpace(val))
            val = null;

          val = HiglightValues(val, ref annotatorLayerDocuments, ref annotators, aId, i);
          
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

    private string HiglightValues(string val, ref Dictionary<string, Dictionary<string, string[]>> annotatorLayerDocuments, 
                                  ref string[] annotators, int currentA, int i)
    {
      if (string.IsNullOrWhiteSpace(val))
        return val;

      var vals = val.Split(' ');

      for (var aId = 0; aId < annotators.Length; aId++)
      {
        if(currentA == aId)
          continue;

        var compare = new HashSet<string>(ReduceHelper.Reduce(annotatorLayerDocuments[annotators[aId]])[i].Split(' '));
        for (var j = 0; j < vals.Length; j++)
          if (!compare.Contains(vals[j]))
            vals[j] = $"<b>{vals[j]}</b>";
      }

      return string.Join(" ", vals);

    }

    protected override void PostProcessing()
    {
    }
  }
}
