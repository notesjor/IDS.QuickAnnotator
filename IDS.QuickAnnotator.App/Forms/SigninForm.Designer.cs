namespace IDS.QuickAnnotator.Client.Forms
{
    partial class SigninForm
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
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.chk_save = new Telerik.WinControls.UI.RadCheckBox();
      this.btn_signin = new Telerik.WinControls.UI.RadButton();
      this.txt_authToken = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_save)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_signin)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_authToken)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.BackColor = System.Drawing.Color.Transparent;
      this.radGroupBox1.Controls.Add(this.chk_save);
      this.radGroupBox1.Controls.Add(this.btn_signin);
      this.radGroupBox1.Controls.Add(this.txt_authToken);
      this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(1);
      this.radGroupBox1.HeaderText = "Anmeldedaten";
      this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(516, 112);
      this.radGroupBox1.TabIndex = 0;
      this.radGroupBox1.Text = "Anmeldedaten";
      // 
      // chk_save
      // 
      this.chk_save.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_save.Dock = System.Windows.Forms.DockStyle.Left;
      this.chk_save.Location = new System.Drawing.Point(5, 61);
      this.chk_save.Name = "chk_save";
      this.chk_save.Padding = new System.Windows.Forms.Padding(10, 12, 0, 0);
      this.chk_save.Size = new System.Drawing.Size(180, 31);
      this.chk_save.TabIndex = 2;
      this.chk_save.Text = "AuthToken speichern?";
      // 
      // btn_signin
      // 
      this.btn_signin.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_signin.Location = new System.Drawing.Point(374, 61);
      this.btn_signin.Name = "btn_signin";
      this.btn_signin.Size = new System.Drawing.Size(137, 46);
      this.btn_signin.TabIndex = 1;
      this.btn_signin.Text = "Anmelden";
      this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
      // 
      // txt_authToken
      // 
      this.txt_authToken.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_authToken.Location = new System.Drawing.Point(5, 25);
      this.txt_authToken.Name = "txt_authToken";
      this.txt_authToken.NullText = "AuthToken hier eingeben...";
      this.txt_authToken.Size = new System.Drawing.Size(506, 36);
      this.txt_authToken.TabIndex = 0;
      // 
      // SigninForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(540, 136);
      this.Controls.Add(this.radGroupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "SigninForm";
      this.Text = "QuickAnnotator";
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_save)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_signin)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_authToken)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion

    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadButton btn_signin;
    private Telerik.WinControls.UI.RadTextBox txt_authToken;
    private Telerik.WinControls.UI.RadCheckBox chk_save;
  }
}
