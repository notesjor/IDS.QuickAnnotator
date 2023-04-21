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
      get => JsonConvert.DeserializeObject<string[]>(File.ReadAllText(Directory.GetFiles(Path.Combine(_basePath, "docs"), $"{SelectDocument}.json", SearchOption.AllDirectories).First(), Encoding.UTF8));
      set { }
    }
    public string SelectDocument { get; set; }

    public IEnumerable<string> AvailableDocumentIds => Directory.GetFiles(Path.Combine(_basePath, "docs"), "*.json", SearchOption.AllDirectories)
                                                                .Select(Path.GetFileNameWithoutExtension);

    public bool[] EditorAnnotations
    {
      get
      {
        var res = new bool[EditorDocument.Length];
        res.Initialize();

        foreach (var change in GetDocumentHistory(true))
        {
          var val = change.Annotation.Count == 0 ? false : true;
          for(var i = change.From; i < change.To; i++)
            res[i] = val;
        }

        return res;
      }
    }

    public void Annotate(DocumentChange change)
    {
      var fn = (DateTime.Now).ToString("yyyy-MM-dd_hh-mm-ss") + ".json";
      File.WriteAllText(Path.Combine(_basePath, "history", SelectDocument, fn), JsonConvert.SerializeObject(change), Encoding.UTF8);
    }

    public DocumentChange[] GetDocumentHistory(bool onlyMyAnnotations)
    {
      var res = new List<DocumentChange>();
      try
      {
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
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      return res.ToArray();
    }

    public DocumentChange GetLastAnnotationState(int index)
    {
      return GetDocumentHistory(true).Where(x => x.From <= index && x.To > index).OrderByDescending(x => x.Timestamp).FirstOrDefault();
    }
  }
}
