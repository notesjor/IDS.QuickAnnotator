using IDS.QuickAnnotator.Client.Model;
using System;

namespace IDS.QuickAnnotator.Client
{
  public partial class SigninForm : AbstractForm
  {
    public SigninForm(string authToken)
    {
      InitializeComponent();
      txt_authToken.Text = authToken;
    }

    private void btn_signin_Click(object sender, EventArgs e)
    {
      var auth = new AuthModel();
      if(auth.Signin(txt_authToken.Text, chk_save.Checked))
      {
        var form = new DashboardForm();
        Hide();
        form.ShowDialog();
        Close();
      }
    }
  }
}
