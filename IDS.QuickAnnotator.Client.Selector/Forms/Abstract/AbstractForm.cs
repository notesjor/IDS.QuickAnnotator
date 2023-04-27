using Telerik.WinControls;

namespace IDS.QuickAnnotator.Client.Forms.Abstract
{
  public partial class AbstractForm : Telerik.WinControls.UI.RadForm
  {
    public AbstractForm()
    {
      ThemeResolutionService.ApplicationThemeName = "Material";
      InitializeComponent();
    }
  }
}
