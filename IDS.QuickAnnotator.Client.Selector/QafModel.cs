using CorpusExplorer.Sdk.Ecosystem;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Svg.Pathing;
using Telerik.WinControls.UI;

namespace IDS.QuickAnnotator.Client.Selector
{
  public class QafModel
  {
    private string _path;
    private List<KeyValuePair<List<string>, int>> _qaf;
    private string[] _sigle;

    public int TodosTexts { get; internal set; }
    public int TodosTokens { get; internal set; }
    public int DoneTexts { get; internal set; }
    public int DoneTokens { get; internal set; }

    public IEnumerable<RadListDataItem> Groups
      => _qaf.Select(x => x.Key.First()).Select(x => new RadListDataItem(x));

    public QafModel()
    {
      Project = CorpusExplorerEcosystem.InitializeMinimal();
    }

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

      if (!File.Exists(Path.Combine(Path.GetDirectoryName(_path), "qaf.sigle")))
      {
        MessageBox.Show("Im Verzeichnis der QAF-Datei muss sich eine Datei 'qaf.sigle' mit Siglen befinden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception("qaf.sigle");
      }
      _sigle = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(_path), "qaf.sigle"), Encoding.UTF8).Where(x=>!string.IsNullOrWhiteSpace(x)).ToArray();

      if (Directory.GetFiles(Path.GetDirectoryName(_path), "*.qac", SearchOption.TopDirectoryOnly).Length == 0)
      {
        MessageBox.Show("Im Verzeichnis der QAF-Datei müssen sich ein oder mehrere QAC-Corpora befinden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        throw new Exception("qac-files");
      }
      
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

      // init outputDirectory
      var outputDirectory = Path.Combine(Path.GetDirectoryName(_path), "output");
      if (!Directory.Exists(outputDirectory))
        Directory.CreateDirectory(outputDirectory);

      foreach (var t in _qaf)
      {
        var token = t.Key.First();
        var dir = Path.Combine(outputDirectory, token);
        if (!Directory.Exists(dir))
          Directory.CreateDirectory(dir);
        var okDir = Path.Combine(dir, "ok");
        if (!Directory.Exists(okDir))
          Directory.CreateDirectory(okDir);
        var rejectDir = Path.Combine(dir, "reject");
        if (!Directory.Exists(rejectDir))
          Directory.CreateDirectory(rejectDir);

        var counter = Path.Combine(dir, "counter.dat");
        if (!File.Exists(counter))
          File.WriteAllText(counter, "0");
      }
    }

    public void Save()
      => File.WriteAllLines(_path, _qaf.Select(x => string.Join("\t", x.Key) + "\t" + x.Value), Encoding.UTF8);

    internal void Accept()
    {
      MoveTo("ok");
      NextSample();
    }

    internal void Reject()
    {
      MoveTo("reject");
      NextSample();
    }

    public string CurrentToken { get; set; }
    public string CurrentSigle { get; set; }
    public string CurrentYear { get; set; }

    public Project Project { get; set; }    
    public Selection CurrentSelection { get; set; }

    private Regex _yearsRegex = new Regex(@"^[0-9]*$");

    private string[] GetYears()
    {
      var files = Directory.GetFiles(Path.GetDirectoryName(_path), "*.qac", SearchOption.TopDirectoryOnly);
      var years = new HashSet<string>();

      foreach (var file in files)
      {
        var name = Path.GetFileNameWithoutExtension(file);
        if (name.StartsWith(CurrentSigle))
        {
          name = name.Replace(".out", "").Replace(CurrentSigle, "");
          if(_yearsRegex.IsMatch(name))
            years.Add(name);
        }
      }

      return years.ToArray();
    }

    private void MoveTo(string choice)
    {
      
    }

    private void NextSample()
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
