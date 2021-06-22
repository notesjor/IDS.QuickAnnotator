using System;
using System.Collections.Generic;
using System.Linq;

namespace IDS.QuickAnnotator.Client.Helper
{
  public static class ReduceHelper
  {
    public static string[] Reduce(Dictionary<string, string[]> input, string unsureReplacement = "")
    {
      // rename
      var oldNames = input.Keys.ToArray();
      foreach (var n in oldNames)
      {
        input.Add(Replace(n), input[n]);
        input.Remove(n);
      }

      var res = new string[input.First().Value.Length];
      var keys = input.Keys.OrderBy(x => x).ToArray();

      for (var i = 0; i < res.Length; i++)
      {
        res[i] =
          string.Join(" ",
                      (from k in keys
                       let val = input[k][i]
                       where !string.IsNullOrWhiteSpace(val)
                       select $"{k}_{val.Substring(0, val.StartsWith("?") ? 2 : 1)}"))
                .Replace("?", unsureReplacement);
      }

      return res;
    }

    private static string Replace(string key)
    {
      switch (key)
      {
        case "Linguistische Klasse":
          return "LK";
        case "Notwendigkeit zu Gendern?":
          return "NG";
        case "Geschlechtsabstrahierendes Substantiv":
          return "GS";
        case "Referenz/Bezug auf konkrete Person / Personengruppe?":
          return "PG";
        case "Generisches Maskulinum":
          return "GM";
        case "Geschlecht aus Kontext erkennbar?":
          return "GK";
        case "Welches Geschlecht ist aus Kontext erkennbar?":
          return "G";
        default:
          throw new NotImplementedException();
      }
    }
  }
}
