
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
      this.btn_export_diff = new Telerik.WinControls.UI.RadButton();
      this.btn_export_anno_all = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_text)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_my)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_history)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_diff)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_all)).BeginInit();
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
      this.btn_export_text.Location = new System.Drawing.Point(24, 41);
      this.btn_export_text.Name = "btn_export_text";
      this.btn_export_text.Size = new System.Drawing.Size(378, 36);
      this.btn_export_text.TabIndex = 1;
      this.btn_export_text.Text = "Nur Text (TXT)";
      this.btn_export_text.Click += new System.EventHandler(this.btn_export_text_Click);
      // 
      // btn_export_anno_my
      // 
      this.btn_export_anno_my.Location = new System.Drawing.Point(24, 83);
      this.btn_export_anno_my.Name = "btn_export_anno_my";
      this.btn_export_anno_my.Size = new System.Drawing.Size(378, 36);
      this.btn_export_anno_my.TabIndex = 2;
      this.btn_export_anno_my.Text = "Text + [MEINE] Annotationen (XML)";
      this.btn_export_anno_my.Click += new System.EventHandler(this.btn_export_anno_my_Click);
      // 
      // btn_export_history
      // 
      this.btn_export_history.Location = new System.Drawing.Point(24, 167);
      this.btn_export_history.Name = "btn_export_history";
      this.btn_export_history.Size = new System.Drawing.Size(378, 36);
      this.btn_export_history.TabIndex = 3;
      this.btn_export_history.Text = "Annotations-History (JSON)";
      this.btn_export_history.Click += new System.EventHandler(this.btn_export_history_Click);
      // 
      // btn_export_diff
      // 
      this.btn_export_diff.Location = new System.Drawing.Point(24, 209);
      this.btn_export_diff.Name = "btn_export_diff";
      this.btn_export_diff.Size = new System.Drawing.Size(378, 36);
      this.btn_export_diff.TabIndex = 4;
      this.btn_export_diff.Text = "Annotator-Diff (TSV)";
      this.btn_export_diff.Click += new System.EventHandler(this.btn_export_diff_Click);
      // 
      // btn_export_anno_all
      // 
      this.btn_export_anno_all.Location = new System.Drawing.Point(24, 125);
      this.btn_export_anno_all.Name = "btn_export_anno_all";
      this.btn_export_anno_all.Size = new System.Drawing.Size(378, 36);
      this.btn_export_anno_all.TabIndex = 5;
      this.btn_export_anno_all.Text = "Text + [ALLE] Annotationen (XML)";
      this.btn_export_anno_all.Click += new System.EventHandler(this.btn_export_anno_all_Click);
      // 
      // ExportForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(414, 282);
      this.Controls.Add(this.btn_export_anno_all);
      this.Controls.Add(this.btn_export_diff);
      this.Controls.Add(this.btn_export_history);
      this.Controls.Add(this.btn_export_anno_my);
      this.Controls.Add(this.btn_export_text);
      this.Controls.Add(this.radLabel1);
      this.MaximizeBox = false;
      this.Name = "ExportForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Exportieren";
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_text)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_my)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_history)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_diff)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_export_anno_all)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadButton btn_export_text;
    private Telerik.WinControls.UI.RadButton btn_export_anno_my;
    private Telerik.WinControls.UI.RadButton btn_export_history;
    private Telerik.WinControls.UI.RadButton btn_export_diff;
    private Telerik.WinControls.UI.RadButton btn_export_anno_all;
  }
}