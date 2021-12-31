using CardfileDotNet.Localization;
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
    public partial class AboutDialog : LocalizableForm
    {
        public AboutDialog()
        {
            InitializeComponent();
            this.textBoxLicense.Font = new Font(FontFamily.GenericMonospace, this.textBoxLicense.Font.Size);
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            pictureBoxIcon.ClientSize = new Size(32, 32);
            pictureBoxIcon.Image = Properties.Resources.cardfileLogo;
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public override void Localize()
        {
            this.Text = Language.GetMenuText("helpAboutToolStripMenuItem.Text");
            this.labelName.Text = Language.Get("ProgramName", "Cardfile.NET");
            this.labelDescription.Text = Language.Get("ProgramInspiration", "A modern recreation of the \"Cardfile\" program in older versions of Windows.");
            this.labelAuthor.Text = string.Format(Language.Get("AuthorInfo", "by {0} and {1}"), "Sampo Hippeläinen (hisahi) 2020-2022", "Cardfile.NET Team");
            this.labelVersion.Text = string.Format(Language.Get("ProgramVersion", "program version {0}"), MainForm.Version);
        }
    }
}
