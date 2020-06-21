using CardfileDotNet.Localization;
using System;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class GoToDialog : LocalizableForm
    {
        public GoToDialog()
        {
            InitializeComponent();
        }

        public string Value
        {
            get => indexTextBox.Text;
            set => indexTextBox.Text = value;
        }

        private void IndexDialog_Shown(object sender, EventArgs e)
        {
            indexTextBox.Focus();
            indexTextBox.SelectAll();
        }

        public override void Localize()
        {
            this.Text = Language.GetMenuText("searchGoToToolStripMenuItem.Text");
            this.labelGoToText.Text = Language.Get("labelGoToText.Text");
            this.buttonOk.Text = Language.Get("OK");
            this.buttonCancel.Text = Language.Get("Cancel");
        }

        private void GoToDialog_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonCancel.PerformClick();
                e.Handled = true;
            }
        }

        private void indexTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonOk.PerformClick();
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonCancel.PerformClick();
                e.Handled = true;
            }
        }
    }
}
