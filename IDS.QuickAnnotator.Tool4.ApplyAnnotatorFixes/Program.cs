using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IDS.QuickAnnotator.API.Model.Request;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Tool4.ApplyAnnotatorFixes
{
  internal class Program
  {
    static void Main()
    {
      var app = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var pathInput = Path.Combine(app, "input");
      var pathOutput = Path.Combine(app, "output");
      var pathFixes =  Path.Combine(app, "fixes");

      if (Directory.Exists(pathOutput))
        Directory.Delete(pathOutput, true);

      EnsureDirectory(pathInput);
      EnsureDirectory(pathOutput);
      EnsureDirectory(pathFixes);

      var docs = Directory.GetDirectories(pathInput);
      foreach (var dirI in docs)
      {
        var id = dirI.Replace(pathInput, "").Replace("\\", "");
        var dirF = Path.Combine(pathFixes, id);
        var dirO = Path.Combine(pathOutput, id);

        Directory.CreateDirectory(dirO);
        var files = Directory.GetFiles(dirI);

        if (Directory.Exists(dirF))
        {
          Console.Write($"{id}...fixing");
          var fixes = LoadFixes(dirF);

          foreach (var file in files)
          {
            var data = JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8));
            var key = BuildKey(data.From, data.To);

            if (fixes.ContainsKey(key))
              data.Annotation = SetAnnotation(fixes[key], data.Annotation);

            File.WriteAllText(file.Replace(dirI, dirO), JsonConvert.SerializeObject(data), Encoding.UTF8);
          }

          Console.WriteLine("...ok!");
        }
        else
        {
          Console.WriteLine($"{id}...copy...ok!");
          foreach (var file in files)
            File.Copy(file, file.Replace(dirI, dirO));
        }
      }
      Console.WriteLine("!END!");
      Console.ReadLine();
    }

    private static Dictionary<string, Dictionary<string, object>> LoadFixes(string path)
    {
      var res = new Dictionary<string, Dictionary<string, object>>();
      
      var files = Directory.GetFiles(path, "*.json");
      foreach (var file in files)
      {
        var fix = JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8));
        var key = BuildKey(fix.From, fix.To);
        if (res.ContainsKey(key))
          res[key] = SetAnnotation(fix.Annotation, res[key]);
        else
          res[key] = SetAnnotation(fix.Annotation);
      }

      return res;
    }

    private static Dictionary<string, object> SetAnnotation(Dictionary<string, object> newValues, Dictionary<string, object> oldValues = null)
    {
      if (oldValues == null)
        oldValues = new Dictionary<string, object>();

      foreach (var n in newValues)
      {
        if(oldValues.ContainsKey(n.Key))
          oldValues[n.Key] = n.Value;
        else
          oldValues.Add(n.Key, n.Value);
      }

      return oldValues;
    }

    private static string BuildKey(int from, int to)
      => $"{from}=>{to}";

    private static void EnsureDirectory(string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
    }
  }
}
