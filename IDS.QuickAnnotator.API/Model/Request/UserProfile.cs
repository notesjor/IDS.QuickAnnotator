using System.Collections.Generic;

namespace IDS.QuickAnnotator.API.Model.Request
{
  public class UserProfile
  {
    public string Name { get; set; }
    public string LastDocumentId { get; set; }
    public List<string> DoneDocumentIds { get; set; } = new List<string>();
    public bool IsAdmin { get; set; }
  }
}
