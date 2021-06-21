using System.IO;
using System.Text;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterPlaintext : AbstractExporter
  {
    public override void Export(IAnnotationModel model, string path) 
      => File.WriteAllText(path, string.Join(" ", model.EditorDocument), Encoding.UTF8);
  }
}
