using System.Collections.Generic;
using IDS.QuickAnnotator.API.Model.Request;

namespace IDS.QuickAnnotator.Client.Model.Annotation.Interface
{
  public interface IAnnotationModel
  {
    string[] EditorDocument { get; set; }
    bool[] EditorAnnotations { get; }
    string SelectDocument { get; set; }
    IEnumerable<string> AvailableDocumentIds { get; }
    DocumentChange[] GetDocumentHistory(bool onlyMyAnnotations);
    DocumentChange GetLastAnnotationState(int index);
    void Annotate(DocumentChange change);
  }
}
