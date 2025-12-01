using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Helper.Diff;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterDiff : AbstractSimpleExporter
  {
    private List<string> _res;
    private string _path;

    protected override void PreProcessing(string path)
    {
      _path = path;
      _res = new List<string>();
      _res.Add("DocumentID\tLength\tAnnotator (A)\tAnnotator (B)\tLayer\tLöschen (A)\tEinfügen (B)\tEdit-Distanz");
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
          var diff = Diff.DiffQuick(aDocs[a[i]][l], aDocs[a[j]][l]);

          _res.Add($"{model.SelectDocument}\t{model.EditorDocument.Length}\t{a[i]}\t{a[j]}\t{l}\t{diff.Sum(x => x.DeletedA)}\t{diff.Sum(x => x.InsertedB)}\t{diff.Sum(x => x.EditDistance)}");
        }
      }
    }

    protected override void PostProcessing()
    {
      // Ausgabe
      File.WriteAllLines(_path, _res, Encoding.UTF8);
    }
  }
}