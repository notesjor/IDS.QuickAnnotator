using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Extension;
using IDS.QuickAnnotator.Client.Controls;
using IDS.QuickAnnotator.Client.Forms.Abstract;
using IDS.QuickAnnotator.Client.Selector.Properties;
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
using System.Windows.Forms.Integration;
using Telerik.WinControls.UI;

namespace IDS.QuickAnnotator.Client.Selector
{
  public partial class MainForm : AbstractForm
  {
    //private QafModel _model = null;
    private Editor _editor = new Editor();
    private CorpusAdapterWriteDirect _corpus;
    private string _basePath;
    private string _pathOk;
    private string _pathReject;
    private Selection _select;
    private List<Guid> _guids;
    private Guid _current;
    private HashSet<string> _highlight;

    public MainForm()
    {
      CorpusExplorerEcosystem.InitializeMinimal();

      InitializeComponent();

      #region EDITOR
      _editor.Height = elementHost1.Height;
      _editor.Width = elementHost1.Width;
      _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      elementHost1.Child = _editor;
      #endregion

      Show();
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog();
      ofd.Filter = "QAF-Datei (*.qaf)|*.qaf";
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      // QAF-Datei laden
      var lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
      var highlight = new List<string>();

      foreach (var item in lines)
      {
        var split = item.Split('\t').ToList();
        if (split.Count < 4)
          continue;

        split.RemoveAt(split.Count - 1);
        split.RemoveAt(split.Count - 1);
        split.RemoveAt(split.Count - 1);

        highlight.AddRange(split.Select(x => x.Trim()));
      }

      _editor.Highlight = new HashSet<string>(highlight);

      /*
      if(_model != null)
        _model.Save();

      MessageBox.Show("Das Sampling wird durchgeführt. Bis zum Abschluss der Berechnung wird das Fenster ausgeblendet. Bitte schließen Sie diesen Dialog mit OK und warten Sie weitere Schritte ab.", "Sampling startet", MessageBoxButtons.OK, MessageBoxIcon.Information);
      Hide();

      _model = new QafModel();
      _model.Load();

      cmb_group.Items.Clear();
      cmb_group.Items.AddRange(_model.Groups);

      Show();
      */
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      MoveDocument("reject");
      NextDocument();
      /*
      _model.Reject();
      EditorRefresh();
      */
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      MoveDocument("ok");
      NextDocument();
      /*
      _model.Accept();
      EditorRefresh();
      */
    }

    private void MoveDocument(string choice)
    {
      var target = Path.Combine(_basePath, choice, _current.ToString() + ".cec6");
      var tmp = _select.CreateTemporary(new[] { _current });
      tmp.ToCorpus().Save(target, false);
    }

    private void NextDocument()
    {
      if (_guids.Count == 0)
      {
        MessageBox.Show("Alle Dokumente wurden bearbeitet.", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      _current = _guids.First();
      _guids.RemoveAt(0);

      _editor.Tokens = _select.GetReadableDocument(_current, "Wort").ReduceDocumentToStreamDocument().ToArray();
    }

    /*
    private void EditorRefresh()
    {


      _editor.Highlight = _model.GetHighlight();
      _editor.Tokens = _model.GetTokens();

      cnt_texts.Text = _model.TodosTexts.ToString();
      cnt_tokens.Text = _model.TodosTokens.ToString();

      info_texts.Text = _model.DoneTexts.ToString();
      info_tokens.Text = _model.DoneTokens.ToString();
    }
    */

    /*
    public QafModel GetModel()
    {
      return _model;
    }
    */

    private void btn_undone_Click(object sender, EventArgs e)
    {
      /*
      var ask = MessageBox.Show("Diese Aktion bricht das aktuelle Dokument ab und lädt das vorherige Dokument zur Bearbeitung.", "Abbrechen > Neu bewerten?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      if (ask != DialogResult.Yes)
        return;

      _model.Undone();
      EditorRefresh();
      */
    }

    private void cnt_texts_KeyUp(object sender, KeyEventArgs e)
    {
      /*
      if (e.KeyCode == Keys.Enter)
        if (int.TryParse(cnt_texts.Text, out var cnt))
          _model.TodosTexts = cnt;
      */
    }

    private void cnt_tokens_KeyUp(object sender, KeyEventArgs e)
    {
      /*
      if (e.KeyCode == Keys.Enter)
        if (int.TryParse(cnt_texts.Text, out var cnt))
          _model.TodosTokens = cnt;
      */
    }

    private void btn_loadCorpus_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog();
      ofd.Filter = "CEC6-Corpus (*.cec6)|*.cec6";
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _corpus = CorpusAdapterWriteDirect.Create(ofd.FileName);

      _basePath = Path.Combine(Path.GetDirectoryName(ofd.FileName), Path.GetFileNameWithoutExtension(ofd.FileName));
      _pathOk = Path.Combine(_basePath, "ok");
      _pathReject = Path.Combine(_basePath, "reject");

      if (!Directory.Exists(_pathOk))
        Directory.CreateDirectory(_pathOk);

      if (!Directory.Exists(_pathReject))
        Directory.CreateDirectory(_pathReject);

      _select = _corpus.ToSelection();
      _guids = _select.DocumentGuids.ToList();
      NextDocument();
    }
  }
}
