using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDS.QuickAnnotator.API.Model.Request;
using Telerik.WinControls.FileDialogs;

namespace IDS.QuickAnnotator.Client.Model
{
  public class AnnotationModel
  {
    private UserProfile _profile;

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
      EditorDocument = QuickAnnotatorApi.GetDocument(documentId);

      var history = new bool[EditorDocument.Length];
      history.Initialize();

      foreach (var change in QuickAnnotatorApi.GetDocumentHistory(documentId))
      {
        if (change.UserName != Profile.UserName) 
          continue;

        for (var i = change.From; i < change.To; i++)
          history[i] = true;
      }

      EditorAnnotations = history;
    }
  }
}
