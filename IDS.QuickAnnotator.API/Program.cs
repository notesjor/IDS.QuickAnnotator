using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    private static string _admins;
    private static string _layers;
    private static Dictionary<string, string> _userDict;

    static void Main(string[] args)
    {
      _app = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      _log = EnsureDirectory("error");
      _docs = EnsureDirectory("docs");
      _history = EnsureDirectory("history");
      _users = EnsureDirectory("users");
      _admins = EnsureDirectory("admins");
      LoadUserDict();

      _layers = File.ReadAllText(Path.Combine(_app, "layers.json"));

      Console.Write("Service-Port: 4545...");
      var server = new Server("*", 4545, (arg) => arg.Response.Send(HttpStatusCode.NoContent));
      server.AddEndpoint(HttpVerb.GET, "/docs", GetDocuments);
      server.AddEndpoint(HttpVerb.GET, "/layer", GetLayer);
      server.AddEndpoint(HttpVerb.GET, "/doc", GetDocument);
      server.AddEndpoint(HttpVerb.VIEW, "/doc", GetDocumentHistory);
      server.AddEndpoint(HttpVerb.POST, "/doc", SetDocument);
      server.AddEndpoint(HttpVerb.GET, "/lock", GetLock);
      server.AddEndpoint(HttpVerb.POST, "/lock", ReleaseLock);
      Console.WriteLine("ok!");

      while (true)
        Thread.Sleep(25000);
    }

    private static void LoadUserDict()
    {
      _userDict = new Dictionary<string, string>();
      foreach (var file in Directory.GetFiles(_users, "*.user"))
      {
        var guid = Path.GetFileNameWithoutExtension(file);
        var name = File.ReadAllText(file);
        _userDict.Add(guid, name);
      }
      Console.WriteLine($"{_userDict.Count} users loaded!");
    }

    private static Task ReleaseLock(HttpContext arg)
    {
      lock (_getLock)
        try
        {
          var req = arg.PostData<RequestLock>();
          if (!IsAuthUser(req))
            return arg.Response.Send(HttpStatusCode.Unauthorized);

          var file = Path.Combine(_docs, req.DocumentId + ".json");
          if (!File.Exists(file))
            return arg.Response.Send(HttpStatusCode.NotFound);

          var fileLock = Path.Combine(_docs, req.DocumentId + ".lock");
          if (!File.Exists(fileLock))
            return arg.Response.Send(HttpStatusCode.NotFound);

          var txt = File.ReadAllText(fileLock);
          if (txt != req.AuthToken)
            return arg.Response.Send(HttpStatusCode.Locked);

          File.Delete(fileLock);
          return arg.Response.Send(HttpStatusCode.OK);

        }
        catch (Exception ex)
        {
          Log(ex);
          return arg.Response.Send(HttpStatusCode.InternalServerError);
        }
    }

    private static object _getLock = new object();
    private static Task GetLock(HttpContext arg)
    {
      lock (_getLock)
        try
        {
          var req = arg.PostData<RequestLock>();
          return arg.Response.Send(IsAuthUser(req) ? InternalFileLock(req.DocumentId, req.AuthToken) : HttpStatusCode.Unauthorized);
        }
        catch (Exception ex)
        {
          Log(ex);
          return arg.Response.Send(HttpStatusCode.InternalServerError);
        }
    }

    private static HttpStatusCode InternalFileLock(string documentId, string authToken)
    {
      var file = Path.Combine(_docs, documentId + ".json");
      if (!File.Exists(file))
        return HttpStatusCode.NotFound;

      var fileLock = Path.Combine(_docs, documentId + ".lock");
      if (File.Exists(fileLock))
      {
        var txt = File.ReadAllText(fileLock);
        return txt == authToken ? HttpStatusCode.OK : HttpStatusCode.Locked;
      }

      File.WriteAllText(fileLock, authToken);
      return HttpStatusCode.OK;
    }

    private static Task GetDocument(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<RequestLock>();
        if (!IsAuthUser(req))
          return arg.Response.Send(HttpStatusCode.Unauthorized);

        var filePath = Path.Combine(_docs, req.DocumentId + ".json");
        if (!File.Exists(filePath))
          return arg.Response.Send(HttpStatusCode.NotFound);

        return arg.Response.Send(File.ReadAllText(filePath, Encoding.UTF8));
      }
      catch (Exception ex)
      {
        Log(ex);
        return arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static Task GetDocumentHistory(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<RequestLock>();
        if (!IsAuthUser(req))
          return arg.Response.Send(HttpStatusCode.Unauthorized);

        var dir = Path.Combine(_history, req.DocumentId);
        if (!Directory.Exists(dir))
          return arg.Response.Send(HttpStatusCode.NotFound);

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

        return arg.Response.Send(res.ToArray());
      }
      catch (Exception ex)
      {
        Log(ex);
        return arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static Task SetDocument(HttpContext arg)
    {
      try
      {
        var req = arg.PostData<RequestDocumentSet>();
        if (!IsAuthUser(req))
          return arg.Response.Send(HttpStatusCode.Unauthorized);

        var validLock = InternalFileLock(req.Change.DocumentId, req.AuthToken);
        if (validLock != HttpStatusCode.OK)
          return arg.Response.Send(validLock);

        var dt = DateTime.Now;
        var dir = Path.Combine(_history, req.Change.DocumentId);
        if (!Directory.Exists(dir))
          Directory.CreateDirectory(dir);

        var path = Path.Combine(dir, GetTimestamp(dt));

        var change = req.Change;
        change.Timestamp = dt;
        change.UserName = GetUserName(req.AuthToken);
        File.WriteAllText(path, JsonConvert.SerializeObject(change));

        return arg.Response.Send(HttpStatusCode.OK);
      }
      catch (Exception ex)
      {
        Log(ex);
        return arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static string GetUserName(string authToken)
    {
      return _userDict.ContainsKey(authToken) ? _userDict[authToken] : string.Empty;
    }

    private static Task GetLayer(HttpContext arg)
    {
      try
      {
        return arg.Response.Send(_layers);
      }
      catch (Exception ex)
      {
        Log(ex);
        return arg.Response.Send(HttpStatusCode.InternalServerError);
      }
    }

    private static Task GetDocuments(HttpContext arg)
    {
      try
      {
        return arg.Response.Send(Directory.GetFiles(_docs, "*.json").Select(x => Path.GetFileNameWithoutExtension(x)).ToArray());
      }
      catch (Exception ex)
      {
        Log(ex);
        return arg.Response.Send(HttpStatusCode.InternalServerError);
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

    private static bool IsAuthAdmin(AbstractAuthRequest req)
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
  }
}
