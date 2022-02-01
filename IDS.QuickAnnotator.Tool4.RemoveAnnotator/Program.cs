using System.IO;
using System.Text;
using IDS.QuickAnnotator.API.Model.Request;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Tool4.RemoveAnnotator
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = args[0];
      var name = args[1];
      var output = args[2];

      foreach (var file in Directory.GetFiles(input, "*.json", SearchOption.AllDirectories))
      {
        try
        {
          var obj = JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8));
          if(name != obj?.UserName)
            continue;

          var nPath = file.Replace(input, output);
          var dir = Path.GetDirectoryName(nPath);
          if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

          File.Move(file, nPath);
        }
        catch
        {
          // ignore
        }
      }
    }
  }
}
