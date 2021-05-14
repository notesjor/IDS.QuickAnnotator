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
        case '5':
          radio_lk_del_5.IsChecked = true;
          break;
        case '1':
          radio_lk_1.IsChecked = true;
          break;
        case '2':
          radio_lk_2.IsChecked = true;
          break;
        case '3':
          radio_lk_3.IsChecked = true;
          break;
        case '4':
          radio_lk_4.IsChecked = true;
          break;
        case '6':
          chk_lk_6.IsChecked = !chk_lk_6.IsChecked;
          break;

        case 'q':
          radio_gen_del_q.IsChecked = true;
          break;
        case 'w':
          radio_gen_true_w.IsChecked = true;
          break;
        case 'e':
          radio_gen_false_e.IsChecked = true;
          break;
        case 't':
          chk_gen_t.IsChecked = !chk_gen_t.IsChecked;
          break;

        case 'a':
          radio_abstr_del_a.IsChecked = true;
          break;
        case 's':
          radio_abstr_true_s.IsChecked = true;
          break;
        case 'd':
          radio_abstr_false_d.IsChecked = true;
          break;
        case 'g':
          chk_abstr_g.IsChecked = !chk_abstr_g.IsChecked;
          break;

        case 'y':
          radio_ref_del_y.IsChecked = true;
          break;
        case 'x':
          radio_ref_true_x.IsChecked = true;
          break;
        case 'c':
          radio_ref_false_c.IsChecked = true;
          break;
        case 'b':
          chk_ref_b.IsChecked = !chk_ref_b.IsChecked;
          break;

        case 'ß':
          radio_mask_del_ß.IsChecked = true;
          break;
        case '0':
          radio_mask_true_0.IsChecked = true;
          break;
        case '9':
          radio_mask_false_9.IsChecked = true;
          break;
        case '7':
          chk_mask_7.IsChecked = !chk_mask_7.IsChecked;
          break;


        case '+':
          radio_kont_del_üü.IsChecked = true;
          break;
        case 'ü':
          radio_kont_true_ü.IsChecked = true;
          break;
        case 'p':
          radio_kont_false_p.IsChecked = true;
          break;
        case 'i':
          chk_kont_i.IsChecked = !chk_kont_i.IsChecked;
          break;

        case '#':
          radio_sex_del_ää.IsChecked = true;
          break;
        case 'ä':
          radio_sex_male_ä.IsChecked = true;
          break;
        case 'ö':
          radio_sex_female_ö.IsChecked = true;
          break;
        case 'l':
          radio_sex_none_l.IsChecked = true;
          break;
        case 'k':
          radio_sex_group_k.IsChecked = true;
          break;
        case 'h':
          chk_sex_h.IsChecked = !chk_sex_h.IsChecked;
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

    private void Cmb_textOnSelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
      var lk = radio_lk_del_5.IsChecked ? "" : (chk_lk_6.IsChecked ? "?" : "") + (radio_lk_1.IsChecked ? "1" : radio_lk_2.IsChecked ? "2" : radio_lk_3.IsChecked ? "3" : radio_lk_4.IsChecked ? "4" : "");
      var ge = radio_gen_del_q.IsChecked ? "" : (chk_gen_t.IsChecked ? "?" : "") + (radio_gen_true_w.IsChecked ? "true" : radio_gen_false_e.IsChecked ? "false" : "");
      var ab = radio_abstr_del_a.IsChecked ? "" : (chk_abstr_g.IsChecked ? "?" : "") + (radio_abstr_true_s.IsChecked ? "true" : radio_abstr_false_d.IsChecked ? "false" : "");
      var re = radio_ref_del_y.IsChecked ? "" : (chk_ref_b.IsChecked ? "?" : "") + (radio_ref_true_x.IsChecked ? "true" : radio_ref_false_c.IsChecked ? "false" : "");
      var ma = radio_mask_del_ß.IsChecked ? "" : (chk_mask_7.IsChecked ? "?" : "") + (radio_mask_true_0.IsChecked ? "true" : radio_mask_false_9.IsChecked ? "false" : "");
      var ko = radio_kont_del_üü.IsChecked ? "" : (chk_kont_i.IsChecked ? "?" : "") + (radio_kont_true_ü.IsChecked ? "true" : radio_kont_false_p.IsChecked ? "false" : "");
      var se = radio_sex_del_ää.IsChecked ? "" : (chk_sex_h.IsChecked ? "?" : "") + (radio_sex_male_ä.IsChecked ? "male" : radio_sex_female_ö.IsChecked ? "female" : radio_sex_none_l.IsChecked ? "none" : radio_sex_group_k.IsChecked ? "group" : "");

      var change = new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = new Dictionary<string, object>
        {
          {"Linguistische Klasse",lk},
          {"Notwendigkeit zu Gendern?",ge},
          {"Geschlechtsabstrahierendes Substantiv",ab},
          {"Referenz/Bezug auf konkrete Person / Personengruppe?",re},
          {"Generisches Maskulinum",ma},
          {"Geschlecht aus Kontext erkennbar?",ko},
          {" Welches Geschlecht ist aus Kontext erkennbar?",se}
        }
      };

      foreach (var control in annotation_editor.Controls)
      {
        if (!(control is Panel panel))
          continue;

        foreach (Control option in panel.Controls)
          switch (option)
          {
            case RadCheckBox chk:
              chk.IsChecked = false;
              break;
            case RadRadioButton radio:
              radio.IsChecked = false;
              break;
          }
      }

      // _anno.Annotate(change);
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
