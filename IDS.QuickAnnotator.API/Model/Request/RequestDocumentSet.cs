using System.Collections.Generic;
using IDS.QuickAnnotator.API.Model.Request.Abstract;

namespace IDS.QuickAnnotator.API.Model.Request
{
  public class RequestDocumentSet : AbstractAuthRequest
  {
    public DocumentChange Change { get; set; }
  }
}