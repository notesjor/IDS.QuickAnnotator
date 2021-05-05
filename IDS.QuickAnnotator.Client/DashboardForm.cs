using IDS.QuickAnnotator.Client.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace IDS.QuickAnnotator.Client
{
  public partial class DashboardForm : AbstractForm
  {
    private Editor _editor = new Editor();
    private readonly AnnotationModel _anno;
    private bool _init = true;

    public DashboardForm()
    {
      InitializeComponent();
      cmb_text.CommandBarDropDownListElement.TextBox.Margin = new Padding(0, 6, 0, 0);
      cmb_text.CommandBarDropDownListElement.TextBox.TextBoxItem.ReadOnly = true;
      commandBarStripElement1.OverflowButton.Visibility = ElementVisibility.Collapsed;

      // EDITOR
      _editor.Height = elementHost1.Height;
      _editor.Width = elementHost1.Width;
      _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      _editor.LeftClick += EditorOnLeftClick;
      _editor.RightClick += EditorOnRightClick;

      elementHost1.Child = _editor;

      _anno = new AnnotationModel();

      cmb_text.Items.Clear();
      var text_index = 0;

      var docs = QuickAnnotatorApi.GetDocuments();
      foreach (var d in docs)
      {
        if (d == _anno.Profile.LastDocumentId)
          text_index = cmb_text.Items.Count;

        var item = new RadListDataItem(d);
        if (_anno.Profile.DoneDocumentIds.Contains(d))
        {
          item.Image = Resources.ok_button;
          item.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        cmb_text.Items.Add(item);
      }

      _init = false;
      cmb_text.SelectedIndex = text_index;
    }

    private int _editorIndexTmp = -1;
    private int _editorIndexFrom = -1;
    private int _editorIndexTo = -1;

    private void EditorOnRightClick(int index)
    {
      _editor.TemporaryAnnotation();
      _editorIndexTmp = index;
      _editor.TemporaryAnnotation(index);
    }

    private void EditorOnLeftClick(int index)
    {
      _editorIndexFrom = _editorIndexTmp;
      _editorIndexTmp = -1;

      _editor.TemporaryAnnotation();
      _editorIndexTo = index;
      _editor.TemporaryAnnotation(_editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom, _editorIndexTo);
    }

    private void commands_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (e.KeyChar)
      {
        case 'q':
          radio_pb_del_q.IsChecked = true;
          break;
        case 'w':
          radio_pb_true_w.IsChecked = true;
          break;
        case 'e':
          radio_pb_false_e.IsChecked = true;
          break;
        case 't':
          chk_pb_t.IsChecked = !chk_pb_t.IsChecked;
          break;

        case 'a':
          radio_gen_del_a.IsChecked = true;
          break;
        case 's':
          radio_gen_true_s.IsChecked = true;
          break;
        case 'd':
          radio_gen_false_d.IsChecked = true;
          break;
        case 'g':
          chk_gen_g.IsChecked = !chk_gen_g.IsChecked;
          break;

        case 'y':
          radio_co_del_y.IsChecked = true;
          break;
        case 'x':
          radio_co_true_x.IsChecked = true;
          break;
        case 'c':
          radio_co_false_c.IsChecked = true;
          break;
        case 'b':
          chk_co_b.IsChecked = !chk_co_b.IsChecked;
          break;

        case '\r':
          btn_submit_Click(this, null);
          break;
      }
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      if (QuickAnnotatorApi.SetDocumentCompletion(cmb_text.Items[cmb_text.SelectedIndex].Text))
      {
        _anno.LoadProfile();
        foreach (var item in cmb_text.Items)
        {
          item.Image = _anno.Profile.DoneDocumentIds.Contains(item.Text) ? Resources.ok_button : null;
          item.TextImageRelation = TextImageRelation.ImageBeforeText;
        }
      }
    }

    private void cmb_text_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
    {
      if (_init)
        return;

      btn_save_Click(null, null);

      _anno.SelectDocument(cmb_text.Items[cmb_text.SelectedIndex].Text);

      _editor.Tokens = _anno.EditorDocument;
      _editor.Annotations = _anno.EditorAnnotations;
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      var form = new ExportForm(cmb_text.Items[cmb_text.SelectedIndex].Text, _anno);
      form.ShowDialog();
    }

    private void btn_submit_Click(object sender, EventArgs e)
    {
      var p = radio_pb_del_q.IsChecked ? "" : radio_pb_true_w.IsChecked ? "true" : radio_pb_false_e.IsChecked ? "false" : "";
      var g = radio_gen_del_a.IsChecked ? "" : radio_gen_true_s.IsChecked ? "true" : radio_gen_false_d.IsChecked ? "false" : "";
      var c = radio_co_del_y.IsChecked ? "" : radio_co_true_x.IsChecked ? "true" : radio_co_false_c.IsChecked ? "false" : "";

      var pS = radio_pb_del_q.IsChecked ? "" : chk_pb_t.IsChecked ? "false" : "true";
      var gS = radio_gen_del_a.IsChecked ? "" : chk_gen_g.IsChecked ? "false" : "true";
      var cS = radio_co_del_y.IsChecked ? "" : chk_co_b.IsChecked ? "false" : "true";

      var change = new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = new Dictionary<string, object>
        {
          {"Personenbezeichnung?", p},
          {"Gendern hier nötig?", g},
          {"Co-Ref. zu Eigennamen?", c},
          {"Personenbezeichnung? (SICHERHEIT)", pS},
          {"Gendern hier nötig? (SICHERHEIT)", gS},
          {"Co-Ref. zu Eigennamen? (SICHERHEIT)", cS},
        }
      };

      _anno.Annotate(change);
      _editor.Tokens = _anno.EditorDocument;
      _editor.Annotations = _anno.EditorAnnotations;
    }

    private void commands_Enter(object sender, EventArgs e)
    {
      btn_focus.Image = Resources.button_green_record;
    }

    private void commands_Leave(object sender, EventArgs e)
    {
      btn_focus.Image = Resources.button_green_pause;
    }
  }
}
