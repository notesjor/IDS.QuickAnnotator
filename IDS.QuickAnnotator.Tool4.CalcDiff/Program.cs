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
      var exporter = new ExporterDiff { DocumentFilter = new HashSet<string>(model.AvailableDocumentIds) };
      exporter.Export(model, args[1]);
    }
  }
}
