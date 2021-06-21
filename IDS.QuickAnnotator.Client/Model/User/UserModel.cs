using IDS.QuickAnnotator.API.Model.Request;

namespace IDS.QuickAnnotator.Client.Model.User
{
  public class UserModel
  {
    public UserModel()
    {
      LoadProfile();
    }

    private UserProfile _profile;
    public UserProfile Profile
    {
      get
      {
        if (_profile != null)
          return _profile;
        LoadProfile();
        return _profile;
      }
    }

    public void LoadProfile()
    {
      _profile = QuickAnnotatorApi.GetProfile();
    }

    public bool IsDocumentDone(string documentId)
    {
      return _profile.DoneDocumentIds.Contains(documentId);
    }
  }
}
