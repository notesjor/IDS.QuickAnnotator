using IDS.QuickAnnotator.Client.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
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
      foreach (var d in QuickAnnotatorApi.GetDocuments())
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

    private int _editorIndexFrom = -1;
    private int _editorIndexTo = -1;

    private void EditorOnRightClick(int index)
    {
      _editor.TemporaryAnnotation();
      _editorIndexFrom = index;
      _editor.TemporaryAnnotation(index);
    }

    private void EditorOnLeftClick(int index)
    {
      _editor.TemporaryAnnotation();
      _editorIndexTo = index;
      _editor.TemporaryAnnotation(_editorIndexFrom, _editorIndexTo);
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
      
    }

    private void btn_submit_Click(object sender, EventArgs e)
    {

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
