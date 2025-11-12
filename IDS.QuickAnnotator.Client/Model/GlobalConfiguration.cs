namespace IDS.QuickAnnotator.Client.Model
{
  public static class GlobalConfiguration
  {
    public static string BaseUrl => "http://lexik02.ids-mannheim.de:45459/"; // "http://localhost:4545";
    public static string AuthToken { get; set; }
  }
}
