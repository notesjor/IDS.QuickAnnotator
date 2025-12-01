using IDS.QuickAnnotator.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDS.QuickAnnotator.Client.Forms;
using IDS.QuickAnnotator.Client.Model.Steps;

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
      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        SetProcessDpiAwareness(_Process_DPI_Awareness.Process_Per_Monitor_DPI_Aware
        );

        var auth = new AuthModel();
        if (auth.Signin())
        {
          StepModel.Init();
          var form = new DashboardForm();
          form.ShowDialog();
        }
        else
        {
          var signin = new SigninForm(GlobalConfiguration.AuthToken);
          signin.ShowDialog();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", "Anwendungsfehler (Screenshot per E-Mail an: ruediger@ids-mannheim.de)", MessageBoxButtons.OK);
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
