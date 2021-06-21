using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using IDS.QuickAnnotator.Client.Export.Abstract;
using IDS.QuickAnnotator.Client.Model.Annotation.Interface;

namespace IDS.QuickAnnotator.Client.Export
{
  public class ExporterXml : AbstractExporter
  {
    public bool OnlyMyAnnotations { get; set; } = true;

    public override void Export(IAnnotationModel model, string path) 
      => File.WriteAllText(path, BuildXml(model), Encoding.UTF8);

    private string BuildXml(IAnnotationModel model)
    {
      var changes = model.GetDocumentHistory(OnlyMyAnnotations);

      var xml = new XmlDocument();
      xml.LoadXml("<document></document>");
      var root = xml.DocumentElement;

      var annotations = xml.CreateElement("annotations");
      root.AppendChild(annotations);
      foreach (var c in changes.OrderBy(x => x.Timestamp))
      {
        var change = xml.CreateElement("annotation");
        change.SetAttribute("from", c.From.ToString());
        change.SetAttribute("to", c.To.ToString());
        change.SetAttribute("user", c.UserName);
        annotations.AppendChild(change);

        foreach (var a in c.Annotation)
        {
          var anno = xml.CreateElement("v");
          anno.SetAttribute("key", a.Key);
          anno.InnerText = a.Value.ToString();
          change.AppendChild(anno);
        }
      }

      var text = xml.CreateElement("text");
      root.AppendChild(text);
      for (var i = 0; i < model.EditorDocument.Length; i++)
      {
        var token = xml.CreateElement("token");
        token.InnerText = model.EditorDocument[i];
        token.SetAttribute("id", $"t_{i}");
        text.AppendChild(token);
      }

      return xml.OuterXml;
    }
  }
}