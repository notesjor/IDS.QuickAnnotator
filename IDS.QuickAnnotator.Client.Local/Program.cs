using IDS.QuickAnnotator.Client.Local.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS.QuickAnnotator.Client.Local
{
  internal static class Program
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

        var ofd = new OpenFileDialog();
        ofd.Filter = "QuickAnnotator-Dateien (*.qaf)|*.qaf";
        ofd.Title = "QuickAnnotator-Datei auswählen";
        ofd.FilterIndex = 0;
        ofd.Multiselect = false;
        if (ofd.ShowDialog() != DialogResult.OK)
          return;

        var form = new DashboardFormLocalAcceptReject(ofd.FileName);
        form.ShowDialog();
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
