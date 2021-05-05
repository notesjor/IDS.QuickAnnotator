
namespace IDS.QuickAnnotator.Client
{
  partial class ExportForm
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
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.btn_export_text = new Telerik.WinControls.UI.RadButton();
      this.btn_export_anno_my = new Telerik.WinControls.UI.RadButton();
      this.btn_export_history = new Telerik.WinControls.UI.RadButton();
      this.btn_export_all_diff = new Telerik.WinControls.UI.RadButton();
      this.btn_export_anno_all = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.btn_export_diff = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_text)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_my)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_history)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_all_diff)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_all)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_diff)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radLabel1
      // 
      this.radLabel1.Location = new System.Drawing.Point(24, 13);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(200, 21);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "Was möchten Sie exportieren:";
      // 
      // btn_export_text
      // 
      this.btn_export_text.Location = new System.Drawing.Point(16, 35);
      this.btn_export_text.Name = "btn_export_text";
      this.btn_export_text.Size = new System.Drawing.Size(378, 36);
      this.btn_export_text.TabIndex = 1;
      this.btn_export_text.Text = "Nur Text (TXT)";
      this.btn_export_text.Click += new System.EventHandler(this.btn_export_text_Click);
      // 
      // btn_export_anno_my
      // 
      this.btn_export_anno_my.Location = new System.Drawing.Point(16, 77);
      this.btn_export_anno_my.Name = "btn_export_anno_my";
      this.btn_export_anno_my.Size = new System.Drawing.Size(378, 36);
      this.btn_export_anno_my.TabIndex = 2;
      this.btn_export_anno_my.Text = "Text + [MEINE] Annotationen (XML)";
      this.btn_export_anno_my.Click += new System.EventHandler(this.btn_export_anno_my_Click);
      // 
      // btn_export_history
      // 
      this.btn_export_history.Location = new System.Drawing.Point(16, 161);
      this.btn_export_history.Name = "btn_export_history";
      this.btn_export_history.Size = new System.Drawing.Size(378, 36);
      this.btn_export_history.TabIndex = 3;
      this.btn_export_history.Text = "Annotations-History (JSON)";
      this.btn_export_history.Click += new System.EventHandler(this.btn_export_history_Click);
      // 
      // btn_export_all_diff
      // 
      this.btn_export_all_diff.Location = new System.Drawing.Point(16, 33);
      this.btn_export_all_diff.Name = "btn_export_all_diff";
      this.btn_export_all_diff.Size = new System.Drawing.Size(378, 36);
      this.btn_export_all_diff.TabIndex = 4;
      this.btn_export_all_diff.Text = "Annotator-Diff (TSV)";
      this.btn_export_all_diff.Click += new System.EventHandler(this.btn_export_all_diff_Click);
      // 
      // btn_export_anno_all
      // 
      this.btn_export_anno_all.Location = new System.Drawing.Point(16, 119);
      this.btn_export_anno_all.Name = "btn_export_anno_all";
      this.btn_export_anno_all.Size = new System.Drawing.Size(378, 36);
      this.btn_export_anno_all.TabIndex = 5;
      this.btn_export_anno_all.Text = "Text + [ALLE] Annotationen (XML)";
      this.btn_export_anno_all.Click += new System.EventHandler(this.btn_export_anno_all_Click);
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.btn_export_diff);
      this.radGroupBox1.Controls.Add(this.btn_export_text);
      this.radGroupBox1.Controls.Add(this.btn_export_anno_all);
      this.radGroupBox1.Controls.Add(this.btn_export_anno_my);
      this.radGroupBox1.Controls.Add(this.btn_export_history);
      this.radGroupBox1.HeaderText = "Aktuell gewählter Text";
      this.radGroupBox1.Location = new System.Drawing.Point(24, 40);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Size = new System.Drawing.Size(416, 255);
      this.radGroupBox1.TabIndex = 6;
      this.radGroupBox1.Text = "Aktuell gewählter Text";
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.btn_export_all_diff);
      this.radGroupBox2.HeaderText = "Gesamtes Korpus";
      this.radGroupBox2.Location = new System.Drawing.Point(24, 311);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Size = new System.Drawing.Size(416, 90);
      this.radGroupBox2.TabIndex = 7;
      this.radGroupBox2.Text = "Gesamtes Korpus";
      // 
      // btn_export_diff
      // 
      this.btn_export_diff.Location = new System.Drawing.Point(16, 203);
      this.btn_export_diff.Name = "btn_export_diff";
      this.btn_export_diff.Size = new System.Drawing.Size(378, 36);
      this.btn_export_diff.TabIndex = 6;
      this.btn_export_diff.Text = "Annotator-Diff (TSV)";
      this.btn_export_diff.Click += new System.EventHandler(this.btn_export_diff_Click);
      // 
      // ExportForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(469, 428);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.radLabel1);
      this.MaximizeBox = false;
      this.Name = "ExportForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Exportieren";
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_text)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_my)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_history)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_all_diff)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_all)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_diff)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadButton btn_export_text;
    private Telerik.WinControls.UI.RadButton btn_export_anno_my;
    private Telerik.WinControls.UI.RadButton btn_export_history;
    private Telerik.WinControls.UI.RadButton btn_export_all_diff;
    private Telerik.WinControls.UI.RadButton btn_export_anno_all;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadButton btn_export_diff;
  }
}