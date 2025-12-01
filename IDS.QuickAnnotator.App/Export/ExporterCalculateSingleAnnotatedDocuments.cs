using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterCalculateSingleAnnotatedDocuments : AbstractSimpleSnippetExporter
  {
    private string _path;
    private Dictionary<string, string> _doneBy = new Dictionary<string, string>();

    protected override void PostProcessing()
    {
      File.WriteAllText(Path.Combine(_path, "doneBy.json"), JsonConvert.SerializeObject(_doneBy, Formatting.Indented), Encoding.UTF8);
    }

    protected override void PreProcessing(string path)
    {
      _path = path;
    }

    protected override void Processing(IAnnotationModel model, Dictionary<string, List<SnippetExportSequence>> annotatorSnippets, string[] annotators, string[] layers)
    {
      if (annotators.Length == 1)
        _doneBy.Add(model.SelectDocument, annotators[0]);
    }
  }
}
