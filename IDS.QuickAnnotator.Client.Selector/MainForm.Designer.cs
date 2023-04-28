namespace IDS.QuickAnnotator.Client.Selector
{
  partial class MainForm
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

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.lbl_info = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.commandBarSeparator4 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_abort = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_ok = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_undone = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(842, 73);
      this.radCommandBar1.TabIndex = 0;
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_load,
            this.commandBarSeparator1,
            this.lbl_info,
            this.commandBarSeparator2,
            this.btn_abort,
            this.commandBarSeparator3,
            this.btn_ok,
            this.commandBarSeparator4,
            this.btn_undone});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // lbl_info
      // 
      this.lbl_info.DisplayName = "commandBarLabel1";
      this.lbl_info.Name = "lbl_info";
      this.lbl_info.Text = "commandBarLabel1";
      // 
      // commandBarSeparator2
      // 
      this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // commandBarSeparator3
      // 
      this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
      this.commandBarSeparator3.Name = "commandBarSeparator3";
      this.commandBarSeparator3.VisibleInOverflowMenu = false;
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 73);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(842, 472);
      this.elementHost1.TabIndex = 1;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // commandBarSeparator4
      // 
      this.commandBarSeparator4.DisplayName = "commandBarSeparator4";
      this.commandBarSeparator4.Name = "commandBarSeparator4";
      this.commandBarSeparator4.Text = "";
      this.commandBarSeparator4.VisibleInOverflowMenu = false;
      // 
      // btn_load
      // 
      this.btn_load.DisplayName = "commandBarButton1";
      this.btn_load.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.database_export;
      this.btn_load.Name = "btn_load";
      this.btn_load.Text = "Projekt laden";
      this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
      // 
      // btn_abort
      // 
      this.btn_abort.DisplayName = "commandBarButton2";
      this.btn_abort.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.delete_button_error;
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Text = "Ablehnen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // btn_ok
      // 
      this.btn_ok.DisplayName = "commandBarButton3";
      this.btn_ok.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.ok_button;
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Text = "Akzeptieren";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // btn_undone
      // 
      this.btn_undone.DisplayName = "commandBarButton1";
      this.btn_undone.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.command_undo;
      this.btn_undone.Name = "btn_undone";
      this.btn_undone.Text = "Zurücknehmen";
      this.btn_undone.Click += new System.EventHandler(this.btn_undone_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(842, 545);
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "MainForm";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_load;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarLabel lbl_info;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_abort;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
    private Telerik.WinControls.UI.CommandBarButton btn_ok;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator4;
    private Telerik.WinControls.UI.CommandBarButton btn_undone;
  }
}

