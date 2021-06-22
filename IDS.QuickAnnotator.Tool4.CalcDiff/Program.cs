using System.Collections.Generic;
using IDS.QuickAnnotator.Client.Export;
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

      var html = new ExporterHtml();
      html.Export(model, args[1].Replace(".tsv", "_html"));

      var xml = new ExporterXml();
      xml.Export(model, args[1].Replace(".tsv", "_xml"));

      var xmlValid = new ExporterXmlValidation();
      xmlValid.Export(model, args[1].Replace(".tsv", "_xmlValid"));
    }
  }
}
