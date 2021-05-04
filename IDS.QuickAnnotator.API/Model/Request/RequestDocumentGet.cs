using IDS.QuickAnnotator.API.Model.Request.Abstract;

namespace IDS.QuickAnnotator.API.Model.Request
{
  public class RequestDocumentGet : AbstractAuthRequest
  {
    public string DocumentId { get; set; }
  }
}
