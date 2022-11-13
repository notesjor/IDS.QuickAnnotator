namespace IDS.QuickAnnotator.Client
{
  partial class AbstractControl
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
      this.SuspendLayout();
      // 
      // AbstractControl
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.Font = new System.Drawing.Font("Roboto", 10.5F);
      this.Name = "AbstractControl";
      this.Size = new System.Drawing.Size(412, 78);
      this.ResumeLayout(false);

    }

        #endregion

        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
    }
}
