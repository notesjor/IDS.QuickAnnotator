using System.Collections.Generic;
using System.Linq;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using IDS.QuickAnnotator.Client.Model.User;

namespace IDS.QuickAnnotator.Client.Model.Annotation
{
  public class AnnotationModelOnline : IAnnotationModel
  {
    private readonly UserModel _user;
    private string _documentId;

    public AnnotationModelOnline(UserModel user)
    {
      _user = user;
    }

    public string[] EditorDocument { get; set; }
    public bool[] EditorAnnotations { get; set; }

    public string SelectDocument
    {
      get => _documentId;
      set
      {
        _documentId = value;
        EditorDocument = QuickAnnotatorApi.GetDocument(value);

        RefreshDocumentHistory();
      }
    }

    public IEnumerable<string> AvailableDocumentIds => QuickAnnotatorApi.GetDocuments();

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
          if(i >= 0 && i < values.Length)
            values[i] = anno;
      }

      for (var i = 0; i < values.Length; i++)
        history[i] = !string.IsNullOrWhiteSpace(values[i]);

      EditorAnnotations = history;
    }
    
    public DocumentChange GetLastAnnotationState(int index)
    {
      return QuickAnnotatorApi.GetDocumentHistory(SelectDocument)?.Where(x => x.UserName == _user.Profile.UserName && x.From <= index && x.To > index).OrderByDescending(x => x.Timestamp).FirstOrDefault();
    }

    public DocumentChange[] GetDocumentHistory(bool onlyMyAnnotations)
    {
      return onlyMyAnnotations ? QuickAnnotatorApi.GetDocumentHistory(SelectDocument)?.Where(x => x.UserName == _user.Profile.UserName).ToArray() : QuickAnnotatorApi.GetDocumentHistory(SelectDocument);
    }

    public void Annotate(DocumentChange change)
    {
      change.DocumentId = _documentId;
      QuickAnnotatorApi.SetDocument(_documentId, change);
      RefreshDocumentHistory();
    }
  }
}
