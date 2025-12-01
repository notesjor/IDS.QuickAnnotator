using System.Net;
using IDS.QuickAnnotator.API.Model.Request;
using Newtonsoft.Json;
using RestSharp;

namespace IDS.QuickAnnotator.Client.Model
{
  public static class QuickAnnotatorApi
  {
    private static RestClient _client = new RestClient();

    public static bool Signin()
    {
      var request = new RestRequest($"{GlobalConfiguration.BaseUrl}/signin", Method.Post) { Timeout = new System.TimeSpan(0, 0, 5) };
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      return EnsureResponse(request, 2).Content == "true";
    }

    private static RestResponse EnsureResponse(RestRequest request, int max = 5)
    {
      RestResponse response = null;
      for (var i = 0; i < max; i++)
      {
        response = _client.Execute(request);
        if (response != null && response.StatusCode > 0 && !string.IsNullOrWhiteSpace(response.Content))
          break;
      }

      return response;
    }

    public static UserProfile GetProfile()
    {
      var request = new RestRequest($"{GlobalConfiguration.BaseUrl}/getProfile", Method.Post){Timeout = new System.TimeSpan(0, 0, 10)};
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<UserProfile>(EnsureResponse(request).Content);
    }

    public static string[] GetDocuments()
    {
      var request = new RestRequest($"{GlobalConfiguration.BaseUrl}/getDocuments",Method.Post){Timeout = new System.TimeSpan(0, 0, 30) };
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<string[]>(EnsureResponse(request).Content);
    }

    public static string[] GetDocument(string documentId)
    {
      var request = new RestRequest($"{GlobalConfiguration.BaseUrl}/getDocument", Method.Post){Timeout = new System.TimeSpan(0, 0, 30)};
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<string[]>(EnsureResponse(request).Content);
    }

    public static DocumentChange[] GetDocumentHistory(string documentId)
    {
      var request = new RestRequest($"{GlobalConfiguration.BaseUrl}/getDocumentHistory", Method.Post){Timeout = new System.TimeSpan(0, 0, 30)};
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<DocumentChange[]>(EnsureResponse(request).Content);
    }

    public static bool SetDocument(string documentId, DocumentChange change)
    {
      var request = new RestRequest($"{GlobalConfiguration.BaseUrl}/setDocument", Method.Post){Timeout = new System.TimeSpan(0, 0, 10)};
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\", \"Change\": {JsonConvert.SerializeObject(change)}}}", ParameterType.RequestBody);
      return EnsureResponse(request).StatusCode == HttpStatusCode.OK;
    }

    public static bool SetDocumentCompletion(string documentId)
    {
      var request = new RestRequest($"{GlobalConfiguration.BaseUrl}/setDocumentCompletion", Method.Post){Timeout = new System.TimeSpan(0, 0, 10)};
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      return EnsureResponse(request).StatusCode == HttpStatusCode.OK;
    }
  }
}
