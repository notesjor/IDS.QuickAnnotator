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
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using Telerik.WinControls.UI;
using static Telerik.WinControls.UI.DateInput;

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
    private Selection _select = null;
    private List<Guid> _guids;
    private Guid _current;
    private HashSet<string> _highlight;

    private Dictionary<string, EasyQafCount> _easyQaf = new Dictionary<string, EasyQafCount>();
    private Dictionary<string, string[]> _easyQafState = new Dictionary<string, string[]>();
    private string[] _tokens;

    private class EasyQafCount
    {
      public int ToDoDocuments { get; set; }
      public int ToDoTokens { get; set; }
    }

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
        var docCnt = int.Parse(split.Last());
        split.RemoveAt(split.Count - 1);
        var tokenCnt = int.Parse(split.Last());
        split.RemoveAt(split.Count - 1);

        _easyQaf.Add(split.First(), new EasyQafCount { ToDoDocuments = docCnt, ToDoTokens = tokenCnt });
        _easyQafState.Add(split.First(), split.ToArray());
        highlight.AddRange(split.Select(x => x.Trim()));
      }

      _highlight = new HashSet<string>(highlight);
      _editor.Highlight = _highlight;

      cmb_group.Items.Clear();
      cmb_group.Items.AddRange(_easyQaf.Keys);
      cmb_group.SelectedIndex = 0;
      btn_loadCorpus.Enabled = true;
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      MoveDocument("reject");
      NextDocument();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      MoveDocument("ok");

      _easyQaf[cmb_group.SelectedItem.Text].ToDoDocuments--;
      foreach (var key in _easyQafState.Keys)
      {
        var test = new HashSet<string>(_easyQafState[key]);
        if (_tokens.Any(t => test.Contains(t)))
          _easyQaf[key].ToDoTokens--;
      }

      NextDocument();
    }

    private void RefreshCounter()
    {
      cnt_texts.Text = _easyQaf[cmb_group.SelectedItem.Text].ToDoDocuments.ToString();
      cnt_tokens.Text = _easyQaf[cmb_group.SelectedItem.Text].ToDoTokens.ToString();
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

      _tokens = _select.GetReadableDocument(_current, "Wort").ReduceDocumentToStreamDocument().ToArray();
      _editor.Tokens = _tokens;
      RefreshCounter();
    }

    private void btn_loadCorpus_Click(object sender, EventArgs e)
    {
      Hide();
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
      RenewGuidList();
      Show();
    }

    private void RenewGuidList()
    {
      if (_select == null)
        return;

      var queries = _easyQafState[cmb_group.SelectedItem.Text];
      var subSelect = _select.CreateTemporary(new FilterQuerySingleLayerAnyMatch
      {
        LayerDisplayname = "Wort",
        LayerQueries = queries
      });
      _guids = subSelect.DocumentGuids.ToList();
      NextDocument();
    }

    private void cmb_group_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      RenewGuidList();
    }
  }
}
