using System.Collections.Generic;
using IDS.QuickAnnotator.API.Model.Request;

namespace IDS.QuickAnnotator.Client.Model.Annotation.Interface
{
  public interface IAnnotationModel
  {
    string[] EditorDocument { get; set; }
    string SelectDocument { get; set; }
    IEnumerable<string> AvailableDocumentIds { get; }
    DocumentChange[] GetDocumentHistory(bool onlyMyAnnotations);
  }
}
