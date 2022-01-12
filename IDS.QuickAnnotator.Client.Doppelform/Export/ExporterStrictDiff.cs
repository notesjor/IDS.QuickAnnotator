using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterStrictDiff : AbstractSimpleExporter
  {
    private List<string> _res;
    private string _path;

    protected override void PreProcessing(string path)
    {
      _path = path;
      _res = new List<string>
      {
        "DocumentID\tLength\tAnnotator (A)\tAnnotator (B)\tLayer\tNur (A)\tNur (B)\tMatches\tUnterschiede (A+B alles)\tUnterschiede (A+B nur anno)\tAgreement (A+B in %)"
      };
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, Dictionary<string, string[]>> aDocs, string[] annotators, string[] layers, string path)
    {
      if (layers == null)
        return;

      // Berechnen

      foreach (var l in layers)
      {
        var a = annotators.OrderBy(x => x).ToArray();
        for (var i = 0; i < a.Length; i++)
          for (var j = i + 1; j < a.Length; j++)
          {
            DiffQuick(aDocs[a[i]][l], aDocs[a[j]][l], out var length, out var plusA, out var plusB, out var common, out var diff, out var diffOnly);
            var percentage = (double)common / length * 100.0;
            if (double.IsNaN(percentage))
              percentage = 100.0;

            _res.Add($"{model.SelectDocument}\t{length}\t{a[i]}\t{a[j]}\t{l}\t{plusA}\t{plusB}\t{common}\t{diff}\t{diffOnly}\t{percentage}");
          }
      }
    }

    private void DiffQuick(string[] annoA, string[] annoB, out int length, out int plusA, out int plusB, out int common, out int diff, out int diffOnly)
    {
      length = 0;
      plusA = 0;
      plusB = 0;
      common = 0;
      diff = 0;
      diffOnly = 0;

      for (var i = 0; i < annoA.Length; i++)
      {
        var a = annoA[i];
        var b = annoB[i];

        if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b))
          continue;

        length++;
        if (a == b)
        {
          common++;
          continue;
        }

        if (string.IsNullOrWhiteSpace(a))
          plusB++;
        if (string.IsNullOrWhiteSpace(b))
          plusA++;
        diff++;

        if (!string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b))
          diffOnly++;
      }
    }

    protected override void PostProcessing()
    {
      // Ausgabe
      File.WriteAllLines(_path, _res, Encoding.UTF8);
    }
  }
}