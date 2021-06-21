using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Client.Model.Annotation
{
  public class AnnotationModelOffline : IAnnotationModel
  {
    private readonly string _basePath;

    public AnnotationModelOffline(string basePath)
    {
      _basePath = basePath;
    }

    public string[] EditorDocument
    {
      get => JsonConvert.DeserializeObject<string[]>(File.ReadAllText(Path.Combine(_basePath, $"docs/{SelectDocument}.json"), Encoding.UTF8));
      set{}
    }
    public string SelectDocument { get; set; }

    public IEnumerable<string> AvailableDocumentIds => Directory.GetFiles(Path.Combine(_basePath, "docs"), "*.json")
                                                                .Select(Path.GetFileNameWithoutExtension);

    public DocumentChange[] GetDocumentHistory(bool onlyMyAnnotations)
    {
      var res = new List<DocumentChange>();
      foreach (var file in Directory.GetFiles(Path.Combine(_basePath, $"history/{SelectDocument}/"), "*.json"))
      {
        try
        {
          res.Add(JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8)));
        }
        catch
        {
          // ignore
        }
      }

      return res.ToArray();
    }
  }
}
