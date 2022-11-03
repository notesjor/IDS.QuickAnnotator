using System;
using System.Linq;
using System.Threading;

namespace IDS.QuickAnnotator.Client.Model.Steps
{
  public static class StepModel
  {
    public static Step[] Steps { get; private set; }
    public static StepRule[] StepRules { get; private set; }

    public static void Init()
    {
      #region steps
      var step_lk = new Step
      {
        Name = "Linguistische Klasse",
        Description = "1:Nominale PB / 2:Stellvertreter / 3:Abhängig / SIM",
        PossibleValues = new[] { "1", "2", "3", "SIM" },
        AlwayOn = true
      };
      var step_generisches_pronomen = new Step
      {
        Name = "Generisches Pronomen?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_notwendigkeit_gendern = new Step
      {
        Name = "Notwendigkeit zu gendern?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_generisches_mask = new Step
      {
        Name = "Generisches Maskulinum?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_generisches_fem = new Step
      {
        Name = "Generisches Femininum?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_gesab_substantiv = new Step
      {
        Name = "Geschlechtsabstrahierendes Substantiv?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_ref_persoGroup = new Step
      {
        Name = "Referenz auf konkrete Person-/Gruppe?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_bereits_moviert = new Step
      {
        Name = "Bereits gegender/moviert?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_genus_sexus = new Step
      {
        Name = "Lexem mit Genus-Sexus-Kongruenz?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_ges_kontext = new Step
      {
        Name = "Geschlecht aus Kontext erkennbar?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_geschlecht = new Step
      {
        Name = "Welches Geschlecht?",
        PossibleValues = new[] { "male", "female", "none", "group" }
      };
      
      Steps = new[]
      {
        step_lk, step_generisches_pronomen, step_notwendigkeit_gendern, step_generisches_mask, step_generisches_fem,
        step_gesab_substantiv, step_ref_persoGroup, step_bereits_moviert, step_genus_sexus, step_ges_kontext,
        step_geschlecht
      };
      #endregion

      #region init
      foreach (var step in Steps)
        step.Init();
      #endregion

      #region rules
      StepRules = new[]
      {
        new StepRule
          { Parent = new[] { step_lk }, ValidSimpleValue = "2", Children = new[] { step_generisches_pronomen } },
        new StepRule
        {
          Parent = new[] { step_generisches_pronomen }, ValidSimpleValue = "true",
          Children = new[] { step_notwendigkeit_gendern }
        },
        new StepRule
          { Parent = new[] { step_lk }, ValidSimpleValue = "3", Children = new[] { step_notwendigkeit_gendern } },
        new StepRule
        {
          Parent = new[] { step_lk }, ValidSimpleValue = "1",
          Children = new[] { step_generisches_mask, step_generisches_fem }
        },
        new StepRule
        {
          Parent = new[] { step_generisches_mask, step_generisches_fem },
          ValidComplexRule = p => p.Any(x => x.Value == "true"),
          Children = new[] { step_generisches_mask, step_generisches_fem }
        },
        new StepRule
        {
          Parent = new[] { step_generisches_mask, step_generisches_fem },
          ValidComplexRule = p => p.All(x => x.Value == "false"),
          Children = new[] { step_gesab_substantiv, step_ref_persoGroup, step_bereits_moviert, step_genus_sexus }
        },
        new StepRule
          { Parent = new[] { step_ref_persoGroup }, ValidSimpleValue = "true", Children = new[] { step_ges_kontext } },
        new StepRule
          { Parent = new[] { step_bereits_moviert }, ValidSimpleValue = "true", Children = new[] { step_ges_kontext } },
        new StepRule
          { Parent = new[] { step_ges_kontext }, ValidSimpleValue = "true", Children = new[] { step_geschlecht } },
        new StepRule
          { Parent = new[] { step_geschlecht }, ValidSimpleValue = "true", Children = new[] { step_geschlecht } }
      };
      #endregion
    }

    public static void Reset()
    {
      foreach (var step in Steps)
      {
        step.StateSet(false);
        step.StateClear();
      }
    }

    public static void Update()
    {
      foreach(var rule in StepRules) 
        foreach(var x in rule.Children)
          x.StateSet(rule.IsValid);
    }
  }
}