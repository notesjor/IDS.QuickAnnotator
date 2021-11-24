using System;
using System.Collections.Generic;
using IDS.QuickAnnotator.Client.Export;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation;

namespace IDS.QuickAnnotator.Tool4.CalcDiff
{
  class Program
  {
    static void Main(string[] args)
    {
      var model = new AnnotationModelOffline(args[0]);

      var diff = new ExporterDiff();
      diff.Export(model, args[1]);

      var diffS = new ExporterStrictDiff();
      diffS.Export(model, args[1].Replace(".tsv", "_strict.tsv"));

      var html = new ExporterHtml();
      html.Export(model, args[1].Replace(".tsv", "_html"));

      var xml = new ExporterXml();
      xml.Export(model, args[1].Replace(".tsv", "_xml"));

      var xmlValid = new ExporterXmlValidation();
      xmlValid.Export(model, args[1].Replace(".tsv", "_xmlValid"));

      var calc = new ExporterCalculateResults();
      calc.Export(model, args[1].Replace(".tsv", "_calc.tsv"));

      var cross = new ExporterCalculateCrossResults();
      cross.Export(model, args[1].Replace(".tsv", "_calcCross.tsv"));

      var snippets = new ExporterCalculateSnippetsResults();
      snippets.Export(model, args[1].Replace(".tsv", "_snippets.tsv"));

      var crossSnippets = new ExporterCalculateCrossSnippetsResults();
      crossSnippets.Export(model, args[1].Replace(".tsv", "_crossSnippets.tsv"));
    }
  }
}
