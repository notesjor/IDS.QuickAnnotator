using System.IO;
using System.Text;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterHistory : AbstractExporter
  {
    public bool OnlyMyAnnotations { get; set; } = true;

    public override void Export(IAnnotationModel model, string path)
      => File.WriteAllText(path, JsonConvert.SerializeObject(model.GetDocumentHistory(OnlyMyAnnotations)), Encoding.UTF8);
  }
}