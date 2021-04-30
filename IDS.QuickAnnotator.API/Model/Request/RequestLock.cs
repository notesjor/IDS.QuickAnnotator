using IDS.QuickAnnotator.API.Model.Request.Abstract;

namespace IDS.QuickAnnotator.API.Model.Request
{
  public class RequestLock : AbstractAuthRequest
  {
    public string DocumentId { get; set; }
  }
}
