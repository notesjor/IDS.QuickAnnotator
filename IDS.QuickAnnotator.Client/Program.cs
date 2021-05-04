using IDS.QuickAnnotator.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS.QuickAnnotator.Client
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      SetProcessDpiAwareness(_Process_DPI_Awareness.Process_System_DPI_Aware);

      var auth = new AuthModel();
      if (auth.Signin())
      {
        var form = new DashboardForm();
        form.ShowDialog();
      }
      else
      {
        var signin = new SigninForm(GlobalConfiguration.AuthToken);
        signin.ShowDialog();
      }
    }

    [DllImport("shcore.dll")]
    static extern int SetProcessDpiAwareness(_Process_DPI_Awareness value);

    enum _Process_DPI_Awareness
    {
      Process_DPI_Unaware = 0,
      Process_System_DPI_Aware = 1,
      Process_Per_Monitor_DPI_Aware = 2
    }
  }
}
