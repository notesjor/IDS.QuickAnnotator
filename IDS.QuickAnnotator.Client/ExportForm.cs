using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    private void btn_export_anno_my_Click(object sender, EventArgs e)
    {
      BuildXml(null);
    }

    private void btn_export_anno_all_Click(object sender, EventArgs e)
    {

    }

    private string BuildXml(DocumentChange[] changes)
    {
      var xml = new XmlDocument();
      
      var root = xml.CreateElement("document");
      var annotations = xml.CreateElement("annotations");
      root.AppendChild(annotations);

      var res = xml.OuterXml;
      return res;
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

    }
  }
}
