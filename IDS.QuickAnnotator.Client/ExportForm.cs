using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Model;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Client
{
  public partial class ExportForm : AbstractForm
  {
    private readonly string _documentId;
    private readonly AnnotationModel _anno;

    public ExportForm(string documentId, AnnotationModel anno)
    {
      _documentId = documentId;
      _anno = anno;
      InitializeComponent();
    }

    private void btn_export_text_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog {Filter = "TXT-Datei (*.txt)|*.txt"};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      File.WriteAllText(sfd.FileName, string.Join(" ", _anno.EditorDocument));
    }

    private void btn_export_anno_my_Click(object sender, EventArgs e) => ExportXml(true);

    private void btn_export_anno_all_Click(object sender, EventArgs e) => ExportXml(false);

    private void ExportXml(bool onlyMyAnnotations)
    {
      var sfd = new SaveFileDialog {Filter = "XML-Datei (*.xml)|*.xml"};
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      File.WriteAllText(sfd.FileName, BuildXml(_anno.GetDocumentHistory(onlyMyAnnotations)));
    }

    private string BuildXml(DocumentChange[] changes)
    {
      var xml = new XmlDocument();
      xml.LoadXml("<document></document>");
      var root = xml.DocumentElement;
      
      var annotations = xml.CreateElement("annotations");
      root.AppendChild(annotations);
      foreach (var c in changes.OrderBy(x=>x.Timestamp))
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
      for (var i = 0; i < _anno.EditorDocument.Length; i++)
      {
        var token = xml.CreateElement("token");
        token.InnerText = _anno.EditorDocument[i];
        token.SetAttribute("id", $"t_{i}");
        text.AppendChild(token);
      }

      return xml.OuterXml;
    }

    private void btn_export_history_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = "JSON-Datei (*.json)|*.json" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(_anno.GetDocumentHistory(false)));
    }

    private void btn_export_diff_Click(object sender, EventArgs e)
    {
      ExportAnnotatorDiff(new[] {_documentId});
    }

    private void btn_export_all_diff_Click(object sender, EventArgs e)
    {
      ExportAnnotatorDiff(QuickAnnotatorApi.GetDocuments());
    }

    private void ExportAnnotatorDiff(string[] documentIds)
    {
      var sfd = new SaveFileDialog { Filter = "TSV-Datei (*.tsv)|*.tsv" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;


    }
  }
}
