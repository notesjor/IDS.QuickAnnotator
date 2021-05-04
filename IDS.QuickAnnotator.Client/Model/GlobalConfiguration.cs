using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.QuickAnnotator.Client.Model
{
  public static class GlobalConfiguration
  {
    public static string BaseUrl => "http://localhost:4545";
    public static string AuthToken { get; set; }
  }
}
