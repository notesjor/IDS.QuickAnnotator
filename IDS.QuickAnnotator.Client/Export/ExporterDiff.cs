using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Utils.Diff;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterDiff : AbstractExporter
  {
    public HashSet<string> DocumentFilter { get; set; } = new HashSet<string>();

    public override void Export(IAnnotationModel model, string path)
    {
      var res = new List<string>();
      res.Add("DocumentID\tLength\tAnnotator (A)\tAnnotator (B)\tLayer\tLöschen (A)\tEinfügen (B)\tEdit-Distanz");

      foreach (var documentId in DocumentFilter)
      {
        model.SelectDocument = documentId;

        // Annotatoren und layer identifizieren
        var annotators = new HashSet<string>();
        var layers = new HashSet<string>();
        foreach (var d in model.GetDocumentHistory(false))
        {
          annotators.Add(d.UserName);
          foreach (var k in d.Annotation.Keys)
            layers.Add(k);
        }

        if (layers.Count == 0 || annotators.Count == 0)
          continue;

        // init
        var aDocs = new Dictionary<string, Dictionary<string, string[]>>();
        foreach (var a in annotators.OrderBy(x => x))
        {
          aDocs.Add(a, new Dictionary<string, string[]>());
          foreach (var l in layers)
          {
            var arr = new string[model.EditorDocument.Length];
            for (int i = 0; i < arr.Length; i++)
              arr[i] = "";
            aDocs[a].Add(l, arr);
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
              aDocs[d.UserName][x.Key][i] = val;
            }

        // Berechnen
        foreach (var l in layers)
        {
          var a = annotators.OrderBy(x => x).ToArray();
          for (var i = 0; i < a.Length; i++)
            for (var j = i + 1; j < a.Length; j++)
            {
              var diff = Diff.DiffQuick(aDocs[a[i]][l], aDocs[a[j]][l]);

              res.Add($"{documentId}\t{model.EditorDocument.Length}\t{a[i]}\t{a[j]}\t{l}\t{diff.Sum(x => x.DeletedA)}\t{diff.Sum(x => x.InsertedB)}\t{diff.Sum(x => x.EditDistance)}");
            }
        }
      }

      // Ausgabe
      File.WriteAllLines(path, res, Encoding.UTF8);
    }
  }
}