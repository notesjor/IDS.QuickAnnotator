using RestSharp;

namespace IDS.QuickAnnotator.Client.Model
{
  public static class QuickAnnotatorApi
  {
    public static bool Signin(string authToken)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/signin");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{authToken}\"}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return response.Content == "true";
    }
  }
}
