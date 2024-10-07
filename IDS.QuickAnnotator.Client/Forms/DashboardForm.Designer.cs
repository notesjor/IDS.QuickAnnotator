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
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
      this.commands = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.cmb_text = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_screenFix = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.panel_controls = new Telerik.WinControls.UI.RadScrollablePanel();
      this.radButton2 = new Telerik.WinControls.UI.RadButton();
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
      ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
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
      this.commands.Size = new System.Drawing.Size(1209, 49);
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
            this.cmb_text,
            this.commandBarSeparator1,
            this.btn_export,
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
      this.commandBarLabel1.Text = "Dokument:";
      // 
      // cmb_text
      // 
      this.cmb_text.DisplayName = "commandBarDropDownList1";
      this.cmb_text.DropDownAnimationEnabled = true;
      this.cmb_text.DropDownHeight = 208;
      radListDataItem1.Text = "ListItem 1";
      radListDataItem2.Text = "ListItem 2";
      radListDataItem3.Text = "ListItem 3";
      this.cmb_text.Items.Add(radListDataItem1);
      this.cmb_text.Items.Add(radListDataItem2);
      this.cmb_text.Items.Add(radListDataItem3);
      this.cmb_text.MinSize = new System.Drawing.Size(391, 94);
      this.cmb_text.Name = "cmb_text";
      this.cmb_text.Text = "text";
      this.cmb_text.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.Cmb_textOnSelectedIndexChanged);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_export
      // 
      this.btn_export.DisplayName = "commandBarButton2";
      this.btn_export.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.database_export;
      this.btn_export.Name = "btn_export";
      this.btn_export.Text = "Exportieren";
      this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
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
      this.elementHost1.Size = new System.Drawing.Size(764, 698);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 49);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(1209, 698);
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
      this.splitPanel1.Size = new System.Drawing.Size(764, 698);
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
      this.splitPanel2.Size = new System.Drawing.Size(429, 698);
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
      this.panel_controls.PanelContainer.Controls.Add(this.radButton2);
      this.panel_controls.PanelContainer.Controls.Add(this.radButton1);
      this.panel_controls.PanelContainer.Controls.Add(this.btn_submit);
      this.panel_controls.PanelContainer.Location = new System.Drawing.Point(0, 0);
      this.panel_controls.PanelContainer.Margin = new System.Windows.Forms.Padding(15);
      this.panel_controls.PanelContainer.Size = new System.Drawing.Size(412, 698);
      this.panel_controls.Size = new System.Drawing.Size(429, 698);
      this.panel_controls.TabIndex = 7;
      this.panel_controls.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      // 
      // radButton2
      // 
      this.radButton2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radButton2.Location = new System.Drawing.Point(0, 72);
      this.radButton2.Margin = new System.Windows.Forms.Padding(6);
      this.radButton2.Name = "radButton2";
      this.radButton2.Size = new System.Drawing.Size(412, 36);
      this.radButton2.TabIndex = 25;
      this.radButton2.Text = "Reguläre Doppelform";
      this.toolTip1.SetToolTip(this.radButton2, "Annotation anwenden");
      ((Telerik.WinControls.UI.RadButtonElement)(this.radButton2.GetChildAt(0))).Text = "Reguläre Doppelform";
      ((Telerik.WinControls.UI.RadButtonElement)(this.radButton2.GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5);
      // 
      // radButton1
      // 
      this.radButton1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radButton1.Location = new System.Drawing.Point(0, 36);
      this.radButton1.Margin = new System.Windows.Forms.Padding(6);
      this.radButton1.Name = "radButton1";
      this.radButton1.Size = new System.Drawing.Size(412, 36);
      this.radButton1.TabIndex = 24;
      this.radButton1.Text = "Alternierende Doppelform";
      this.toolTip1.SetToolTip(this.radButton1, "Annotation anwenden");
      ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Alternierende Doppelform";
      ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Margin = new System.Windows.Forms.Padding(5);
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
      ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
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
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList cmb_text;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private System.Windows.Forms.ToolTip toolTip1;
    private Telerik.WinControls.UI.RadButton btn_submit;
        private Telerik.WinControls.UI.RadScrollablePanel panel_controls;
        private Telerik.WinControls.UI.CommandBarButton btn_screenFix;
    private Telerik.WinControls.UI.RadButton radButton2;
    private Telerik.WinControls.UI.RadButton radButton1;
  }
}
