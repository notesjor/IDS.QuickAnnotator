using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export.Abstract
{
  public abstract class AbstractExporter
  {
    public abstract void Export(IAnnotationModel model, string path);
  }
}
