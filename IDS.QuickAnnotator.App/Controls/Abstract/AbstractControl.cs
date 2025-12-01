using System.Windows.Forms;
using Telerik.WinControls;

namespace IDS.QuickAnnotator.Client.Controls.Abstract
{
  public partial class AbstractControl : UserControl
  {
    public AbstractControl()
    {
      ThemeResolutionService.ApplicationThemeName = "Material";
      InitializeComponent();
    }
  }
}
