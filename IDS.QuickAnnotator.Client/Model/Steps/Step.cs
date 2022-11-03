using System.Web.UI;

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
      Control.PossibleValues = PossibleValues;
    }

    public string Value => Control.Value;

    public void StateSet(bool value)
    {
      if(AlwayOn)
        value = true;

      Control.StateSet(value);
    }

    public void StateClear()
      => Control.StateClear();
  }
}
