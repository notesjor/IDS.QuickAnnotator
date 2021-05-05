using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using IDS.QuickAnnotator.API.Model.Request;
using Telerik.WinControls.FileDialogs;

namespace IDS.QuickAnnotator.Client.Model
{
  public class AnnotationModel
  {
    private UserProfile _profile;
    private string _documentId;

    public AnnotationModel()
    {
      LoadProfile();
    }

    public UserProfile Profile => _profile;
    public string[] EditorDocument { get; set; }
    public bool[] EditorAnnotations { get; set; }

    public void LoadProfile()
    {
      _profile = QuickAnnotatorApi.GetProfile();
    }

    public bool IsDocumentDone(string documentId)
    {
      return _profile.DoneDocumentIds.Contains(documentId);
    }

    public void SelectDocument(string documentId)
    {
      _documentId = documentId;
      EditorDocument = QuickAnnotatorApi.GetDocument(documentId);

      RefreshDocumentHistory();
    }

    private void RefreshDocumentHistory()
    {
      if (EditorDocument == null)
        return;

      // RESET
      var history = new bool[EditorDocument.Length];
      history.Initialize();
      EditorAnnotations = history;

      // INIT
      var values = new string[EditorDocument.Length];
      values.Initialize();

      var changes = GetDocumentHistory(true)?.OrderBy(x => x.Timestamp);
      if (changes == null)
        return;

      foreach (var change in changes)
      {
        var tmp = new List<string>();
        foreach (var a in change.Annotation)
        {
          var val = a.Value.ToString();
          if (!string.IsNullOrWhiteSpace(val))
            tmp.Add(val);
        }

        var anno = tmp.Count == 0 ? "" : string.Join(" | ", tmp);
        for (int i = change.From; i < change.To; i++)
          values[i] = anno;
      }

      for (var i = 0; i < values.Length; i++)
        history[i] = !string.IsNullOrWhiteSpace(values[i]);

      EditorAnnotations = history;
    }

    public DocumentChange[] GetDocumentHistory(bool onlyMyAnnotations)
    {
      return onlyMyAnnotations ? QuickAnnotatorApi.GetDocumentHistory(_documentId)?.Where(x => x.UserName == Profile.UserName).ToArray() : QuickAnnotatorApi.GetDocumentHistory(_documentId);
    }

    public void Annotate(DocumentChange change)
    {
      change.DocumentId = _documentId;
      QuickAnnotatorApi.SetDocument(_documentId, change);
      RefreshDocumentHistory();
    }
  }
}
