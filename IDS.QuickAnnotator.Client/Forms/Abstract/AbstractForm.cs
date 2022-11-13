using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IDS.QuickAnnotator.Client
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
