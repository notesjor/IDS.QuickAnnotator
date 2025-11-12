using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.API.Model.Request.Abstract;
using Newtonsoft.Json;
using Tfres;

namespace IDS.QuickAnnotator.API
{
  class Program
  {
    private static string _app;
    private static string _log;
    private static string _docs;
    private static string _history;
    private static string _users;
    private static string _layers;

    static void Main(string[] args)
    {
      _app = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      _log = EnsureDirectory("error");
      _docs = EnsureDirectory("docs");
      EnsureDirectory("docs/all");
      _history = EnsureDirectory("history");
      _users = EnsureDirectory("users");

      _layers = File.ReadAllText(Path.Combine(_app, "layers.json"));

      Console.Write("Service-Port: 4545...");
      var server = new Server("*", 45459, (arg) => arg.Response.Send(HttpStatusCode.NoContent));
      server.AddEndpoint(HttpMethod.Post, "/getDocuments", GetDocuments);
      server.AddEndpoint(HttpMethod.Post, "/getLayer", GetLayer);
      server.AddEndpoint(HttpMethod.Post, "/getDocument", GetDocument);
      server.AddEndpoint(HttpMethod.Post, "/getDocumentHistory", GetDocumentHistory);
      server.AddEndpoint(HttpMethod.Post, "/setDocument", SetDocument);
      server.AddEndpoint(HttpMethod.Post, "/setDocumentCompletion", SetDocumentCompletion);
      server.AddEndpoint(HttpMethod.Post, "/signin", Signin);
      server.AddEndpoint(HttpMethod.Post, "/getProfile", MyProfileInfo);
      Console.WriteLine("ok!");

      while (true)
        Thread.Sleep(25000);
    }

    private static void SetDocumentCompletion(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<RequestDocumentGet>();
        if (!IsAuthUser(req))
        {
          arg.Response.Send(HttpStatusCode.Unauthorized);
          return;
        }

        var user = GetUser(req.AuthToken);
        user.DoneDocumentIds.Add(req.DocumentId);
        SetUser(req.AuthToken, user);

        arg.Response.Send(HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void MyProfileInfo(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<AbstractAuthRequest>();
        if (!IsAuthUser(req))
          arg.Response.Send(HttpStatusCode.Unauthorized);
        else
          arg.Response.Send(GetUser(req.AuthToken));
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void GetDocument(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<RequestDocumentGet>();
        if (!IsAuthUser(req))
        {
          arg.Response.Send(HttpStatusCode.Unauthorized);
          return;
        }

        var docs = Directory.GetFiles(_docs, req.DocumentId + ".json", SearchOption.AllDirectories);
        if (docs.Length < 1)
        {
          arg.Response.Send(HttpStatusCode.NotFound);
          return;
        }

        var filePath = docs[0];
        var user = GetUser(req.AuthToken);
        user.LastDocumentId = req.DocumentId;
        SetUser(req.AuthToken, user);

        arg.Response.Send(File.ReadAllText(filePath, Encoding.UTF8));
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void GetDocumentHistory(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<RequestDocumentGet>();
        if (!IsAuthUser(req))
        {
          arg.Response.Send(HttpStatusCode.Unauthorized);
          return;
        }

        var dir = Path.Combine(_history, req.DocumentId);
        if (!Directory.Exists(dir))
        {
          arg.Response.Send(HttpStatusCode.NotFound);
          return;
        }

        var res = new List<DocumentChange>();
        foreach (var file in Directory.GetFiles(dir, "*.json"))
        {
          try
          {
            res.Add(JsonConvert.DeserializeObject<DocumentChange>(File.ReadAllText(file, Encoding.UTF8)));
          }
          catch (Exception ex)
          {
            Log(ex);
          }
        }

        arg.Response.Send(res.ToArray());
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void SetDocument(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<RequestDocumentSet>();
        if (!IsAuthUser(req))
        {
          arg.Response.Send(HttpStatusCode.Unauthorized);
          return;
        }

        var dt = DateTime.Now;
        var dir = Path.Combine(_history, req.Change.DocumentId);
        if (!Directory.Exists(dir))
          Directory.CreateDirectory(dir);

        var path = Path.Combine(dir, GetTimestamp(dt));

        var change = req.Change;
        change.Timestamp = dt;
        change.UserName = GetUser(req.AuthToken).UserName;
        File.WriteAllText(path, JsonConvert.SerializeObject(change));

        arg.Response.Send(HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void GetLayer(HttpContext arg)
    {
      try
      {
        arg.Response.Send(_layers);
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void GetDocuments(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<AbstractAuthRequest>();

        var res = new List<string>();
        res.AddRange(Directory.GetFiles(Path.Combine(_docs, "all"), "*.json").Select(Path.GetFileNameWithoutExtension));
        try
        {
          res.AddRange(Directory.GetFiles(Path.Combine(_docs, req.AuthToken), "*.json").Select(Path.GetFileNameWithoutExtension));
        }
        catch
        {
          // ignore
        }
        res.Sort();

        arg.Response.Send(res.ToArray());
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void Signin(HttpContext arg)
    {
      try
      {
        arg.Response.Send(IsAuthUser(arg.PostData<AbstractAuthRequest>()));
      }
      catch (Exception ex)
      {
        Log(ex);
        arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static void Log(Exception ex)
    {
      try
      {
        File.WriteAllText(Path.Combine(_log, GetTimestamp()), JsonConvert.SerializeObject(ex));
      }
      catch
      {
        // ignore
      }
    }

    private static bool IsAuthUser(AbstractAuthRequest req)
    {
      return File.Exists(Path.Combine(_users, req.AuthToken + ".user"));
    }

    private static string GetTimestamp(DateTime? dt = null)
    {
      return (dt ?? DateTime.Now).ToString("yyyy-MM-dd_hh-mm-ss") + ".json";
    }

    private static string EnsureDirectory(string name)
    {
      var res = Path.Combine(_app, name);
      if (!Directory.Exists(res))
        Directory.CreateDirectory(res);
      return res;
    }

    private static UserProfile GetUser(string authToken)
    {
      try
      {
        return JsonConvert.DeserializeObject<UserProfile>(File.ReadAllText(Path.Combine(_users, authToken + ".user"), Encoding.UTF8));
      }
      catch (Exception ex)
      {
        Log(ex);
        return null;
      }
    }

    private static void SetUser(string authToken, UserProfile profile)
    {
      try
      {
        var path = Path.Combine(_users, authToken + ".user");
        if (!File.Exists(path))
          throw new FileNotFoundException(path);
        File.WriteAllText(path, JsonConvert.SerializeObject(profile), Encoding.UTF8);
      }
      catch (Exception ex)
      {
        Log(ex);
      }
    }
  }
}
