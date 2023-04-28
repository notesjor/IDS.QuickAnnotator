using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS.QuickAnnotator.Client.Selector
{
  public class QafModel
  {
    private string _path;
    private List<KeyValuePair<List<string>, int>> _qaf;

    public QafModel() { }

    public void Load()
    {
      var ofd = new OpenFileDialog
      {
        CheckFileExists = true,
        CheckPathExists = true,
        Filter = "QAF-File (*.qaf)|*.qaf"
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _path = ofd.FileName;
      _qaf = new List<KeyValuePair<List<string>, int>>();

      var lines = File.ReadAllLines(_path, Encoding.UTF8);
      foreach (var line in lines)
      {
        var split = line.Split('\t').ToList();
        if (split.Count < 2)
          continue;
        var count = int.Parse(split.Last());
        split.RemoveAt(split.Count - 1);
        _qaf.Add(new KeyValuePair<List<string>, int>(split, count));
      }
    }

    public void Save() 
      => File.WriteAllLines(_path, _qaf.Select(x => string.Join("\t", x.Key) + "\t" + x.Value), Encoding.UTF8);

    internal void Accept()
    {
      throw new NotImplementedException();
    }

    internal void Reject()
    {
      throw new NotImplementedException();
    }

    internal void Undone()
    {
      throw new NotImplementedException();
    }

    internal HashSet<string> GetHighlight()
    {
      throw new NotImplementedException();
    }

    internal string[] GetTokens()
    {
      throw new NotImplementedException();
    }
  }
}
