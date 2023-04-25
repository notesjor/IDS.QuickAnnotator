namespace IDS.QuickAnnotator.Client.Local.Forms
{
    partial class DashboardFormLocalAcceptReject
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
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.btn_loadProject = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.btn_accept = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_reject = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_screenFix = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.panel_controls = new Telerik.WinControls.UI.RadScrollablePanel();
      this.btn_submit_doppelform = new Telerik.WinControls.UI.RadButton();
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
      ((System.ComponentModel.ISupportInitialize)(this.btn_submit_doppelform)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_submit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // commands
      // 
      this.commands.Dock = System.Windows.Forms.DockStyle.Top;
      this.commands.Location = new System.Drawing.Point(0, 0);
      this.commands.Margin = new System.Windows.Forms.Padding(6);
      this.commands.Name = "commands";
      this.commands.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.commands.Size = new System.Drawing.Size(1209, 74);
      this.commands.TabIndex = 0;
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(49, 49);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel1,
            this.btn_loadProject,
            this.commandBarLabel2,
            this.btn_accept,
            this.btn_reject,
            this.commandBarSeparator1,
            this.btn_screenFix});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // 
      // 
      this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      this.commandBarStripElement1.OverflowMenuMaxSize = new System.Drawing.Size(528, 0);
      this.commandBarStripElement1.OverflowMenuMinSize = new System.Drawing.Size(98, 49);
      ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = "Projekt:";
      // 
      // btn_loadProject
      // 
      this.btn_loadProject.DisplayName = "commandBarButton1";
      this.btn_loadProject.Image = global::IDS.QuickAnnotator.Client.Local.Properties.Resources.database_export;
      this.btn_loadProject.Name = "btn_loadProject";
      this.btn_loadProject.Text = "Projekt laden";
      this.btn_loadProject.Click += new System.EventHandler(this.btn_loadProject_Click);
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = "Aktion:";
      // 
      // btn_accept
      // 
      this.btn_accept.DisplayName = "commandBarButton2";
      this.btn_accept.DrawText = true;
      this.btn_accept.Image = global::IDS.QuickAnnotator.Client.Local.Properties.Resources.ok_button;
      this.btn_accept.Name = "btn_accept";
      this.btn_accept.Text = "Akzeptieren";
      this.btn_accept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
      // 
      // btn_reject
      // 
      this.btn_reject.DisplayName = "commandBarButton3";
      this.btn_reject.DrawText = true;
      this.btn_reject.Image = global::IDS.QuickAnnotator.Client.Local.Properties.Resources.delete_button_error;
      this.btn_reject.Name = "btn_reject";
      this.btn_reject.Text = "Ablehnen";
      this.btn_reject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_reject.Click += new System.EventHandler(this.btn_reject_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_screenFix
      // 
      this.btn_screenFix.DisplayName = "commandBarButton1";
      this.btn_screenFix.Image = global::IDS.QuickAnnotator.Client.Local.Properties.Resources.computer_3_add;
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
      this.elementHost1.Size = new System.Drawing.Size(764, 673);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 74);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(1209, 673);
      this.radSplitContainer1.SplitterWidth = 16;
      this.radSplitContainer1.TabIndex = 1;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(764, 673);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1404024F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(132, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.panel_controls);
      this.splitPanel2.Location = new System.Drawing.Point(780, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(429, 673);
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
      this.panel_controls.Margin = new System.Windows.Forms.Padding(6);
      this.panel_controls.Name = "panel_controls";
      this.panel_controls.Padding = new System.Windows.Forms.Padding(0);
      // 
      // panel_controls.PanelContainer
      // 
      this.panel_controls.PanelContainer.Controls.Add(this.btn_submit_doppelform);
      this.panel_controls.PanelContainer.Controls.Add(this.btn_submit);
      this.panel_controls.PanelContainer.Location = new System.Drawing.Point(0, 0);
      this.panel_controls.PanelContainer.Margin = new System.Windows.Forms.Padding(15);
      this.panel_controls.PanelContainer.Size = new System.Drawing.Size(412, 673);
      this.panel_controls.Size = new System.Drawing.Size(429, 673);
      this.panel_controls.TabIndex = 7;
      this.panel_controls.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      // 
      // btn_submit_doppelform
      // 
      this.btn_submit_doppelform.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_submit_doppelform.Location = new System.Drawing.Point(0, 36);
      this.btn_submit_doppelform.Margin = new System.Windows.Forms.Padding(6);
      this.btn_submit_doppelform.Name = "btn_submit_doppelform";
      this.btn_submit_doppelform.Size = new System.Drawing.Size(412, 36);
      this.btn_submit_doppelform.TabIndex = 23;
      this.btn_submit_doppelform.Text = "Doppelform";
      this.toolTip1.SetToolTip(this.btn_submit_doppelform, "Annotation anwenden");
      this.btn_submit_doppelform.Click += new System.EventHandler(this.btn_submit_doppelform_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_submit_doppelform.GetChildAt(0))).Text = "Doppelform";
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_submit_doppelform.GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5);
      // 
      // btn_submit
      // 
      this.btn_submit.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_submit.Location = new System.Drawing.Point(0, 0);
      this.btn_submit.Margin = new System.Windows.Forms.Padding(15, 6, 6, 6);
      this.btn_submit.Name = "btn_submit";
      this.btn_submit.Size = new System.Drawing.Size(412, 36);
      this.btn_submit.TabIndex = 7;
      this.btn_submit.Text = "Annotieren";
      this.toolTip1.SetToolTip(this.btn_submit, "Annotation anwenden");
      this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_submit.GetChildAt(0))).Text = "Annotieren";
      ((Telerik.WinControls.UI.RadButtonElement)(this.btn_submit.GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5);
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
      ((System.ComponentModel.ISupportInitialize)(this.btn_submit_doppelform)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_submit)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar commands;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private System.Windows.Forms.ToolTip toolTip1;
    private Telerik.WinControls.UI.RadButton btn_submit;
    private Telerik.WinControls.UI.RadButton btn_submit_doppelform;
        private Telerik.WinControls.UI.RadScrollablePanel panel_controls;
        private Telerik.WinControls.UI.CommandBarButton btn_screenFix;
    private Telerik.WinControls.UI.CommandBarButton btn_loadProject;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarButton btn_accept;
    private Telerik.WinControls.UI.CommandBarButton btn_reject;
  }
}
