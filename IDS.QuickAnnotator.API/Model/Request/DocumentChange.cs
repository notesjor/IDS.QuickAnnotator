using System;
using System.Collections.Generic;

namespace IDS.QuickAnnotator.API.Model.Request
{
  public class DocumentChange
  {
    public string DocumentId { get; set; }
    public string UserName { get; set; }
    public int SentenceStart { get; set; }
    public int TokenStart { get; set; }
    public int SentenceEnd { get; set; }
    public int TokenEnd { get; set; }
    public Dictionary<string, object> Annotation { get; set; }
    public DateTime Timestamp { get; set; }
  }
}
