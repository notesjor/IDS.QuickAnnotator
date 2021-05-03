using IDS.QuickAnnotator.Client.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using Telerik.WinControls;

namespace IDS.QuickAnnotator.Client
{
  public partial class DashboardForm : AbstractForm
  {
    private Editor _editor = new Editor();

    public DashboardForm()
    {
      InitializeComponent();
      cmb_text.CommandBarDropDownListElement.TextBox.Margin = new Padding(0, 6, 0, 0);

      // EDITOR
      _editor.Height = elementHost1.Height;
      _editor.Width = elementHost1.Width;
      _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      _editor.KeyPressed += EditorOnKeyPressed;

      elementHost1.Child = _editor;      
    }

    private void EditorOnKeyPressed(Key key)
    {
      switch (key)
      {
        case Key.Q:
          radio_pb_del_q.IsChecked = true;
          break;
        case Key.W:
          radio_pb_true_w.IsChecked = true;
          break;
      }
    }

    private void btn_export_Click(object sender, EventArgs e)
    {

    }

    private void btn_save_Click(object sender, EventArgs e)
    {

    }

    private void cmb_text_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {

    }
  }
}
