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
using IDS.QuickAnnotator.Client.Local.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using IDS.QuickAnnotator.Client.Forms;
using System.IO;

namespace IDS.QuickAnnotator.Client.Local.Forms
{
  public partial class DashboardFormLocalAcceptReject : AbstractForm
  {
    private Editor _editor = new Editor();
    private readonly AnnotationModelOfflineAcceptReject _anno;
    private bool _init = true;

    public DashboardFormLocalAcceptReject(string qafFile)
    {
      InitializeComponent();
      commandBarStripElement1.OverflowButton.Visibility = ElementVisibility.Collapsed;

      #region EDITOR
      _editor.Height = elementHost1.Height;
      _editor.Width = elementHost1.Width;
      _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      _editor.LeftClick += EditorOnLeftClick;
      _editor.RightClick += EditorOnRightClick;

      elementHost1.Child = _editor;

      _anno = new AnnotationModelOfflineAcceptReject(qafFile);

      var text_index = 0;
      #endregion

      #region APP
      Text = $"QuickAnnotator (LOKALER SAMPLER)";

      _init = false;
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

    /*
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
    */

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

    private void btn_submit_doppelform_Click(object sender, EventArgs e)
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

    private void btn_loadProject_Click(object sender, EventArgs e)
    {

    }

    private void btn_accept_Click(object sender, EventArgs e)
    {

    }

    private void btn_reject_Click(object sender, EventArgs e)
    {

    }
  }
}
