using IDS.QuickAnnotator.API.Model.Request;
using Newtonsoft.Json;
using System.Text;

namespace IDS.QuickAnnotator.Tool4.OnlyAnnotatedBy
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var dir = Path.Combine(args[0], "history");
      var res = new Dictionary<string, HashSet<string>>();

      var subDirs = Directory.GetDirectories(dir);
      foreach (var subDir in subDirs)
      {
        var name = Path.GetFileName(subDir);
        res.Add(name, new HashSet<string>());

        var files = Directory.GetFiles(subDir, "*.json");
        foreach (var file in files)
          res[name].Add(JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8))?.UserName);
      }

      var stb = new StringBuilder();
      foreach (var (key, value) in res)
        stb.AppendLine($"{key}\t{string.Join(", ", value.OrderBy(x => x))}");
      File.WriteAllText(Path.Combine(args[0], "annotatedBy.txt"), stb.ToString(), Encoding.UTF8);
    }
  }
}