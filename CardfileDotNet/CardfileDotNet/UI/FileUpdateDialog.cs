using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class FileUpdateDialog : LocalizableForm
    {
        public FileUpdateDialog()
        {
            InitializeComponent();
            this.columnCardIndex.DisplayMember = "Index";
            this.columnCardFileName.DisplayMember = "FileName";
            fileListView.DataSource = Files;
        }

        public BindingList<FileUpdate> Files { get; } = new BindingList<FileUpdate>();
        public List<FileUpdate> CheckedFiles => Files.Where(file => fileListView.GetItem(file).Checked).ToList();

        public override void Localize()
        {
            this.buttonCancel.Text = Language.Get("Cancel");
            Language.LocalizeControls(this, new Control[] { });
        }

        private void buttonFileCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
                item.Checked = true;
        }

        private void buttonCheckNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
                item.Checked = false;
        }

        private void buttonInvertCheck_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
                item.Checked = !item.Checked;
        }

        private void buttonFilesUpdate_Click(object sender, EventArgs e)
        {
            UpdateRequest?.Invoke(this, new EventArgs());
            Hide();
            Files.Clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
            Files.Clear();
        }

        private void FileUpdateDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                buttonCancel.PerformClick();
        }

        private void FileUpdateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Files.Clear();
        }

        public event EventHandler UpdateRequest;
    }

    public class FileUpdate : VolatileState
    {
        private Card card;
        private string path;

        public FileUpdate(Card card, string path)
        {
            Card = card;
            FilePath = path;
        }

        public Card Card
        {
            get => card;
            private set
            {
                if (card != null) card.CardChanged -= Card_CardChanged;
                card = value;
                card.CardChanged += Card_CardChanged;
                Update(nameof(Index));
            }
        }

        private void Card_CardChanged(object sender, CardChangedEventArgs e)
        {
            Update(nameof(Index));
        }

        public string Index => card.Index;

        public string FilePath
        {
            get => path;
            set => Set(ref path, value);
        }

        public string FileName => Path.GetFileName(path);
    }
}
