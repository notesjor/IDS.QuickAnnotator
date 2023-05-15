using System.Diagnostics.Eventing.Reader;
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
      var option = args[1];
      var name = args[2];
      var output = args[3];

      foreach (var file in Directory.GetFiles(input, "*.json", SearchOption.AllDirectories))
      {
        try
        {
          var obj = JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8));
          if (option == "user")
            if (name != obj?.UserName)
              continue;

          if (option == "layer")
            if (obj.Annotation.ContainsKey(name))
              obj.Annotation.Remove(name);

          var nPath = file.Replace(input, output);
          var dir = Path.GetDirectoryName(nPath);
          if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

          File.WriteAllText(nPath, JsonConvert.SerializeObject(obj));
        }
        catch
        {
          // ignore
        }
      }
    }
  }
}
