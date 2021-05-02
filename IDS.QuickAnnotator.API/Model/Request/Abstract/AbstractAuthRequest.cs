namespace IDS.QuickAnnotator.API.Model.Request.Abstract
{
  public abstract class AbstractAuthRequest : AbstractRequest
  {
    public string AuthToken { get; set; }
  }
}