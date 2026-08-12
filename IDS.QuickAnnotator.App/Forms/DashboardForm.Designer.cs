namespace IDS.QuickAnnotator.Client.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      this.commands = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarButton4 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_screenFix = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.panel_controls = new Telerik.WinControls.UI.RadScrollablePanel();
      this.radButton1 = new Telerik.WinControls.UI.RadButton();
      this.btn_submit = new Telerik.WinControls.UI.RadButton();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.commands)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panel_controls)).BeginInit();
      this.panel_controls.PanelContainer.SuspendLayout();
      this.panel_controls.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_submit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // commands
      // 
      this.commands.Dock = System.Windows.Forms.DockStyle.Top;
      this.commands.Location = new System.Drawing.Point(0, 0);
      this.commands.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
      this.commands.Name = "commands";
      this.commands.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.commands.Size = new System.Drawing.Size(1209, 76);
      this.commands.TabIndex = 0;
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(76, 76);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarButton1,
            this.commandBarSeparator1,
            this.commandBarButton2,
            this.commandBarLabel1,
            this.commandBarButton3,
            this.commandBarSeparator2,
            this.commandBarButton4,
            this.commandBarSeparator3,
            this.btn_screenFix});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // 
      // 
      this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      this.commandBarStripElement1.OverflowMenuMaxSize = new System.Drawing.Size(825, 0);
      this.commandBarStripElement1.OverflowMenuMinSize = new System.Drawing.Size(152, 76);
      ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.DisplayName = "commandBarButton1";
      this.commandBarButton1.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.folder_open_doc_60px;
      this.commandBarButton1.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Text = "Annotationsrunde laden";
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarButton2
      // 
      this.commandBarButton2.DisplayName = "commandBarButton2";
      this.commandBarButton2.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.symbol_arrow_left_60px;
      this.commandBarButton2.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.commandBarButton2.Name = "commandBarButton2";
      this.commandBarButton2.Text = "commandBarButton2";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = "< Bitte zunächst Annotationsrunde laden";
      // 
      // commandBarButton3
      // 
      this.commandBarButton3.DisplayName = "commandBarButton3";
      this.commandBarButton3.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.symbol_arrow_right_60px;
      this.commandBarButton3.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.commandBarButton3.Name = "commandBarButton3";
      this.commandBarButton3.Text = "commandBarButton3";
      // 
      // commandBarSeparator2
      // 
      this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // commandBarButton4
      // 
      this.commandBarButton4.DisplayName = "commandBarButton4";
      this.commandBarButton4.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.save_60px;
      this.commandBarButton4.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.commandBarButton4.Name = "commandBarButton4";
      this.commandBarButton4.Text = "commandBarButton4";
      // 
      // commandBarSeparator3
      // 
      this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
      this.commandBarSeparator3.Name = "commandBarSeparator3";
      this.commandBarSeparator3.VisibleInOverflowMenu = false;
      // 
      // btn_screenFix
      // 
      this.btn_screenFix.DisplayName = "commandBarButton1";
      this.btn_screenFix.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.computer_3_add;
      this.btn_screenFix.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btn_screenFix.Name = "btn_screenFix";
      this.btn_screenFix.StretchVertically = false;
      this.btn_screenFix.Text = "Screen-Fix";
      this.btn_screenFix.Click += new System.EventHandler(this.btn_screenFix_Click);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 0);
      this.elementHost1.Margin = new System.Windows.Forms.Padding(0);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(758, 671);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 76);
      this.radSplitContainer1.Name = "radSplitContainer1";
      this.radSplitContainer1.Size = new System.Drawing.Size(1209, 671);
      this.radSplitContainer1.SplitterWidth = 25;
      this.radSplitContainer1.TabIndex = 1;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      this.splitPanel1.Size = new System.Drawing.Size(758, 671);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1404024F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(132, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.panel_controls);
      this.splitPanel2.Location = new System.Drawing.Point(783, 0);
      this.splitPanel2.Name = "splitPanel2";
      this.splitPanel2.Size = new System.Drawing.Size(426, 671);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1404023F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(-132, 0);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // panel_controls
      // 
      this.panel_controls.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel_controls.HorizontalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
      this.panel_controls.Location = new System.Drawing.Point(0, 0);
      this.panel_controls.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
      this.panel_controls.Name = "panel_controls";
      this.panel_controls.Padding = new System.Windows.Forms.Padding(0);
      // 
      // panel_controls.PanelContainer
      // 
      this.panel_controls.PanelContainer.Controls.Add(this.radButton1);
      this.panel_controls.PanelContainer.Controls.Add(this.btn_submit);
      this.panel_controls.PanelContainer.Location = new System.Drawing.Point(0, 0);
      this.panel_controls.PanelContainer.Margin = new System.Windows.Forms.Padding(60, 60, 60, 60);
      this.panel_controls.PanelContainer.Size = new System.Drawing.Size(405, 671);
      this.panel_controls.Size = new System.Drawing.Size(426, 671);
      this.panel_controls.TabIndex = 7;
      this.panel_controls.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      // 
      // radButton1
      // 
      this.radButton1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radButton1.Location = new System.Drawing.Point(0, 56);
      this.radButton1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
      this.radButton1.Name = "radButton1";
      this.radButton1.Size = new System.Drawing.Size(405, 56);
      this.radButton1.TabIndex = 24;
      this.radButton1.Text = "Doppelform";
      this.toolTip1.SetToolTip(this.radButton1, "Annotation anwenden");
      this.radButton1.Click += new System.EventHandler(this.btn_submit_doppelform_altern_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Margin = new System.Windows.Forms.Padding(8);
      // 
      // btn_submit
      // 
      this.btn_submit.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_submit.Location = new System.Drawing.Point(0, 0);
      this.btn_submit.Margin = new System.Windows.Forms.Padding(24, 10, 10, 10);
      this.btn_submit.Name = "btn_submit";
      this.btn_submit.Size = new System.Drawing.Size(405, 56);
      this.btn_submit.TabIndex = 7;
      this.btn_submit.Text = "Annotieren";
      this.toolTip1.SetToolTip(this.btn_submit, "Annotation anwenden");
      this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_submit.GetChildAt(0))).Margin = new System.Windows.Forms.Padding(8);
      // 
      // DashboardForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(1209, 747);
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.commands);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "DashboardForm";
      this.Text = "QuickAnnotator";
      ((System.ComponentModel.ISupportInitialize)(this.commands)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.panel_controls.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panel_controls)).EndInit();
      this.panel_controls.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_submit)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar commands;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private System.Windows.Forms.ToolTip toolTip1;
    private Telerik.WinControls.UI.RadButton btn_submit;
        private Telerik.WinControls.UI.RadScrollablePanel panel_controls;
        private Telerik.WinControls.UI.CommandBarButton btn_screenFix;
    private Telerik.WinControls.UI.RadButton radButton1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton3;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton4;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
  }
}
