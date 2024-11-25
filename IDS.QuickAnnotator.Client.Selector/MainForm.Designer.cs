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
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_loadCorpus = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.cmb_group = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.lbl_texts = new Telerik.WinControls.UI.CommandBarLabel();
      this.cnt_texts = new Telerik.WinControls.UI.CommandBarTextBox();
      this.info_texts = new Telerik.WinControls.UI.CommandBarLabel();
      this.lbl_tokens = new Telerik.WinControls.UI.CommandBarLabel();
      this.cnt_tokens = new Telerik.WinControls.UI.CommandBarTextBox();
      this.info_tokens = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_abort = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_ok = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
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
      this.radCommandBar1.Size = new System.Drawing.Size(842, 48);
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
            this.btn_loadCorpus,
            this.commandBarSeparator1,
            this.cmb_group,
            this.lbl_texts,
            this.cnt_texts,
            this.info_texts,
            this.lbl_tokens,
            this.cnt_tokens,
            this.info_tokens,
            this.commandBarSeparator2,
            this.btn_abort,
            this.commandBarSeparator3,
            this.btn_ok});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_load
      // 
      this.btn_load.DisplayName = "commandBarButton1";
      this.btn_load.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.database_export;
      this.btn_load.Name = "btn_load";
      this.btn_load.Text = "Projekt laden";
      this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
      // 
      // btn_loadCorpus
      // 
      this.btn_loadCorpus.DisplayName = "commandBarButton1";
      this.btn_loadCorpus.Enabled = false;
      this.btn_loadCorpus.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.folder_open;
      this.btn_loadCorpus.Name = "btn_loadCorpus";
      this.btn_loadCorpus.Text = "Korpus";
      this.btn_loadCorpus.Click += new System.EventHandler(this.btn_loadCorpus_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // cmb_group
      // 
      this.cmb_group.DisplayName = "commandBarDropDownList1";
      this.cmb_group.DropDownAnimationEnabled = true;
      radListDataItem1.Text = "ListItem 1";
      radListDataItem2.Text = "ListItem 2";
      radListDataItem3.Text = "ListItem 3";
      this.cmb_group.Items.Add(radListDataItem1);
      this.cmb_group.Items.Add(radListDataItem2);
      this.cmb_group.Items.Add(radListDataItem3);
      this.cmb_group.MinSize = new System.Drawing.Size(200, 48);
      this.cmb_group.Name = "cmb_group";
      this.cmb_group.Text = "";
      this.cmb_group.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.cmb_group.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmb_group_SelectedIndexChanged);
      // 
      // lbl_texts
      // 
      this.lbl_texts.DisplayName = "commandBarLabel1";
      this.lbl_texts.Name = "lbl_texts";
      this.lbl_texts.Text = "Texte:";
      // 
      // cnt_texts
      // 
      this.cnt_texts.DisplayName = "commandBarTextBox1";
      this.cnt_texts.Name = "cnt_texts";
      this.cnt_texts.Text = "0";
      ((Telerik.WinControls.UI.RadTextBoxElement)(this.cnt_texts.GetChildAt(0))).Text = "0";
      // 
      // info_texts
      // 
      this.info_texts.DisplayName = "commandBarLabel1";
      this.info_texts.Name = "info_texts";
      this.info_texts.Text = "";
      // 
      // lbl_tokens
      // 
      this.lbl_tokens.DisplayName = "commandBarLabel1";
      this.lbl_tokens.Name = "lbl_tokens";
      this.lbl_tokens.Text = "Token:";
      // 
      // cnt_tokens
      // 
      this.cnt_tokens.DisplayName = "commandBarTextBox2";
      this.cnt_tokens.Name = "cnt_tokens";
      this.cnt_tokens.Text = "0";
      ((Telerik.WinControls.UI.RadTextBoxElement)(this.cnt_tokens.GetChildAt(0))).Text = "0";
      // 
      // info_tokens
      // 
      this.info_tokens.DisplayName = "commandBarLabel2";
      this.info_tokens.Name = "info_tokens";
      this.info_tokens.Text = "";
      // 
      // commandBarSeparator2
      // 
      this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_abort
      // 
      this.btn_abort.DisplayName = "commandBarButton2";
      this.btn_abort.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.delete_button_error;
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Text = "Ablehnen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // commandBarSeparator3
      // 
      this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
      this.commandBarSeparator3.Name = "commandBarSeparator3";
      this.commandBarSeparator3.VisibleInOverflowMenu = false;
      // 
      // btn_ok
      // 
      this.btn_ok.DisplayName = "commandBarButton3";
      this.btn_ok.Image = global::IDS.QuickAnnotator.Client.Selector.Properties.Resources.ok_button;
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Text = "Akzeptieren";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 48);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(842, 497);
      this.elementHost1.TabIndex = 1;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(842, 545);
      this.Controls.Add(this.elementHost1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "MainForm";
      this.Text = "QuickSelector";
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
    private Telerik.WinControls.UI.CommandBarLabel lbl_texts;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_abort;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
    private Telerik.WinControls.UI.CommandBarButton btn_ok;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.CommandBarTextBox cnt_texts;
    private Telerik.WinControls.UI.CommandBarLabel lbl_tokens;
    private Telerik.WinControls.UI.CommandBarTextBox cnt_tokens;
    private Telerik.WinControls.UI.CommandBarDropDownList cmb_group;
    private Telerik.WinControls.UI.CommandBarLabel info_texts;
    private Telerik.WinControls.UI.CommandBarLabel info_tokens;
    private Telerik.WinControls.UI.CommandBarButton btn_loadCorpus;
  }
}

