namespace IDS.QuickAnnotator.Client.Model
{
  public static class GlobalConfiguration
  {
    public static string BaseUrl => "http://lexik02.ids-mannheim.de:4545/"; // "http://localhost:4545";
    public static string AuthToken { get; set; }
  }
}
