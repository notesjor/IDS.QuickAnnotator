using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Export;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation;
using Newtonsoft.Json;

namespace IDS.QuickAnnotator.Client
{
  public partial class ExportForm : AbstractForm
  {
    private readonly string _documentId;
    private readonly AnnotationModelOnline _anno;

    public ExportForm(string documentId, AnnotationModelOnline anno)
    {
      _documentId = documentId;
      _anno = anno;
      InitializeComponent();
    }

    private void btn_export_text_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = "TXT-Datei (*.txt)|*.txt" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = new ExporterPlaintext();
      exporter.Export(_anno, sfd.FileName);
    }

    private void btn_export_anno_all_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = "XML-Datei (*.xml)|*.xml" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = new ExporterXml();
      exporter.Export(_anno, sfd.FileName);
    }

    private void btn_export_history_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = "JSON-Datei (*.json)|*.json" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = new ExporterHistory { OnlyMyAnnotations = false };
      exporter.Export(_anno, sfd.FileName);
    }

    private void btn_export_all_diff_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = "TSV-Datei (*.tsv)|*.tsv" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = new ExporterDiff();
      exporter.Export(_anno, sfd.FileName);
    }

    private void btn_export_html_Click(object sender, EventArgs e)
    {
      var sfd = new SaveFileDialog { Filter = "HTML-Datei (*.html)|*.html" };
      if (sfd.ShowDialog() != DialogResult.OK)
        return;

      var exporter = new ExporterHtml();
      exporter.Export(_anno, sfd.FileName);
    }
  }
}
