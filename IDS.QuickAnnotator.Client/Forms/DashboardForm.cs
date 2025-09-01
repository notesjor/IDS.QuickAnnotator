using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Controls;
using IDS.QuickAnnotator.Client.Forms.Abstract;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation;
using IDS.QuickAnnotator.Client.Model.Steps;
using IDS.QuickAnnotator.Client.Model.User;
using IDS.QuickAnnotator.Client.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IDS.QuickAnnotator.Client.Forms
{
  public partial class DashboardForm : AbstractForm
  {
    private Editor _editor = new Editor();
    private readonly AnnotationModelOnline _anno;
    private readonly UserModel _user;
    private bool _init = true;

    public DashboardForm()
    {
      InitializeComponent();
      cmb_text.CommandBarDropDownListElement.TextBox.Margin = new Padding(0, 6, 0, 0);
      cmb_text.CommandBarDropDownListElement.TextBox.TextBoxItem.ReadOnly = true;
      commandBarStripElement1.OverflowButton.Visibility = ElementVisibility.Collapsed;

      #region EDITOR
      _editor.Height = elementHost1.Height;
      _editor.Width = elementHost1.Width;
      _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      _editor.LeftClick += EditorOnLeftClick;
      _editor.RightClick += EditorOnRightClick;
      //_editor.Highlight = new HashSet<string> { };
      _editor.Highlight = new HashSet<string>
      {
        "Geschäftsführer", "Geschäftsführer", "Geschäftsführers", "Geschäftsführern", "Geschäftsführerin", "Geschäftsführerin", "Geschäftsführerinnen", "Künstler", "Künstler", "Künstlers", "Künstlern", "Künstlerin", "Künstlerin", "Künstlerinnen", "Lehrer", "Lehrer", "Lehrers", "Lehrern", "Lehrerin", "Lehrerin", "Lehrerinnen", "Leiter", "Leiter", "Leiters", "Leitern", "Leiterin", "Leiterin", "Leiterinnen", "Mitarbeiter", "Mitarbeiter", "Mitarbeiters", "Mitarbeitern", "Mitarbeiterin", "Mitarbeiterin", "Mitarbeiterinnen", "Spieler", "Spieler", "Spielers", "Spielern", "Spielerin", "Spielerin", "Spielerinnen", "Berliner", "Berliner", "Berliners", "Berlinern", "Berlinerin", "Berlinerin", "Berlinerinnen", "Hamburger", "Hamburger", "Hamburgers", "Hamburgern", "Hamburgerin", "Hamburgerin", "Hamburgerinnen", "Schweizer", "Schweizer", "Schweizers", "Schweizern", "Schweizerin", "Schweizerin", "Schweizerinnen", "Wiener", "Wiener", "Wieners", "Wienern", "Wienerin", "Wienerin", "Wienerinnen", "Bürger", "Bürger", "Bürgers", "Bürgern", "Bürgerin", "Bürgerin", "Bürgerinnen", "Freund", "Freund", "Freundes", "Freunds", "Freunde", "Freunden", "Freundin", "Freundin", "Freundinnen", "Gastgeber", "Gastgeber", "Gastgebers", "Gastgebern", "Gastgeberin", "Gastgeberin", "Gastgeberinnen", "Schüler", "Schüler", "Schülers", "Schülern", "Schülerin", "Schülerin", "Schülerinnen", "Teilnehmer", "Teilnehmer", "Teilnehmers", "Teilnehmern", "Teilnehmerin", "Teilnehmerin", "Teilnehmerinnen", "Bürgermeister", "Bürgermeister", "Bürgermeisters", "Bürgermeistern", "Bürgermeisterin", "Bürgermeisterin", "Bürgermeisterinnen", "Chef", "Chef", "Chefs", "Chefin", "Chefin", "Chefinnen", "Minister", "Minister", "Ministers", "Ministern", "Ministerin", "Ministerin", "Ministerinnen", "Pfarrer", "Pfarrer", "Pfarrers", "Pfarrern", "Pfarrerin", "Pfarrerin", "Pfarrerinnen", "Präsident", "Präsident", "Präsidenten", "Präsidentin", "Präsidentin", "Präsidentinnen", "Richter", "Richter", "Richters", "Richtern", "Richterin", "Richterin", "Richterinnen"
      };

      elementHost1.Child = _editor;

      _user = new UserModel();
      _anno = new AnnotationModelOnline(_user);

      cmb_text.Items.Clear();
      var text_index = 0;

      foreach (var d in _anno.AvailableDocumentIds)
      {
        if (d == _user.Profile.LastDocumentId)
          text_index = cmb_text.Items.Count;

        var item = new RadListDataItem(d);
        if (_user.Profile.DoneDocumentIds.Contains(d))
        {
          item.Image = Resources.ok_button;
          item.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        cmb_text.Items.Add(item);
      }
      #endregion

      #region APP
      Text = $"QuickAnnotator (Hallo: {_user.Profile.UserName})";

      _init = false;
      cmb_text.SelectedIndex = text_index;
      #endregion

      #region STEPS
      foreach (var step in StepModel.Steps.Reverse())
      {
        step.Control.Dock = DockStyle.Top;
        step.StateSet(false);
        panel_controls.Controls.Add(step.Control);
      }
      #endregion
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

      DisplayExsistingAnnotation(index);
      _editor.TemporaryAnnotation(_editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom, _editorIndexTo);
    }

    private void DisplayExsistingAnnotation(int index)
    {
      // RESET
      foreach (var control in panel_controls.PanelContainer.Controls)
      {
        if (!(control is Panel panel))
          continue;

        foreach (Control option in panel.Controls)
          switch (option)
          {
            case RadCheckBox chk:
              chk.BackColor = Color.Transparent;
              break;
            case RadRadioButton radio:
              radio.BackColor = Color.Transparent;
              break;
          }
      }

      // SET
      var last = _anno.GetLastAnnotationState(index);
      StepModel.HighlightReset();
      if (last?.Annotation == null)
        return;

      StepModel.HighlightSet(last.Annotation);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      if (QuickAnnotatorApi.SetDocumentCompletion(cmb_text.Items[cmb_text.SelectedIndex].Text))
      {
        _user.LoadProfile();
        foreach (var item in cmb_text.Items)
        {
          item.Image = _user.Profile.DoneDocumentIds.Contains(item.Text) ? Resources.ok_button : null;
          item.TextImageRelation = TextImageRelation.ImageBeforeText;
        }
      }
    }

    private void Cmb_textOnSelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      if (_init)
        return;

      btn_save_Click(null, null);

      _anno.SelectDocument = cmb_text.Items[cmb_text.SelectedIndex].Text;

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
      if (_editorIndexTo == -1)
        return;

      _anno.Annotate(new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = StepModel.GetAnnotation()
      });

      foreach (var control in panel_controls.PanelContainer.Controls)
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

      StepModel.Reset();

      if (StepModel.IsDeleteState())
        _editor.Tokens = _anno.EditorDocument;
      _editor.Annotations = _anno.EditorAnnotations;
    }

    // NOTE -------------------------------------------- Start der Doppelformen ->
    // Wird nicht mehr verwendet
    //private void btn_submit_doppelform_Click(object sender, EventArgs e)
    //{
    //  var from = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom;
    //  var to = _editorIndexTo + 1;
    //  if (to - from < 2)
    //  {
    //    MessageBox.Show("Doppelformen müssen mehrere Token umfassen. Zuerst Rechtsklick auf erstes Token, dann Linksklick auf letztes Token.");
    //    return;
    //  }
    //
    //  _anno.Annotate(new DocumentChange
    //  {
    //    From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
    //    To = _editorIndexTo + 1,
    //    Annotation = new Dictionary<string, object>
    //    {
    //      {"Doppelform", "true"}
    //    }
    //  });
    //
    //  _editor.Annotations = _anno.EditorAnnotations;
    //}

    private void btn_submit_doppelform_altern_Click(object sender, EventArgs e)
    {
      var from = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom;
      var to = _editorIndexTo + 1;
      if (to - from < 2)
      {
        MessageBox.Show("Doppelformen müssen mehrere Token umfassen. Zuerst Rechtsklick auf erstes Token, dann Linksklick auf letztes Token.");
        return;
      }

      _anno.Annotate(new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = new Dictionary<string, object>
        {
          {"Doppelform", "true"}
        }
      });

      _editor.Annotations = _anno.EditorAnnotations;
    }

    private void btn_submit_doppelform_regu_Click(object sender, EventArgs e)
    {
      var from = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom;
      var to = _editorIndexTo + 1;
      if (to - from < 2)
      {
        MessageBox.Show("Doppelformen müssen mehrere Token umfassen. Zuerst Rechtsklick auf erstes Token, dann Linksklick auf letztes Token.");
        return;
      }

      _anno.Annotate(new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = new Dictionary<string, object>
        {
          {"Reguläre Doppelform", "true"}
        }
      });

      _editor.Annotations = _anno.EditorAnnotations;
    }
    // NOTE <-------------------------------------------- Ende der Doppelformen

    private void btn_screenFix_Click(object sender, EventArgs e)
    {
      foreach (Control c in panel_controls.PanelContainer.Controls)
      {
        if (!(c is StepControl step)) 
          continue;
        
        var nsize = step.Size.Height + 5;
        
        step.MaximumSize = step.MinimumSize = new Size(0, nsize);
        step.Size = new Size(step.Size.Width, nsize);
      }
    }
  }
}
