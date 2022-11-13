namespace IDS.QuickAnnotator.Client.Controls
{
  partial class StepControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StepControl));
      this.lbl_desc = new System.Windows.Forms.Label();
      this.panel_values = new Telerik.WinControls.UI.RadPanel();
      this.chk_unsure = new Telerik.WinControls.UI.RadCheckBox();
      this.radio_del = new Telerik.WinControls.UI.RadRadioButton();
      this.lbl_head = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.panel_values)).BeginInit();
      this.panel_values.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_unsure)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_del)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_head)).BeginInit();
      this.SuspendLayout();
      // 
      // lbl_desc
      // 
      this.lbl_desc.AutoSize = true;
      this.lbl_desc.Dock = System.Windows.Forms.DockStyle.Top;
      this.lbl_desc.Font = new System.Drawing.Font("Roboto Condensed", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_desc.Location = new System.Drawing.Point(0, 56);
      this.lbl_desc.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
      this.lbl_desc.Name = "lbl_desc";
      this.lbl_desc.Padding = new System.Windows.Forms.Padding(0, 0, 0, 9);
      this.lbl_desc.Size = new System.Drawing.Size(315, 22);
      this.lbl_desc.TabIndex = 9;
      this.lbl_desc.Text = "L1=Nominale PB / L2=Pronom+Co-Ref / L3=Kompositum / L4=abhängig";
      // 
      // panel_values
      // 
      this.panel_values.Controls.Add(this.chk_unsure);
      this.panel_values.Controls.Add(this.radio_del);
      this.panel_values.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_values.Location = new System.Drawing.Point(0, 21);
      this.panel_values.Margin = new System.Windows.Forms.Padding(24);
      this.panel_values.MaximumSize = new System.Drawing.Size(0, 35);
      this.panel_values.Name = "panel_values";
      this.panel_values.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
      // 
      // 
      // 
      this.panel_values.RootElement.MaxSize = new System.Drawing.Size(0, 35);
      this.panel_values.RootElement.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.panel_values.RootElement.ShadowDepth = 0;
      this.panel_values.Size = new System.Drawing.Size(412, 35);
      this.panel_values.TabIndex = 8;
      ((Telerik.WinControls.UI.RadPanelElement)(this.panel_values.GetChildAt(0))).ShadowDepth = 0;
      ((Telerik.WinControls.UI.RadPanelElement)(this.panel_values.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
      // 
      // chk_unsure
      // 
      this.chk_unsure.Dock = System.Windows.Forms.DockStyle.Right;
      this.chk_unsure.Location = new System.Drawing.Point(390, 3);
      this.chk_unsure.Margin = new System.Windows.Forms.Padding(6);
      this.chk_unsure.Name = "chk_unsure";
      this.chk_unsure.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
      this.chk_unsure.Size = new System.Drawing.Size(19, 32);
      this.chk_unsure.TabIndex = 3;
      // 
      // radio_del
      // 
      this.radio_del.BackColor = System.Drawing.Color.Transparent;
      this.radio_del.Dock = System.Windows.Forms.DockStyle.Left;
      this.radio_del.Font = new System.Drawing.Font("Roboto Medium", 8.5F);
      this.radio_del.Image = ((System.Drawing.Image)(resources.GetObject("radio_del.Image")));
      this.radio_del.Location = new System.Drawing.Point(3, 3);
      this.radio_del.Margin = new System.Windows.Forms.Padding(6);
      this.radio_del.Name = "radio_del";
      this.radio_del.Size = new System.Drawing.Size(45, 32);
      this.radio_del.TabIndex = 0;
      this.radio_del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.radio_del.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.StateChanged);
      // 
      // lbl_head
      // 
      this.lbl_head.Dock = System.Windows.Forms.DockStyle.Top;
      this.lbl_head.Location = new System.Drawing.Point(0, 0);
      this.lbl_head.Margin = new System.Windows.Forms.Padding(6);
      this.lbl_head.Name = "lbl_head";
      this.lbl_head.Size = new System.Drawing.Size(412, 21);
      this.lbl_head.TabIndex = 7;
      this.lbl_head.Text = "Linguistische Klasse";
      // 
      // StepControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lbl_desc);
      this.Controls.Add(this.panel_values);
      this.Controls.Add(this.lbl_head);
      this.Name = "StepControl";
      ((System.ComponentModel.ISupportInitialize)(this.panel_values)).EndInit();
      this.panel_values.ResumeLayout(false);
      this.panel_values.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_unsure)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_del)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_head)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label lbl_desc;
        private Telerik.WinControls.UI.RadPanel panel_values;
        private Telerik.WinControls.UI.RadCheckBox chk_unsure;
        private Telerik.WinControls.UI.RadRadioButton radio_del;
        private Telerik.WinControls.UI.RadLabel lbl_head;
    }
}
