using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using IDS.QuickAnnotator.API.Model.Request;

namespace IDS.QuickAnnotator.Client
{
  /// <summary>
  /// Interaktionslogik für Editor.xaml
  /// </summary>
  public partial class Editor : UserControl
  {
    public Editor()
    {
      InitializeComponent();
    }

    public HashSet<string> Highlight { get; set; } = new HashSet<string>
    {
      "Erzieher",
      "Erziehers",
      "Erziehern",
      "Erzieherin",
      "Erzieherinnen",
      "Bürger",
      "Bürgers",
      "Bürgern",
      "Bürgerin",
      "Bürgerinnen",
      "Manager",
      "Managers",
      "Managern",
      "Managerin",
      "Managerinnen"
    };

    public string[] Tokens
    {
      set
      {
        if (value == null)
          return;

        EditorContent.Children.Clear();
        for (var i = 0; i < value.Length; i++)
        {
          var token = new Token { TokenText = value[i], TokenIndex = i };
          token.LeftClick += LeftClick;
          token.RightClick += RightClick;
          token.HighlightToken = Highlight.Contains(value[i]);

          EditorContent.Children.Add(token);
        }
      }
    }

    public bool[] Annotations
    {
      set
      {
        if (value == null)
          return;

        for (var i = 0; i < value.Length; i++)
        {
          ((Token)EditorContent.Children[i]).HighlightBottom = value[i] ? Colors.Black : Colors.White;
        }
      }
    }

    public event HighlightEvent RightClick;
    public event HighlightEvent LeftClick;

    public void TemporaryAnnotation(int from = -1, int to = -1)
    {
      if (from == -1 && to == -1) // Lösche alles
      {
        for (var i = 0; i < EditorContent.Children.Count; i++)
          ((Token)EditorContent.Children[i]).HighlightTop = Colors.White;
      }
      else if (from > -1 && to == -1) // Markiere Start
      {
        ((Token)EditorContent.Children[from]).HighlightTop = Colors.Green;
      }
      else if (from > -1 && to > -1)
      {
        ((Token)EditorContent.Children[from]).HighlightTop = Colors.Green;
        ((Token)EditorContent.Children[to]).HighlightTop = Colors.Red;
        for (var i = from + 1; i < to; i++)
          ((Token)EditorContent.Children[i]).HighlightTop = Colors.Yellow;
      }
    }
  }
}
