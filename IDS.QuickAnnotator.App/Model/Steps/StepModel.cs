using System;
using System.Collections.Generic;
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
        //Description = "1:Nominale PB / 2:Stellvertreter / 3:Abhängig / SIM",
        // PossibleValues = new[] { "1", "2", "3", "SIM" },
        PossibleValues = new[] { "1", "SIM" },
        AlwayOn = true
      };
      var step_numerus_plural = new Step
      {
        Name = "Plural?",
        Description = "Ja = Plural / Nein = Singular",
        PossibleValues = new[] { "true", "false" }
      };
      //var step_in_definit = new Step
      //{
      //  Name = "Definit?",
      //  Description = "Ja = Definit / Nein = Indefinit",
      //  PossibleValues = new[] { "true", "false" }
      //};
      var step_form_genus = new Step
      {
        Name = "Form/Genus",
        Description = "Maskulinum / Femininum / Genderzeichen",
        PossibleValues = new[] { "male", "female", "none" }
      };
      var step_usage = new Step
      {
        Name = "Geschlechtsspezifisch?",
        Description = "Ja = geschlechtsspezifisch / Nein = geschlechtsübergreifend",
        PossibleValues = new[] { "true", "false" }
      };
      //var step_granulation = new Step
      //{
      //  Name = "Grad der Identifizierbarkeit",
      //  PossibleValues = new[] { "--", "-", "+", "++" }
      //};
      var step_beruf = new Step
      {
        Name = "Beruf/Rolle",
        PossibleValues = new[] { "B", "R", "-" }
      };
      var step_semantik = new Step
      {
        Name = "Semantik",
        Description = "Nr. der Bedeutung im Wörterbuch",
        PossibleValues = new[] { "1", "2", "-" }
      };
      /*
      var step_artikel_bestimmt = new Step
      {
        Name = "Bestimmter Artikel? - Nein = unbestimmter Artikel",
        PossibleValues = new[] { "true", "false" }
      };
      */
      /*
      var step_generisches_pronomen = new Step
      {
        Name = "Generisches Pronomen?",
        PossibleValues = new[] { "true", "false" }
      };
      */
      /*
      var step_notwendigkeit_gendern = new Step
      {
        Name = "Notwendigkeit zu Gendern?",
        PossibleValues = new[] { "true", "false" }
      };
      */
      /*
      var step_generisches_mask = new Step
      {
        Name = "Generisches Maskulinum",
        PossibleValues = new[] { "true", "false" }
      };
      var step_gesab_beruf = new Step
      {
        Name = "Beruf (=ja) / Rolle (=nein)",
        PossibleValues = new[] { "true", "false" }
      };
      var step_gesab_semantik = new Step
      {
        Name = "Semantik: Definition",
        PossibleValues = new[] { "1", "2", "andres" },
      };
      */
      /*
      var step_generisches_fem = new Step
      {
        Name = "Generisches Femininum",
        PossibleValues = new[] { "true", "false" }
      };
      */
      /*var step_gesab_substantiv = new Step
      {
        Name = "Geschlechtsabstrahierendes Substantiv",
        PossibleValues = new[] { "true", "false" }
      };*/
      /*var step_ref_persoGroup = new Step
      {
        Name = "Referenz/Bezug auf konkrete Person / Personengruppe?",
        PossibleValues = new[] { "true", "false" }
      };*/
      /*
      var step_bereits_moviert = new Step
      {
        Name = "Moviert?",
        PossibleValues = new[] { "true", "false" }
      };
      */
      /*var step_bereits_gendert = new Step
      {
        Name = "Gegendert?",
        PossibleValues = new[] { "true", "false" }
      };*/
      /*
      var step_genus_sexus = new Step
      {
        Name = "Lexem mit Genus-Sexus-Kongruenz?",
        PossibleValues = new[] { "true", "false" }
      };
      */
      /*
      var step_ges_kontext = new Step
      {
        Name = "Geschlecht aus Kontext erkennbar?",
        PossibleValues = new[] { "true", "false" }
      };
      var step_geschlecht = new Step
      {
        Name = "Welches Geschlecht ist aus Kontext erkennbar?",
        PossibleValues = new[] { "male", "female", "none", "group" }
      };
      */

      Steps = new[]
      {
        step_lk, 
        step_numerus_plural, 
        //step_artikel_bestimmt, 
        //step_gesab_beruf,
        //step_gesab_semantik,
        //step_generisches_pronomen, 
        //step_generisches_mask, 
        //step_generisches_fem, 
        //step_notwendigkeit_gendern,
        //step_gesab_substantiv, 
        //step_ref_persoGroup, 
        //step_bereits_moviert, 
        //step_bereits_gendert,
        //step_genus_sexus, 
        //step_ges_kontext,
        //step_geschlecht
        //step_in_definit,
        step_form_genus,
        step_usage,
        //step_granulation
        step_beruf,
        step_semantik
      };
      #endregion

      #region init
      foreach (var step in Steps)
        step.Init();
      #endregion

      #region rules
      StepRules = new[]
      {
        // new StepRule { Parent = new[] { step_lk }, ValidSimpleValue = "2", Children = new[] { step_generisches_pronomen } },
        // new StepRule { Parent = new[] { step_generisches_pronomen }, ValidSimpleValue = "true", Children = new[] { step_notwendigkeit_gendern } },
        // new StepRule { Parent = new[] { step_lk }, ValidSimpleValue = "3", Children = new[] { step_notwendigkeit_gendern } },
        new StepRule
        {
          Parent = new[] { step_lk }, ValidSimpleValue = "1", Children = new[]
          {
            step_numerus_plural,            
            step_form_genus,
            step_beruf,
            step_semantik,
           }
        },
        new StepRule
        {
          Parent = new[] { step_form_genus }, ValidComplexRule = p => p.Any(x => x.ValuePure != ""), Children = new[]
          {
            step_usage,
            //step_granulation
          }
        },
        /*
        new StepRule
        {
          Parent = new[] { step_generisches_mask, step_generisches_fem },
          ValidComplexRule = p => p.Any(x => x.ValuePure == "true"),
          Children = new[] { step_notwendigkeit_gendern }
        },
        */
        /*
        new StepRule
        {
          Parent = new[] { step_generisches_mask },
          ValidComplexRule = p => p.Any(x => x.ValuePure == "false"),
          Children = new[]
          { 
            //step_gesab_substantiv, 
            //step_ref_persoGroup,
            step_bereits_moviert, 
            //step_bereits_gendert,
            //step_genus_sexus 
            }
        },
        */
        /*
        new StepRule
          { Parent = new[] { step_ref_persoGroup }, ValidSimpleValue = "true", Children = new[] { step_ges_kontext } },
        new StepRule
          { Parent = new[] { step_bereits_moviert }, ValidSimpleValue = "true", Children = new[] { step_ges_kontext } },
        new StepRule
          { Parent = new[] { step_ges_kontext }, ValidSimpleValue = "true", Children = new[] { step_geschlecht } },
        new StepRule
          { Parent = new[] { step_geschlecht }, ValidSimpleValue = "true", Children = new[] { step_geschlecht } },
        */
        // new StepRule { Parent = new[] { step_genus_sexus }, ValidSimpleValue = "true", Children = new[] { step_ges_kontext, step_geschlecht } }
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
      foreach (var step in Steps)
        step.StateSet(false);

      foreach (var rule in StepRules)
        if (rule.IsValid)
          foreach (var child in rule.Children)
            child.StateSet(true);
    }

    public static Dictionary<string, object> GetAnnotation()
      => Steps.ToDictionary<Step, string, object>(step => step.Name, step => step.Value);

    public static bool IsDeleteState() => Steps.All(step => step.Value == "");

    public static void HighlightReset()
    {
      foreach (var step in Steps)
        step.HighlightReset();
    }

    public static void HighlightSet(Dictionary<string, object> annotation)
    {
      foreach (var step in Steps)
        if (annotation.ContainsKey(step.Name))
          step.HighlightSet(annotation[step.Name]);
    }
  }
}