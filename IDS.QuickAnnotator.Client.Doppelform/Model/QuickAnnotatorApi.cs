using System.Net;
using IDS.QuickAnnotator.API.Model.Request;
using Newtonsoft.Json;
using RestSharp;

namespace IDS.QuickAnnotator.Client.Model
{
  public static class QuickAnnotatorApi
  {
    public static bool Signin()
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/signin") { Timeout = -1 };
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      return EnsureResponse(client, request, true).Content == "true";
    }

    private static IRestResponse EnsureResponse(RestClient client, RestRequest request, bool hasContent)
    {
      IRestResponse response = null;
      for (var i = 0; i < 5; i++)
      {
        response = client.Execute(request);
        if (response != null && response.StatusCode > 0)
          if (hasContent)
          {
            if (!string.IsNullOrWhiteSpace(response.Content))
              break;
          }
          else
            break;
      }

      return response;
    }

    public static UserProfile GetProfile()
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getProfile") { Timeout = -1 };
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<UserProfile>(EnsureResponse(client, request, true).Content);
    }

    public static string[] GetDocuments()
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getDocuments") { Timeout = -1 };
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<string[]>(EnsureResponse(client, request, true).Content);
    }

    public static string[] GetDocument(string documentId)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getDocument") { Timeout = -1 };
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<string[]>(EnsureResponse(client, request, true).Content);
    }

    public static DocumentChange[] GetDocumentHistory(string documentId)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getDocumentHistory") { Timeout = -1 };
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      return JsonConvert.DeserializeObject<DocumentChange[]>(EnsureResponse(client, request, true).Content);
    }

    public static bool SetDocument(string documentId, DocumentChange change)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/setDocument") { Timeout = -1 };
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\", \"Change\": {JsonConvert.SerializeObject(change)}}}", ParameterType.RequestBody);
      return EnsureResponse(client, request, false).StatusCode == HttpStatusCode.OK;
    }

    public static bool SetDocumentCompletion(string documentId)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/setDocumentCompletion") { Timeout = -1 };
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return EnsureResponse(client, request, false).StatusCode == HttpStatusCode.OK;
    }
  }
}
