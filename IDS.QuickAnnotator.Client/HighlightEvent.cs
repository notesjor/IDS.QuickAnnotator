using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDS.QuickAnnotator.Client
{
  public delegate bool HighlightEvent(Token wpf, int sentence, int token);

  public delegate void KeyPressedEvent(Key key);
}
