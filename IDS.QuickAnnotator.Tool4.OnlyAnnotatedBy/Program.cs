using IDS.QuickAnnotator.API.Model.Request;
using Newtonsoft.Json;
using System.Text;

namespace IDS.QuickAnnotator.Tool4.OnlyAnnotatedBy
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var dir = args[0];

      var result = new Dictionary<string, List<string>>();

      var subDirs = Directory.GetDirectories(dir);
      foreach (var subDir in subDirs)
      {
        var names = new HashSet<string>();
        var files = Directory.GetFiles(subDir, "*.json");
        foreach (var file in files)
        {
          names.Add(JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8)).UserName);
          if (names.Count > 1)
            break;
        }

        if (names.Count > 1)
          continue;

        var name = names.First();
        if (!result.ContainsKey(name))
          result[name] = new List<string>();
        result[name].Add(subDir.Replace(dir, ""));
      }

      using (var fs = new FileStream("output.tsv", FileMode.Create, FileAccess.Write))
      using (var sw = new StreamWriter(fs, Encoding.UTF8))
        foreach (var user in result)
          foreach (var entry in user.Value)
            sw.WriteLine($"{user.Key}\t{entry}");
    }
  }
}