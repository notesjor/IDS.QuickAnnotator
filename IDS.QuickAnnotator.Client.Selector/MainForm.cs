using IDS.QuickAnnotator.Client.Controls;
using IDS.QuickAnnotator.Client.Forms.Abstract;
using IDS.QuickAnnotator.Client.Selector.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    private QafModel _model = null;
    private Editor _editor = new Editor();

    public MainForm()
    {
      InitializeComponent();

      #region EDITOR
      _editor.Height = elementHost1.Height;
      _editor.Width = elementHost1.Width;
      _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      elementHost1.Child = _editor;
      #endregion
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
      if(_model != null)
        _model.Save();
      _model = new QafModel();
      _model.Load();
    }

    private void btn_abort_Click(object sender, EventArgs e)
    {
      _model.Reject();
      EditorRefresh();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
      _model.Accept();
      EditorRefresh();
    }

    private void EditorRefresh()
    {
      _editor.Highlight = _model.GetHighlight();
      _editor.Tokens = _model.GetTokens();
    }

    public QafModel GetModel()
    {
      return _model;
    }

    private void btn_undone_Click(object sender, EventArgs e)
    {
      var ask = MessageBox.Show("Diese Aktion bricht das aktuelle Dokument ab und lädt das vorherige Dokument zur Bearbeitung.", "Abbrechen > Neu bewerten?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      if (ask != DialogResult.Yes)
        return;

      _model.Undone();
      EditorRefresh();
    }
  }
}
