using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IDS.QuickAnnotator.Client.Controls.Abstract;
using IDS.QuickAnnotator.Client.Model.Steps;
using IDS.QuickAnnotator.Client.Properties;
using Telerik.WinControls.UI;

namespace IDS.QuickAnnotator.Client.Controls
{
  public partial class StepControl : AbstractControl
  {
    private List<RadRadioButton> _radRadioButtons = new List<RadRadioButton>();

    public StepControl()
    {
      InitializeComponent();
    }

    public string StepName
    {
      get => lbl_head.Text;
      set => lbl_head.Text = value;
    }

    public string StepDescription
    {
      get => lbl_desc.Text;
      set => lbl_desc.Text = value;
    }

    public string[] PossibleValues
    {
      set
      {
        for (var i = value.Length - 1; i > -1; i--)
        {
          var radio = new RadRadioButton();
          radio.Dock = DockStyle.Left;
          radio.Font = new Font("Roboto Medium", 8.5F);
          radio.Location = new Point(48, 3);
          radio.Margin = new Padding(6);
          radio.Name = $"radio_{i}";
          radio.Padding = new Padding(8, 2, 8, 0);
          radio.Size = new Size(48, 32);
          radio.Text = ValueToText(value[i]);
          radio.Tag = value[i];
          radio.TextImageRelation = TextImageRelation.ImageBeforeText;
          radio.ToggleStateChanged += StateChanged;

          panel_values.Controls.Add(radio);
          _radRadioButtons.Add(radio);
        }
        panel_values.Controls.Remove(radio_del);
        panel_values.Controls.Add(radio_del);
      }
    }

    private string ValueToText(string value)
    {
      switch (value)
      {
        case "true":
        case "false":
        case "male":
        case "female":
        case "none":
        case "group":
          return "";
        default:
          return value;
      }
    }

    public void StateSet(bool value)
    {
      foreach (var x in _radRadioButtons) 
        x.Image = ValueToImage(x.Tag.ToString(), value);
    }

    public void StateClear()
    {
      foreach (var x in _radRadioButtons)
        x.IsChecked = false;

      chk_unsure.Checked = false;
      radio_del.IsChecked = false;
    }

    private Image ValueToImage(string value, bool enable)
    {
      if (!enable)
      {
        switch (value)
        {
          case "true":
            return Resources.ok_button_grey;
          case "false":
            return Resources.delete_button_error_grey;
          case "male":
            return Resources.gender_male_grey;
          case "female":
            return Resources.gender_female_grey;
          case "none":
            return Resources.gender_non_binary_grey;
          case "group":
            return Resources.group_1_grey;
          default:
            return null;
        }
      }

      switch (value)
      {
        case "true":
          return Resources.ok_button;
        case "false":
          return Resources.delete_button_error;
        case "male":
          return Resources.gender_male;
        case "female":
          return Resources.gender_female;
        case "none":
          return Resources.gender_non_binary;
        case "group":
          return Resources.group_1;
        default:
          return null;
      }
    }

    public string Value
    {
      get
      {
        var first = _radRadioButtons.FirstOrDefault(x => x.IsChecked);
        if (first == null)
          return "";
        return (chk_unsure.Checked ? "?" : "") + first.Tag;
      }
    }

    private void StateChanged(object sender, StateChangedEventArgs args)
    {
      StepModel.Update();
    }

    public void HighlightReset()
    {
      foreach (var x in _radRadioButtons)
        x.BackColor = Color.White;
      chk_unsure.BackColor = Color.White;
    }

    public void HighlightSet(string value)
    {
      var pure = value.Replace("?", "");
      foreach (var x in _radRadioButtons) 
        x.BackColor = x.Tag.ToString() == pure ? Color.Yellow : Color.White;
      chk_unsure.BackColor = value.Contains("?") ? Color.Yellow : Color.White;
    }
  }
}
