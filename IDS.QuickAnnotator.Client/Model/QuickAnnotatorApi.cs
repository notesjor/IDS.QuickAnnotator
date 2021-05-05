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
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/signin");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return response.Content == "true";
    }

    public static UserProfile GetProfile()
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getProfile");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\"}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return JsonConvert.DeserializeObject<UserProfile>(response.Content);
    }

    public static string[] GetDocuments()
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getDocuments");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      IRestResponse response = client.Execute(request);
      return JsonConvert.DeserializeObject<string[]>(response.Content);
    }

    public static string[] GetDocument(string documentId)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getDocument");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return JsonConvert.DeserializeObject<string[]>(response.Content);
    }

    public static DocumentChange[] GetDocumentHistory(string documentId)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/getDocumentHistory");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return JsonConvert.DeserializeObject<DocumentChange[]>(response.Content);
    }

    public static bool SetDocument(string documentId, DocumentChange change)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/setDocument");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\", \"Change\": {JsonConvert.SerializeObject(change)}}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return response.StatusCode == HttpStatusCode.OK;
    }

    public static bool SetDocumentCompletion(string documentId)
    {
      var client = new RestClient($"{GlobalConfiguration.BaseUrl}/setDocumentCompletion");
      client.Timeout = -1;
      var request = new RestRequest(Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddParameter("application/json", $"{{\"AuthToken\": \"{GlobalConfiguration.AuthToken}\", \"DocumentId\": \"{documentId}\"}}", ParameterType.RequestBody);
      IRestResponse response = client.Execute(request);
      return response.StatusCode == HttpStatusCode.OK;
    }
  }
}
