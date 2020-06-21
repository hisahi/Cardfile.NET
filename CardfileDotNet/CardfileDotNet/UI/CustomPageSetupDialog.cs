using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class CustomPageSetupDialog : LocalizableForm
    {
        private PageSetupDataSource source;

        public CustomPageSetupDialog()
        {
            InitializeComponent();
            source = new PageSetupDataSource();
            textBoxPageHeader.DataBindings.Add("Text", source, "PageHeader");
            textBoxPageFooter.DataBindings.Add("Text", source, "PageFooter");
            radioButtonPrintPage.DataBindings.Add("Checked", source, "PrintModePage");
            radioButtonPrintCard.DataBindings.Add("Checked", source, "PrintModeCard");
        }

        public PageSetupDialog DefaultDialog { get; set; }

        public override void Localize()
        {
            this.Text = Language.GetMenuText("filePageSetupToolStripMenuItem.Text");
            Language.LocalizeControls(this, new Control[] { });
            this.buttonOk.Text = Language.Get("OK");
            this.buttonCancel.Text = Language.Get("Cancel");
        }

        private void buttonNormalPageSetup_Click(object sender, EventArgs e)
        {
            DefaultDialog.ShowDialog(this);
        }

        private void CustomPageSetupDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                buttonCancel.PerformClick();
        }
    }

    public class PageSetupDataSource : VolatileState
    {
        public string PageHeader
        {
            get => OptionHandler.PageHeader;
            set => Properties.Settings.Default.PrintHeader = OptionHandler.SetMaybeStringValue(value);
        }

        public string PageFooter
        {
            get => OptionHandler.PageFooter;
            set => Properties.Settings.Default.PrintFooter = OptionHandler.SetMaybeStringValue(value);
        }

        public bool PrintModePage
        {
            get => Properties.Settings.Default.PrintMode == CardPrintMode.FullPage;
            set
            {
                if (value)
                    Properties.Settings.Default.PrintMode = CardPrintMode.FullPage;
            }
        }

        public bool PrintModeCard
        {
            get => Properties.Settings.Default.PrintMode == CardPrintMode.CardFrame;
            set
            {
                if (value)
                    Properties.Settings.Default.PrintMode = CardPrintMode.CardFrame;
            }
        }
    }
}
