using System;

namespace IDS.QuickAnnotator.API.Model.Request.Abstract
{
  public abstract class AbstractAuthRequest : AbstractRequest
  {
    public Guid AuthToken { get; set; }
  }
}