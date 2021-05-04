namespace IDS.QuickAnnotator.Client
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
      this.commands = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.cmb_text = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_export = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_focus = new Telerik.WinControls.UI.CommandBarButton();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.chk_pb_t = new Telerik.WinControls.UI.RadCheckBox();
      this.radio_pb_false_e = new Telerik.WinControls.UI.RadRadioButton();
      this.radio_pb_true_w = new Telerik.WinControls.UI.RadRadioButton();
      this.radio_pb_del_q = new Telerik.WinControls.UI.RadRadioButton();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.chk_gen_g = new Telerik.WinControls.UI.RadCheckBox();
      this.radio_gen_false_d = new Telerik.WinControls.UI.RadRadioButton();
      this.radio_gen_true_s = new Telerik.WinControls.UI.RadRadioButton();
      this.radio_gen_del_a = new Telerik.WinControls.UI.RadRadioButton();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.chk_co_b = new Telerik.WinControls.UI.RadCheckBox();
      this.radio_co_false_c = new Telerik.WinControls.UI.RadRadioButton();
      this.radio_co_true_x = new Telerik.WinControls.UI.RadRadioButton();
      this.radio_co_del_y = new Telerik.WinControls.UI.RadRadioButton();
      this.panel4 = new System.Windows.Forms.Panel();
      this.btn_submit = new Telerik.WinControls.UI.RadButton();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.commands)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_pb_t)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_pb_false_e)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_pb_true_w)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_pb_del_q)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_gen_g)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_gen_false_d)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_gen_true_s)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_gen_del_a)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_co_b)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_co_false_c)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_co_true_x)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_co_del_y)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_submit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // commands
      // 
      this.commands.Dock = System.Windows.Forms.DockStyle.Top;
      this.commands.Location = new System.Drawing.Point(0, 0);
      this.commands.Name = "commands";
      this.commands.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.commands.Size = new System.Drawing.Size(985, 48);
      this.commands.TabIndex = 0;
      this.commands.Enter += new System.EventHandler(this.commands_Enter);
      this.commands.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commands_KeyPress);
      this.commands.Leave += new System.EventHandler(this.commands_Leave);
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
            this.btn_save,
            this.commandBarLabel1,
            this.cmb_text,
            this.commandBarSeparator1,
            this.btn_export,
            this.btn_focus});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // 
      // 
      this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
      // 
      // btn_save
      // 
      this.btn_save.DisplayName = "commandBarButton1";
      this.btn_save.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.save1;
      this.btn_save.Name = "btn_save";
      this.btn_save.Text = "Speichern";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
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
      radListDataItem1.Text = "ListItem 1";
      radListDataItem2.Text = "ListItem 2";
      radListDataItem3.Text = "ListItem 3";
      this.cmb_text.Items.Add(radListDataItem1);
      this.cmb_text.Items.Add(radListDataItem2);
      this.cmb_text.Items.Add(radListDataItem3);
      this.cmb_text.MaxDropDownItems = 0;
      this.cmb_text.MinSize = new System.Drawing.Size(200, 48);
      this.cmb_text.Name = "cmb_text";
      this.cmb_text.Text = "text";
      this.cmb_text.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmb_text_SelectedIndexChanged);
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
      // btn_focus
      // 
      this.btn_focus.DisplayName = "commandBarButton1";
      this.btn_focus.Image = ((System.Drawing.Image)(resources.GetObject("btn_focus.Image")));
      this.btn_focus.Name = "btn_focus";
      this.btn_focus.Text = "Focus";
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(10, 10);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(603, 589);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 48);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.radSplitContainer1.Size = new System.Drawing.Size(985, 609);
      this.radSplitContainer1.SplitterWidth = 8;
      this.radSplitContainer1.TabIndex = 1;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      this.splitPanel1.Padding = new System.Windows.Forms.Padding(10);
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel1.Size = new System.Drawing.Size(623, 609);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1376663F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(113, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.flowLayoutPanel1);
      this.splitPanel2.Location = new System.Drawing.Point(631, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel2.Size = new System.Drawing.Size(354, 609);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1376663F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(-113, 0);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Controls.Add(this.radLabel1);
      this.flowLayoutPanel1.Controls.Add(this.panel1);
      this.flowLayoutPanel1.Controls.Add(this.radLabel2);
      this.flowLayoutPanel1.Controls.Add(this.panel2);
      this.flowLayoutPanel1.Controls.Add(this.radLabel3);
      this.flowLayoutPanel1.Controls.Add(this.panel3);
      this.flowLayoutPanel1.Controls.Add(this.panel4);
      this.flowLayoutPanel1.Controls.Add(this.btn_submit);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(354, 609);
      this.flowLayoutPanel1.TabIndex = 0;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Location = new System.Drawing.Point(3, 3);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(347, 21);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "Ist Personenbezeichnung?";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.chk_pb_t);
      this.panel1.Controls.Add(this.radio_pb_false_e);
      this.panel1.Controls.Add(this.radio_pb_true_w);
      this.panel1.Controls.Add(this.radio_pb_del_q);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 30);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(347, 31);
      this.panel1.TabIndex = 1;
      // 
      // chk_pb_t
      // 
      this.chk_pb_t.Dock = System.Windows.Forms.DockStyle.Right;
      this.chk_pb_t.Location = new System.Drawing.Point(248, 0);
      this.chk_pb_t.Name = "chk_pb_t";
      this.chk_pb_t.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.chk_pb_t.Size = new System.Drawing.Size(99, 31);
      this.chk_pb_t.TabIndex = 3;
      this.chk_pb_t.Text = "<html> unsicher? <span style=\"font-size: 8.5pt\">T</span></html>";
      this.toolTip1.SetToolTip(this.chk_pb_t, "Unsicherheit markieren");
      // 
      // radio_pb_false_e
      // 
      this.radio_pb_false_e.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_pb_false_e.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_pb_false_e.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.delete_button_error;
      this.radio_pb_false_e.Location = new System.Drawing.Point(137, 0);
      this.radio_pb_false_e.Name = "radio_pb_false_e";
      this.radio_pb_false_e.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
      this.radio_pb_false_e.Size = new System.Drawing.Size(76, 31);
      this.radio_pb_false_e.TabIndex = 2;
      this.radio_pb_false_e.Text = "E";
      this.radio_pb_false_e.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_pb_false_e, "Ablehnen");
      // 
      // radio_pb_true_w
      // 
      this.radio_pb_true_w.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_pb_true_w.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_pb_true_w.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.ok_button;
      this.radio_pb_true_w.Location = new System.Drawing.Point(57, 0);
      this.radio_pb_true_w.Name = "radio_pb_true_w";
      this.radio_pb_true_w.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
      this.radio_pb_true_w.Size = new System.Drawing.Size(80, 31);
      this.radio_pb_true_w.TabIndex = 1;
      this.radio_pb_true_w.Text = "W";
      this.radio_pb_true_w.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_pb_true_w, "Zustimmen");
      // 
      // radio_pb_del_q
      // 
      this.radio_pb_del_q.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_pb_del_q.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_pb_del_q.Image = ((System.Drawing.Image)(resources.GetObject("radio_pb_del_q.Image")));
      this.radio_pb_del_q.Location = new System.Drawing.Point(0, 0);
      this.radio_pb_del_q.Name = "radio_pb_del_q";
      this.radio_pb_del_q.Size = new System.Drawing.Size(57, 31);
      this.radio_pb_del_q.TabIndex = 0;
      this.radio_pb_del_q.Text = "Q";
      this.radio_pb_del_q.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_pb_del_q, "Wert entfernen");
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Location = new System.Drawing.Point(3, 67);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel2.Size = new System.Drawing.Size(307, 37);
      this.radLabel2.TabIndex = 2;
      this.radLabel2.Text = "Gendern notwendig?";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.chk_gen_g);
      this.panel2.Controls.Add(this.radio_gen_false_d);
      this.panel2.Controls.Add(this.radio_gen_true_s);
      this.panel2.Controls.Add(this.radio_gen_del_a);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(3, 110);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(347, 31);
      this.panel2.TabIndex = 3;
      // 
      // chk_gen_g
      // 
      this.chk_gen_g.Dock = System.Windows.Forms.DockStyle.Right;
      this.chk_gen_g.Location = new System.Drawing.Point(247, 0);
      this.chk_gen_g.Name = "chk_gen_g";
      this.chk_gen_g.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.chk_gen_g.Size = new System.Drawing.Size(100, 31);
      this.chk_gen_g.TabIndex = 3;
      this.chk_gen_g.Text = "<html> unsicher? <span style=\"font-size: 8.5pt\">G</span></html>";
      this.toolTip1.SetToolTip(this.chk_gen_g, "Unsicherheit markieren");
      // 
      // radio_gen_false_d
      // 
      this.radio_gen_false_d.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_gen_false_d.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_gen_false_d.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.delete_button_error;
      this.radio_gen_false_d.Location = new System.Drawing.Point(133, 0);
      this.radio_gen_false_d.Name = "radio_gen_false_d";
      this.radio_gen_false_d.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
      this.radio_gen_false_d.Size = new System.Drawing.Size(77, 31);
      this.radio_gen_false_d.TabIndex = 2;
      this.radio_gen_false_d.Text = "D";
      this.radio_gen_false_d.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_gen_false_d, "Ablehnen");
      // 
      // radio_gen_true_s
      // 
      this.radio_gen_true_s.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_gen_true_s.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_gen_true_s.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.ok_button;
      this.radio_gen_true_s.Location = new System.Drawing.Point(57, 0);
      this.radio_gen_true_s.Name = "radio_gen_true_s";
      this.radio_gen_true_s.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
      this.radio_gen_true_s.Size = new System.Drawing.Size(76, 31);
      this.radio_gen_true_s.TabIndex = 1;
      this.radio_gen_true_s.Text = "S";
      this.radio_gen_true_s.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_gen_true_s, "Zustimmen");
      // 
      // radio_gen_del_a
      // 
      this.radio_gen_del_a.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_gen_del_a.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_gen_del_a.Image = ((System.Drawing.Image)(resources.GetObject("radio_gen_del_a.Image")));
      this.radio_gen_del_a.Location = new System.Drawing.Point(0, 0);
      this.radio_gen_del_a.Name = "radio_gen_del_a";
      this.radio_gen_del_a.Size = new System.Drawing.Size(57, 31);
      this.radio_gen_del_a.TabIndex = 0;
      this.radio_gen_del_a.Text = "A";
      this.radio_gen_del_a.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_gen_del_a, "Wert entfernen");
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Location = new System.Drawing.Point(3, 147);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel3.Size = new System.Drawing.Size(307, 37);
      this.radLabel3.TabIndex = 4;
      this.radLabel3.Text = "Ist Co-Referenz zu Eigennamen";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.chk_co_b);
      this.panel3.Controls.Add(this.radio_co_false_c);
      this.panel3.Controls.Add(this.radio_co_true_x);
      this.panel3.Controls.Add(this.radio_co_del_y);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(3, 190);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(347, 31);
      this.panel3.TabIndex = 5;
      // 
      // chk_co_b
      // 
      this.chk_co_b.Dock = System.Windows.Forms.DockStyle.Right;
      this.chk_co_b.Location = new System.Drawing.Point(248, 0);
      this.chk_co_b.Name = "chk_co_b";
      this.chk_co_b.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.chk_co_b.Size = new System.Drawing.Size(99, 31);
      this.chk_co_b.TabIndex = 3;
      this.chk_co_b.Text = "<html> unsicher? <span style=\"font-size: 8.5pt\">B</span></html>";
      this.toolTip1.SetToolTip(this.chk_co_b, "Unsicherheit markieren");
      // 
      // radio_co_false_c
      // 
      this.radio_co_false_c.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_co_false_c.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_co_false_c.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.delete_button_error;
      this.radio_co_false_c.Location = new System.Drawing.Point(133, 0);
      this.radio_co_false_c.Name = "radio_co_false_c";
      this.radio_co_false_c.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
      this.radio_co_false_c.Size = new System.Drawing.Size(77, 31);
      this.radio_co_false_c.TabIndex = 2;
      this.radio_co_false_c.Text = "C";
      this.radio_co_false_c.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_co_false_c, "Ablehnen");
      // 
      // radio_co_true_x
      // 
      this.radio_co_true_x.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_co_true_x.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_co_true_x.Image = global::IDS.QuickAnnotator.Client.Properties.Resources.ok_button;
      this.radio_co_true_x.Location = new System.Drawing.Point(56, 0);
      this.radio_co_true_x.Name = "radio_co_true_x";
      this.radio_co_true_x.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
      this.radio_co_true_x.Size = new System.Drawing.Size(77, 31);
      this.radio_co_true_x.TabIndex = 1;
      this.radio_co_true_x.Text = "X";
      this.radio_co_true_x.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_co_true_x, "Zustimmen");
      // 
      // radio_co_del_y
      // 
      this.radio_co_del_y.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_co_del_y.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_co_del_y.Image = ((System.Drawing.Image)(resources.GetObject("radio_co_del_y.Image")));
      this.radio_co_del_y.Location = new System.Drawing.Point(0, 0);
      this.radio_co_del_y.Name = "radio_co_del_y";
      this.radio_co_del_y.Size = new System.Drawing.Size(56, 31);
      this.radio_co_del_y.TabIndex = 0;
      this.radio_co_del_y.Text = "Y";
      this.radio_co_del_y.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.radio_co_del_y, "Wert entfernen");
      // 
      // panel4
      // 
      this.panel4.Location = new System.Drawing.Point(3, 227);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(307, 29);
      this.panel4.TabIndex = 6;
      // 
      // btn_submit
      // 
      this.btn_submit.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_submit.Location = new System.Drawing.Point(3, 262);
      this.btn_submit.Name = "btn_submit";
      this.btn_submit.Size = new System.Drawing.Size(347, 36);
      this.btn_submit.TabIndex = 7;
      this.btn_submit.Text = "Annotieren (ENTER)";
      this.toolTip1.SetToolTip(this.btn_submit, "Annotation anwenden");
      this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
      // 
      // DashboardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(985, 657);
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.commands);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "DashboardForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "QuickAnnotator";
      ((System.ComponentModel.ISupportInitialize)(this.commands)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_pb_t)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_pb_false_e)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_pb_true_w)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_pb_del_q)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_gen_g)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_gen_false_d)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_gen_true_s)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_gen_del_a)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_co_b)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_co_false_c)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_co_true_x)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_co_del_y)).EndInit();
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
    private Telerik.WinControls.UI.CommandBarButton btn_save;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private System.Windows.Forms.Panel panel1;
    private Telerik.WinControls.UI.RadRadioButton radio_pb_del_q;
    private Telerik.WinControls.UI.RadRadioButton radio_pb_false_e;
    private Telerik.WinControls.UI.RadRadioButton radio_pb_true_w;
    private Telerik.WinControls.UI.RadCheckBox chk_pb_t;
    private System.Windows.Forms.ToolTip toolTip1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private System.Windows.Forms.Panel panel2;
    private Telerik.WinControls.UI.RadCheckBox chk_gen_g;
    private Telerik.WinControls.UI.RadRadioButton radio_gen_false_d;
    private Telerik.WinControls.UI.RadRadioButton radio_gen_true_s;
    private Telerik.WinControls.UI.RadRadioButton radio_gen_del_a;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private System.Windows.Forms.Panel panel3;
    private Telerik.WinControls.UI.RadCheckBox chk_co_b;
    private Telerik.WinControls.UI.RadRadioButton radio_co_false_c;
    private Telerik.WinControls.UI.RadRadioButton radio_co_true_x;
    private Telerik.WinControls.UI.RadRadioButton radio_co_del_y;
    private System.Windows.Forms.Panel panel4;
    private Telerik.WinControls.UI.RadButton btn_submit;
    private Telerik.WinControls.UI.CommandBarButton btn_focus;
  }
}
