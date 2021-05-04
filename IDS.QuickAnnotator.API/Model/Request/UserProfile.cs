using System.Collections.Generic;

namespace IDS.QuickAnnotator.API.Model.Request
{
  public class UserProfile
  {
    public string UserName { get; set; }
    public string LastDocumentId { get; set; }
    public HashSet<string> DoneDocumentIds { get; set; } = new HashSet<string>();
    public bool IsAdmin { get; set; }
  }
}
