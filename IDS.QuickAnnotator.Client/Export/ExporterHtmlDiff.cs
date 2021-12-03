using System;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IDS.QuickAnnotator.Client.Helper;
using IDS.QuickAnnotator.Client.Properties;

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
      if (annotators.Length < 2)
        return;

      var doc = model.EditorDocument;
      var tags = new []{"a", "b", "c"};
      var idx = 0;
      var names = new List<string>();
      foreach (var a in annotators)
      {
        names.Add($"<li><div class=\"{tags[idx]}\"><strong>{tags[idx]}</strong>: {a}</div></li>");
        idx++;
      }

      var annos = annotators.Select(x => ReduceHelper.Reduce(annotatorLayerDocuments[x])).ToArray();

      for (var i = 0; i < doc.Length; i++)
      {
        var votes = annos.Select(a => new HashSet<string>(a[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))).ToArray();
        for (var j = 0; j < votes.Length; j++)
        {
          for (var k = 0; k < votes.Length; k++)
          {
            if (j == k)
              continue;

            var test = votes[k].ToArray();

            foreach (var x in test)
              if (votes[j].Remove(x))
                votes[k].Remove(x);
          }
        }

        if (votes.Sum(x => x.Count) == 0)
          continue;

        for (var id = 0; id < votes.Length; id++)
        {
          if (votes[id].Count == 0)
            continue;

          var allValues = annos[id][i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
          for (var j = 0; j < allValues.Length; j++)
            allValues[j] = votes[id].Contains(allValues[j]) ? $"<b>{allValues[j]}</b>" : allValues[j];

          doc[i] = $"<div class=\"{tags[id]}\"><div class=\"lbl\">{string.Join(" ", allValues)}</div><div class=\"txt\">{doc[i]}</div></div>";
        }
      }
      
      var name = $"<ul>{string.Join("", names)}</ul>";
      File.WriteAllText(Path.Combine(path, $"{model.SelectDocument}.html"), Resources.ExporterHtmlTemplate.Replace("<!--NAME-->", name).Replace("<!--BODY-->", string.Join(" ", doc)));
    }

    protected override void PostProcessing()
    {
    }
  }
}
