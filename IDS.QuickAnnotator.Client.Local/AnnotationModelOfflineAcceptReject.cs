using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.QuickAnnotator.Client.Local
{
  public class AnnotationModelOfflineAcceptReject : IAnnotationModel
  {
    private readonly string _qafFile;
    private readonly string _basePath;

    public AnnotationModelOfflineAcceptReject(string qafFile)
    {
      _qafFile = qafFile;
      _basePath = Path.GetDirectoryName(qafFile);
    }

    public string[] EditorDocument
    {
      get => JsonConvert.DeserializeObject<string[]>(File.ReadAllText(Directory.GetFiles(Path.Combine(_basePath, "docs"), $"{SelectDocument}.json", SearchOption.AllDirectories).First(), Encoding.UTF8));
      set { }
    }

    public bool[] EditorAnnotations
    {
      get
      {
        var res = new bool[EditorDocument.Length];
        res.Initialize();

        foreach (var change in GetDocumentHistory(true))
        {
          var val = change.Annotation.Count == 0 ? false : true;
          for (var i = change.From; i < change.To; i++)
            res[i] = val;
        }

        return res;
      }
    }

    public string SelectDocument { get; set; }

    public void StateAccept()
    {

    }

    public void StateReject()
    {

    }

    private void NextDocument()
    {
      var index = Array.IndexOf(AvailableDocumentIds.ToArray(), SelectDocument);
      if (index < AvailableDocumentIds.Count() - 1)
        SelectDocument = AvailableDocumentIds.ToArray()[index + 1];
    }

    public IEnumerable<string> AvailableDocumentIds => Directory.GetFiles(Path.Combine(_basePath, "docs"), "*.json", SearchOption.AllDirectories)
                                                                .Select(Path.GetFileNameWithoutExtension);

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

    public void Annotate(DocumentChange change)
    {
      var fn = (DateTime.Now).ToString("yyyy-MM-dd_hh-mm-ss") + ".json";
      File.WriteAllText(Path.Combine(_basePath, "history", SelectDocument, fn), JsonConvert.SerializeObject(change), Encoding.UTF8);
    }
  }
}
