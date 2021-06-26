using System.Collections.Generic;
using IDS.QuickAnnotator.API.Model.Request;

namespace IDS.QuickAnnotator.Client.Model
{
  public class SnippetExportSequence
  {
    public SnippetExportSequence(ref string[] document, DocumentChange dc, string value)
    {
      From = dc.From;
      To = dc.To;
      Value = value;

      var tmp = new List<string>();
      for (var i = From; i < To; i++)
        tmp.Add(document[i]);
      Snippet = string.Join(" ", tmp);
    }

    public int From { get; set; }
    public int To { get; set; }
    public string Value { get; set; }
    public string Snippet { get; set; }

    public bool IsChange(SnippetExportSequence other)
    {
      if (other.To < From)
        return false;
      if (other.From > To)
        return false;
      if (other.From >= From && other.From < To)
        return true;
      return false;
    }

    public bool IsFullMatch(SnippetExportSequence other)
      => other.From == From && other.To == To;
  }
}
