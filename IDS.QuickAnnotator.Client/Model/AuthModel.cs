using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.QuickAnnotator.Client.Model
{
  public class AuthModel
  {
    private string _authPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IDS/QuickAnnotator/credentials.json");
    private string _authToken = "";

    public AuthModel()
    {
      var dir = Path.GetDirectoryName(_authPath);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      if (File.Exists(_authPath))
        _authToken = File.ReadAllText(_authPath);
    }

    public bool Signin()
    {
      return QuickAnnotatorApi.Signin(_authToken);
    }

    public bool Signin(string authToken, bool saveCredentials)
    {
      if (QuickAnnotatorApi.Signin(authToken))
      {
        if (saveCredentials)
          File.WriteAllText(_authPath, authToken);

        return true;
      }
      return false;
    }
  }
}
