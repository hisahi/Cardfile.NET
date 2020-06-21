using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Util;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class FileViewUserControl : LocalizableUserControl
    {
        public WindowState State { get; } = null;
        private Card Card;
        private AttachmentFile File;
        private TempDirectory tempdir;
        private Dictionary<string, Card> fileUpdatePairs;
        private FileUpdateDialog fileUpdateDialog = new FileUpdateDialog();

        public FileViewUserControl(WindowState state)
        {
            InitializeComponent();
            State = state;
            fileUpdatePairs = new Dictionary<string, Card>();
            State.BindFile(GotFile);
            State.BindFrontCard(GotCard);
            panelFilePreview.Resize += PanelFilePreview_Resize;
            iconImageList.Images.Add(SystemIcons.WinLogo);
            Disposed += OnDispose;
            textBoxIndex.Font = new Font(FontFamily.GenericMonospace, textBoxIndex.Font.Size);
            fileUpdateDialog.UpdateRequest += FileUpdateDialog_UpdateRequest;
            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
            listViewFile.Resize += (s, e) => RecenterIcon();
        }

        public override void Localize()
        {
            Language.LocalizeControls(this, new Control[] { });
            fileUpdateDialog.Localize();
        }

        private void OnDispose(object sender, EventArgs e)
        {
            tempdir.Dispose();
        }

        public void GotFile(Cardfile file)
        {
            tempdir = new TempDirectory("Cardfile.NET");
            fileUpdatePairs.Clear();
        }

        public void GotCard(Card card)
        {
            if (Card != null) Card.CardChanged -= Card_CardChanged;
            Card = card;
            if (card == null)
            {
                UpdateAttachment(null);
                return;
            }
            textBoxIndex.Text = card.Index;
            UpdateAttachment(card.Attachment);
            card.CardChanged += Card_CardChanged;
        }

        private void Card_CardChanged(object sender, CardChangedEventArgs e)
        {
            Card card = sender as Card;
            if (e.OldValue != null)
                RemoveByValue(fileUpdatePairs, card);
            if (e.PropertyName == "Attachment")
                UpdateAttachment(e.NewValue as AttachmentFile);
            else if (e.PropertyName == "Index")
                textBoxIndex.Text = card.Index;
        }

        private void RemoveByValue<K, V>(Dictionary<K, V> dict, V val)
        {
            dict.Where(pair => val.Equals(pair.Value)).ToList().ForEach(pair => dict.Remove(pair.Key));
        }

        private PreviewType AutoDetectPreviewType(AttachmentFile attachment)
        {
            if (attachment == null)
                return PreviewType.None;
            if (attachment.Mime == "image/bmp" || attachment.Mime == "image/gif" || attachment.Mime == "image/jpeg" || attachment.Mime == "image/png")
                return PreviewType.Image;
            return PreviewType.File;
        }

        private void UpdatePreview(PreviewType type)
        {
            listViewFile.Visible = pictureBoxImagePreview.Visible = false;
            listViewFile.Items.Clear();
            pictureBoxImagePreview.Image = null;
            switch (type)
            {
                case PreviewType.None:
                    return;
                case PreviewType.File:
                    iconImageList.Images.Clear();
                    iconImageList.Images.Add(Win32Util.GetIconForExtension(File.Name));
                    var fileItem = new ListViewItem(File.Name);
                    listViewFile.Items.Add(fileItem);
                    fileItem.ImageIndex = 0;
                    listViewFile.Visible = true;
                    RecenterIcon();
                    break;
                case PreviewType.Image:
                    MemoryStream imgStream = new MemoryStream(File.Data);
                    Image image;
                    try
                    {
                        image = Image.FromStream(imgStream);
                    }
                    catch (Exception)
                    {
                        UpdatePreview(PreviewType.File);
                        return;
                    }
                    pictureBoxImagePreview.Image = image;
                    pictureBoxImagePreview.Size = image.Size;
                    UpdatePictureBoxPosition();
                    pictureBoxImagePreview.Visible = true;
                    break;
            }
        }

        private void RecenterIcon()
        {
            if (listViewFile.Items.Count > 0)
            {
                var item = listViewFile.Items[0];
                int viewWidth = listViewFile.Width, viewHeight = listViewFile.Height;
                int itemWidth = SystemInformation.IconSpacingSize.Width, itemHeight = SystemInformation.IconSpacingSize.Height;
                item.EnsureVisible();
                item.Position = new Point(Math.Max(0, (viewWidth - itemWidth) / 2), Math.Max(0, (viewHeight - itemHeight) / 2));
            }
        }

        private void PanelFilePreview_Resize(object sender, EventArgs e)
        {
            UpdatePictureBoxPosition();
        }

        private void UpdatePictureBoxPosition()
        {
            if (pictureBoxImagePreview.Image != null)
            {
                pictureBoxImagePreview.Left = Math.Max(0, (panelFilePreview.Width - pictureBoxImagePreview.Width) / 2);
                pictureBoxImagePreview.Top = Math.Max(0, (panelFilePreview.Height - pictureBoxImagePreview.Height) / 2);
            }
        }

        private void UpdateAttachment(AttachmentFile attachment)
        {
            File = attachment;
            buttonOpenAttachment.Enabled = buttonExportAttachment.Enabled = buttonRemoveAttachment.Enabled = attachment != null;
            this.SuspendLayout();
            UpdatePreview(AutoDetectPreviewType(File));
            this.ResumeLayout();
        }

        private void buttonOpenAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                string fpath = Path.Combine(tempdir.Path, File.Name);
                fileUpdatePairs.Remove(fpath);
                tempdir.Create(fpath, File.Data);
                if (!fileSystemWatcher.EnableRaisingEvents)
                {
                    fileSystemWatcher.Path = tempdir.Path;
                    fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
                    fileSystemWatcher.EnableRaisingEvents = true;
                }
                fileUpdatePairs[fpath] = Card;
                Process.Start(fpath);
            }
            catch (IOException)
            {
            }
        }

        private void buttonImportAttachment_Click(object sender, EventArgs e)
        {
            (this.ParentForm as MainForm).TryImportAttachment();
        }

        private void buttonExportAttachment_Click(object sender, EventArgs e)
        {
            (this.ParentForm as MainForm).TryExportAttachment();
        }

        private void buttonRemoveAttachment_Click(object sender, EventArgs e)
        {
            Card.Attachment = null;
        }

        private void textBoxIndex_DoubleClick(object sender, EventArgs e)
        {
            (ParentForm as MainForm).OpenIndexDialog();
        }

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (fileUpdatePairs.ContainsKey(e.FullPath))
            {
                fileUpdateDialog.Owner = this.ParentForm;
                fileUpdateDialog.Show();
                fileUpdateDialog.BringToFront();
                bool found = false;
                foreach (FileUpdate fupd in fileUpdateDialog.Files)
                {
                    if (fupd.FilePath == e.FullPath)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    fileUpdateDialog.Files.Add(new FileUpdate(fileUpdatePairs[e.FullPath], e.FullPath));
            }
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            fileUpdatePairs.Remove(e.FullPath);
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            fileUpdatePairs[e.FullPath] = fileUpdatePairs[e.OldFullPath];
            fileUpdatePairs.Remove(e.OldFullPath);
            fileUpdateDialog.Owner = this.ParentForm;
            fileUpdateDialog.Show();
            fileUpdateDialog.BringToFront();

            bool found = false;
            foreach (FileUpdate fupd in fileUpdateDialog.Files)
            {
                if (fupd.FilePath == e.OldFullPath)
                {
                    fupd.FilePath = e.FullPath;
                    found = true;
                }
            }
            if (!found)
                fileUpdateDialog.Files.Add(new FileUpdate(fileUpdatePairs[e.FullPath], e.FullPath));
        }

        private void FileUpdateDialog_UpdateRequest(object sender, EventArgs e)
        {
            foreach (FileUpdate fupd in fileUpdateDialog.CheckedFiles)
                (ParentForm as MainForm).DoImportAttachment(fupd.Card, fupd.FilePath, false);
        }
    }

    enum PreviewType
    {
        None, File, Image
    }
}