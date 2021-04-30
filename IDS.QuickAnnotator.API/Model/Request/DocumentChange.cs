using System.Collections.Generic;

namespace IDS.QuickAnnotator.API.Model.Request
{
  public class DocumentChange
  {
    public string DocumentId { get; set; }
    public string UserName { get; set; }
    public int SentenceId { get; set; }
    public int TokenId { get; set; }
    public Dictionary<string, object> Annotation { get; set; }
  }
}
