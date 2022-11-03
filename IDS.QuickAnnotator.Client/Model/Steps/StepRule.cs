using System;
using System.Linq;

namespace IDS.QuickAnnotator.Client.Model.Steps
{
  public class StepRule
  {
    public Step[] Parent { get; set; }
    public string ValidSimpleValue { get; set; }
    public StepRuleDelegate ValidComplexRule { get; set; }
    public Step[] Children { get; set; }

    public delegate bool StepRuleDelegate(Step[] Parent);

    public bool IsValid
    {
      get
      {
        return ValidSimpleValue == null
          ? ValidComplexRule != null && ValidComplexRule(Parent)
          : Parent.Any(p => p.Value == ValidSimpleValue);
      }
    }
  }
}