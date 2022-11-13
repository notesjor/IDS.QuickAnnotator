using System.Drawing;
using System.Web.UI;
using IDS.QuickAnnotator.Client.Controls;

namespace IDS.QuickAnnotator.Client.Model.Steps
{
  public class Step
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] PossibleValues { get; set; }
    public bool AlwayOn { get; set; }
    public StepControl Control { get; private set; }

    public void Init()
    {
      Control = new StepControl();
      Control.StepName = Name;
      Control.StepDescription = Description;
      Control.Size = string.IsNullOrEmpty(Description) ? new Size(412, 53) : new Size(412, 78);
      Control.MaximumSize = Control.MinimumSize = new Size(0, Control.Size.Height);

      Control.PossibleValues = PossibleValues;
    }

    public string Value => Control.Value;
    public string ValuePure => Control.Value.Replace("?", "");

    public void StateSet(bool value)
    {
      if(AlwayOn)
        value = true;

      Control.StateSet(value);
    }

    public void StateClear()
      => Control.StateClear();

    public void HighlightReset()
      => Control.HighlightReset();

    public void HighlightSet(object value)
      => Control.HighlightSet(value.ToString());
  }
}
