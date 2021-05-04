using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IDS.QuickAnnotator.Client
{
  /// <summary>
  /// Interaktionslogik für Token.xaml
  /// </summary>
  public partial class Token : UserControl
  {
    public Token()
    {
      InitializeComponent();
    }

    public string TokenText
    {
      get
      {
        return TokenStr.Text;
      }
      set
      {
        TokenStr.Text = value;
      }
    }

    public Color HighlightTop
    {
      set => LineColorTop.Fill = new SolidColorBrush(value);
    }

    public Color HighlightBottom
    {
      set => LineColorBottom.Fill = new SolidColorBrush(value);
    }

    public int TokenIndex { get; set; }

    private void RootPanel_MouseEnter(object sender, MouseEventArgs e)
    {
      TokenStr.Background = new SolidColorBrush(Colors.Black);
      TokenStr.Foreground = new SolidColorBrush(Colors.White);
    }

    private void RootPanel_MouseLeave(object sender, MouseEventArgs e)
    {
      TokenStr.Background = new SolidColorBrush(Colors.White);
      TokenStr.Foreground = new SolidColorBrush(Colors.Black);
    }

    public event HighlightEvent RightClick;
    public event HighlightEvent LeftClick;

    private void RootPanel_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      RightClick?.Invoke(TokenIndex);
    }

    private void RootPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      LeftClick?.Invoke(TokenIndex);
    }
  }
}
