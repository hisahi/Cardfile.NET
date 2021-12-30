using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using CardfileDotNet.Properties;
using CardfileDotNet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class MainForm : Form
    {
        private const int LargeFileSizeLimit = 16 * (1 << 20); // 16 MiB

        public WindowState State { get; }
        internal IndexDialog indexDialog;
        internal OptionsDialog optionsDialog;
        internal GoToDialog goToDialog;
        internal CustomPageSetupDialog customPageSetupDialog;
        internal Dictionary<ViewMode, ViewInfo> views;
        private Dictionary<Cardfile, SearchDialog> openSearchDialogs;
        private Cardfile searchFile;
        private OpenFileDialog openDialog;
        private SaveFileDialog saveDialog;
        private OpenFileDialog importAttachmentDialog;
        private SaveFileDialog exportAttachmentDialog;
        private RichTextBox findRtfBox;
        private PrintDocument printDocument;
        private CardPrinter cardPrinter;
        private KeysConverter kcvt = new KeysConverter();

        public MainForm()
        {
            InitializeComponent();
            Settings.Default.Reload();

            State = new WindowState(this);
            views = new Dictionary<ViewMode, ViewInfo>()
            {
                { ViewMode.Card, new ViewInfo("CardView", new CardViewUserControl(State)) },
                { ViewMode.Edit, new ViewInfo("EditView", new EditViewUserControl(State)) },
                { ViewMode.File, new ViewInfo("AttachmentView", new FileViewUserControl(State)) },
                { ViewMode.List, new ViewInfo("ListView", new ListViewUserControl(State)) }
            };
            NewFile();

            Language.LanguageChanged += Localization_LanguageChanged;
            State.PropertyChanged += State_PropertyChanged;
            State.FileClosed += State_FileClosed;
            AddBindings();
            foreach (ViewInfo uc in views.Values)
            {
                uc.Control.Visible = false;
                uc.Control.Dock = DockStyle.Fill;
                viewPanel.Controls.Add(uc.Control);
            }

            indexDialog = new IndexDialog();
            optionsDialog = new OptionsDialog();
            goToDialog = new GoToDialog();
            customPageSetupDialog = new CustomPageSetupDialog();
            openSearchDialogs = new Dictionary<Cardfile, SearchDialog>();
            searchFile = null;
            openDialog = new OpenFileDialog();
            saveDialog = new SaveFileDialog();
            importAttachmentDialog = new OpenFileDialog();
            exportAttachmentDialog = new SaveFileDialog();
            openDialog.FileName = "";
            saveDialog.FileName = "";
            importAttachmentDialog.FileName = "";
            saveDialog.Title = Language.GetMenuText("fileSaveAsToolStripMenuItem.Text");
            findRtfBox = new RichTextBox();

            printDocument = new PrintDocument();
            printPreviewDialog.Document = printDocument;
            pageSetupDialog.Document = printDocument;
            printDocument.BeginPrint += PrintDocument_BeginPrint;
            printDocument.PrintPage += PrintDocument_PrintPage;
            customPageSetupDialog.DefaultDialog = pageSetupDialog;

            ApplySettings();
            State.BindFile(GotFile);
            cardPrinter = new CardPrinter(State, false);
        }

        #region Standard handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            var c = views[ViewMode.Card].Control as CardViewUserControl;
            c.Select();
            c.FocusIndexBox();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmUnsaved())
                e.Cancel = true;
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            Commit();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Commit();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (State.ViewMode != ViewMode.List)
            {
                if (keyData == Keys.PageUp)
                {
                    State.File.PreviousCard();
                    return true;
                }
                if (keyData == Keys.PageDown)
                {
                    State.File.NextCard();
                    return true;
                }
            }
            if (keyData == (Keys.Control | Keys.Home))
            {
                if (State.File.CardCount > 0)
                    State.File.FrontIndex = 0;
                return true;
            }
            if (keyData == (Keys.Control | Keys.End))
            {
                if (State.File.CardCount > 0)
                    State.File.FrontIndex = State.File.CardCount - 1;
                return true;
            }
            if ((keyData & (Keys.Control | Keys.Shift | Keys.Alt)) == (Keys.Control | Keys.Shift) && GetCharacterFromKey(keyData) != null)
            {
                if (State.File.CardCount > 0)
                {
                    char c = (char)GetCharacterFromKey(keyData);
                    string cs = "" + c;
                    bool found = false;
                    int front = State.File.FrontIndex;
                    int index;
                    for (int i = 1; i <= State.File.CardCount; ++i)
                    {
                        index = (front + i) % State.File.CardCount;
                        if (State.File.Cards[index].Index.StartsWith(cs, StringComparison.CurrentCultureIgnoreCase))
                        {
                            State.File.FrontIndex = index;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        SystemSounds.Beep.Play();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private char? GetCharacterFromKey(Keys key)
        {
            if (MapVirtualKey((uint)key, 2) != 0)   // ignore if Ctrl+Shift+key actually is an input key
                return null;
            Keys noMod = key & Keys.KeyCode;
            if (keysToChar.ContainsKey(noMod))
                return keysToChar[noMod];
            uint unshifted = MapVirtualKey((uint)key, 2);
            if (unshifted != 0)
                return Convert.ToChar(unshifted);
            return null;
        }

        #region Dictionary and extern for preceding function
        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private static Dictionary<Keys, char> keysToChar = new Dictionary<Keys, char>()
        {
            { Keys.A, 'A' },
            { Keys.B, 'B' },
            { Keys.C, 'C' },
            { Keys.D, 'D' },
            { Keys.E, 'E' },
            { Keys.F, 'F' },
            { Keys.G, 'G' },
            { Keys.H, 'H' },
            { Keys.I, 'I' },
            { Keys.J, 'J' },
            { Keys.K, 'K' },
            { Keys.L, 'L' },
            { Keys.M, 'M' },
            { Keys.N, 'N' },
            { Keys.O, 'O' },
            { Keys.P, 'P' },
            { Keys.Q, 'Q' },
            { Keys.R, 'R' },
            { Keys.S, 'S' },
            { Keys.T, 'T' },
            { Keys.U, 'U' },
            { Keys.V, 'V' },
            { Keys.W, 'W' },
            { Keys.X, 'X' },
            { Keys.Y, 'Y' },
            { Keys.Z, 'Z' },
            { Keys.D0, '0' },
            { Keys.D1, '1' },
            { Keys.D2, '2' },
            { Keys.D3, '3' },
            { Keys.D4, '4' },
            { Keys.D5, '5' },
            { Keys.D6, '6' },
            { Keys.D7, '7' },
            { Keys.D8, '8' },
            { Keys.D9, '9' }
        };
        #endregion

        #endregion

        #region File code

        private void NewFile()
        {
            State.File = Cardfile.NewFile();
        }

        private bool TryOpen(out string path, out FileFormat fmt)
        {
            openDialog.Filter = Language.Get("OpenFilter", "Cardfile.NET file (*.CRDX)|*.CRDX|Classic Card File (*.CRD)|*.CRD|All files (*.*)|*");
            DialogResult result = openDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = openDialog.FileName;
                switch (openDialog.FilterIndex)
                {
                    case 1:
                        fmt = FileFormat.CRDX;
                        break;
                    case 2:
                        fmt = FileFormat.CRD;
                        break;
                    default:
                        if (Path.GetExtension(path).Equals(".CRD", StringComparison.InvariantCultureIgnoreCase))
                            fmt = FileFormat.CRD;
                        else
                            fmt = FileFormat.CRDX;
                        break;
                }
                return true;
            }
            path = null;
            fmt = default;
            return false;
        }

        private bool TrySaveAs()
        {
            saveDialog.Filter = Language.Get("SaveFilter", "Cardfile.NET file, compressed (*.CRDX)|*.CRDX|Cardfile.NET file (*.CRDX)|*.CRDX|All files (*.*)|*");
            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                State.File.Save(saveDialog.FileName, saveDialog.FilterIndex == 1);
                return true;
            }
            return false;
        }

        private bool TrySave()
        {
            if (!State.File.CanSaveBack || State.File.FilePath == null)
                return TrySaveAs();
            else
            {
                State.File.Save();
                return true;
            }
        }

        internal bool DoImportAttachment(Card card, string filePath, bool displaySizeWarning)
        {
            try
            {
                if (displaySizeWarning && new System.IO.FileInfo(filePath).Length > LargeFileSizeLimit)
                {
                    if (MessageBox.Show(
                            this,
                            Language.Get("LargeAttachment", "The selected file is large. Attached files should generally be small files.\nUsing large files will increase disk and memory usage.\n\nContinue?"),
                            this.ProgramName,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return false;
                }
                UseWaitCursor = true;
                card.Attachment = new AttachmentFile(Path.GetFileName(filePath), MimeTypeDetector.DetectMime(filePath), File.ReadAllBytes(filePath));
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show(
                    this,
                    Language.Get("CannotImportAttachment", "An error occurred while importing the attachment. Make sure you have access to the file you are trying to import."),
                    this.ProgramName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        internal bool TryImportAttachment()
        {
            importAttachmentDialog.Filter = Language.Get("ImportAttachmentFilter", "All files (*.*)|*");
            DialogResult result = importAttachmentDialog.ShowDialog();
            return result == DialogResult.OK && DoImportAttachment(State.File.FrontCard, importAttachmentDialog.FileName, true);
        }

        internal bool TryExportAttachment()
        {
            if (State.File.FrontCard.Attachment != null)
            {
                AttachmentFile attachment = State.File.FrontCard.Attachment;
                string ext = Path.GetExtension(attachment.Name);
                if (ext != "")
                {
                    exportAttachmentDialog.Filter = string.Format(
                        Language.Get("ExportAttachmentFilter", "{1} (*.{0})|*.{0}|All files (*.*)|*"),
                        ext,
                        Win32Util.GetFileDescription(ext) ?? string.Format(Language.Get("UnknownExtension", "{0} File"), ext));
                }
                else
                {
                    exportAttachmentDialog.Filter = Language.Get("ExportAttachmentFilterNoExt", "All files (*.*)|*");
                }
                exportAttachmentDialog.FileName = attachment.Name;
                DialogResult result = exportAttachmentDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = exportAttachmentDialog.FileName;
                    try
                    {
                        UseWaitCursor = true;
                        File.WriteAllBytes(filePath, attachment.Data);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(
                            this,
                            Language.Get("CannotExportAttachment", "An error occurred while exporting the attachment. Make sure the file is not read-only and that you have sufficient disk space."),
                            this.ProgramName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                    }
                    finally
                    {
                        UseWaitCursor = false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool ConfirmUnsaved()
        {
            if (!State.File.Unsaved)
                return true;
            var result = MessageBox.Show(
                this,
                ((State.File.FilePath ?? "") + "\n" + Language.Get("FileUnsaved", "This file has been changed.\nSave the changes?")).Trim(),
                this.ProgramName,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                return TrySave();
            return result == DialogResult.No;
        }

        private void GotFile(Cardfile file)
        {
            // only one file / search box for now
            if (searchFile != null)
            {
                openSearchDialogs[file] = openSearchDialogs[searchFile];
                openSearchDialogs[file].Cardfile = file;
                openSearchDialogs.Remove(searchFile);
            }

            UpdateTitle();
            UpdateCardCountLabel();
            file.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "CardCount")
                    UpdateCardCountLabel();
                if (e.PropertyName == "FrontIndex")
                    UpdateCardCountLabel();
                if (e.PropertyName == "Unsaved" || e.PropertyName == "FilePath")
                    UpdateTitle();
            };
        }

        private void State_FileClosed(object sender, FileClosedEventArgs e)
        {
            if (openSearchDialogs.ContainsKey(e.File))
                openSearchDialogs[e.File].Close();
        }

        private void Commit()
        {
            if (views[State.ViewMode].Control is ICommitable ic)
                ic.Commit();
        }

        #endregion

        #region Views code

        private void OnViewModeChanged()
        {
            foreach (KeyValuePair<ViewMode, ViewInfo> item in views)
                item.Value.Control.Visible = State.ViewMode == item.Key;
            viewModeLabel.Text = Language.Get(views[State.ViewMode].Key);
        }

        private void State_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ViewMode")
                OnViewModeChanged();
        }

        #endregion

        #region Option, localization & text code

        private void UpdateCardCountLabel()
        {
            cardCountLabel.Text = string.Format(Language.GetCardinalNumber("CardCount", "{1} Cards", State.File.CardCount), State.File.FrontIndex + 1, State.File.CardCount);
        }

        private string ProgramName => Language.Get("ProgramName", "Cardfile.NET");

        public static string Version
        {
            get => AssemblyName.GetAssemblyName(System.Reflection.Assembly.GetExecutingAssembly().Location).Version.ToString();
        }

        private void UpdateTitle()
        {
            string title = ProgramName;

            string fileHeader = State.File.FilePath ?? "";
            if (fileHeader != "")
                title = String.Format(Language.Get("TitleFormat", "{0} - {1}"), Path.GetFileName(fileHeader), ProgramName);

            this.Text = (State.File.Unsaved ? "*" : "") + title;
        }

        public void Localize()
        {
            Language.LocalizeControls(this, new Control[] { viewPanel });
            foreach (ViewInfo uc in views.Values)
                uc.Control.Localize();
            indexDialog.Localize();
            optionsDialog.Localize();
            goToDialog.Localize();
            customPageSetupDialog.Localize();
            foreach (SearchDialog dialog in openSearchDialogs.Values)
                dialog.Localize();
        }

        private void Localization_LanguageChanged(object sender, EventArgs e)
        {
            this.Localize();
        }

        private void ApplySettings()
        {
            Language.SetLanguage(Settings.Default.Language);
            OnViewModeChanged();
            UpdateTitle();
            UpdateCardCountLabel();
        }

        #endregion

        #region Find code

        private bool TryRtfFind(FindRequest req, Card card, bool fromStart)
        {
            findRtfBox.Rtf = card.Contents;
            RichTextBoxFinds finds = RichTextBoxFinds.None;
            if (req.MatchCase)
                finds |= RichTextBoxFinds.MatchCase;
            if (req.Direction == FindDirection.Backwards)
                finds |= RichTextBoxFinds.Reverse;
            if (fromStart)
                return findRtfBox.Find(req.Text, finds) >= 0;
            else
            {
                int start = findRtfBox.SelectionStart + (findRtfBox.SelectionLength > 0 ? (req.Direction == FindDirection.Backwards ? -1 : 1) : 0);
                int end = findRtfBox.TextLength;
                return findRtfBox.Find(req.Text, start, end, finds) >= start;
            }
        }

        private bool TryRtfFind(Cardfile file)
        {
            if (TryRtfFind(file.Find, file.FrontCard, false))
                return true;
            int front = State.File.FrontIndex;
            int index;
            StringComparison comp = file.Find.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
            for (int i = 1; i < file.CardCount; ++i)
            {
                if (file.Find.Direction == FindDirection.Forwards)
                    index = (front + i) % State.File.CardCount;
                else //if (file.Find.Direction == FindDirection.Backwards)
                    index = (front + State.File.CardCount - i) % State.File.CardCount;

                if (State.File.Cards[index].Text.IndexOf(file.Find.Text, comp) >= 0)
                {
                    if (TryRtfFind(file.Find, file.FrontCard, true))
                    {
                        State.File.FrontIndex = index;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DidFindNextWithBox(Cardfile file)
        {
            bool result;
            switch (State.ViewMode)
            {
                case ViewMode.Card:
                    var cardView = views[ViewMode.Card].Control as CardViewUserControl;
                    findRtfBox.Rtf = file.FrontCard.Contents;
                    findRtfBox.SelectionStart = cardView.ContentsSelectionStart;
                    findRtfBox.SelectionLength = cardView.ContentsSelectionLength;
                    result = TryRtfFind(file);
                    if (result) cardView.SelectText(findRtfBox.SelectionStart, findRtfBox.SelectionLength);
                    return result;
                case ViewMode.Edit:
                    var editView = views[ViewMode.Edit].Control as EditViewUserControl;
                    findRtfBox.Rtf = file.FrontCard.Contents;
                    findRtfBox.SelectionStart = editView.ContentsSelectionStart;
                    findRtfBox.SelectionLength = editView.ContentsSelectionLength;
                    result = TryRtfFind(file);
                    if (result) editView.SelectText(findRtfBox.SelectionStart, findRtfBox.SelectionLength);
                    return result;
            }
            return false; // cannot use this
        }

        private bool DidFindNext(Cardfile file)
        {
            int front = State.File.FrontIndex;
            int index;
            StringComparison comp = file.Find.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
            for (int i = 1; i < State.File.CardCount; ++i)
            {
                if (file.Find.Direction == FindDirection.Forwards)
                    index = (front + i) % State.File.CardCount;
                else //if (file.Find.Direction == FindDirection.Backwards)
                    index = (front + State.File.CardCount - i) % State.File.CardCount;

                if (State.File.Cards[index].Text.IndexOf(file.Find.Text, comp) >= 0)
                {
                    State.File.FrontIndex = index;
                    return true;
                }
            }
            return false;
        }

        private void TryFindNext(Form owner, Cardfile file)
        {
            if (DidFindNextWithBox(file))
            {
                this.Activate();
                return;
            }
            if (DidFindNext(file))
            {
                this.Activate();
                return;
            }

            MessageBox.Show(owner,
                    string.Format(Language.Get("CannotFind", "Cannot find \"{0}\"."), file.Find.Text),
                    this.ProgramName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void DoFind(SearchDialog searchDialog, Cardfile cardfile, FindRequest request)
        {
            cardfile.Find = request;
            TryFindNext(searchDialog, cardfile);
        }

        #endregion

        #region Printing code

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            cardPrinter.Reset();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            cardPrinter.PrintPage(this, e);
        }

        #endregion

        #region Bindings

        private void AddCheckedEnumBinding<T>(BindableToolStripMenuItem menuItem, object dataSource, string dataMember, T trueValue) where T : Enum
        {
            Binding binding = new Binding("Checked", dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += (s, e) => e.Value = ((T)e.Value).Equals(trueValue);
            binding.Parse += (s, e) => { if ((bool)e.Value) e.Value = trueValue; };
            menuItem.DataBindings.Add(binding);
        }

        public void AddBindings()
        {
            this.editUndoToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "CanUndo"));
            this.editRedoToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "CanRedo"));
            this.editCutToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "Editing"));
            this.editCopyToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "Editing"));
            this.editPasteToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "Editing"));
            this.editIndexToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "HasCards"));
            this.editRestoreToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "Editing"));
            this.editShowFileToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "HasCards"));
            this.editImportFileToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "HasCards"));
            this.editExportFileToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "CanExport"));
            this.searchFindNextToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "CanFindNext"));

            AddCheckedEnumBinding(this.viewCardToolStripMenuItem, State, "ViewMode", ViewMode.Card);
            AddCheckedEnumBinding(this.viewEditToolStripMenuItem, State, "ViewMode", ViewMode.Edit);
            AddCheckedEnumBinding(this.viewFileToolStripMenuItem, State, "ViewMode", ViewMode.File);
            AddCheckedEnumBinding(this.viewListToolStripMenuItem, State, "ViewMode", ViewMode.List);

            this.cardDeleteToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "HasCards"));
            this.cardDuplicateToolStripMenuItem.DataBindings.Add(new Binding("Enabled", State, "HasCards"));
        }

        #endregion

        #region Misc buttons

        private void leftRightControl_LeftButton(object sender, EventArgs e)
        {
            State.File.PreviousCard();
        }

        private void leftRightControl_RightButton(object sender, EventArgs e)
        {
            State.File.NextCard();
        }

        #endregion

        #region File menu

        private void fileNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (ConfirmUnsaved())
                NewFile();
        }

        private void fileOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (ConfirmUnsaved())
            {
                openDialog.Title = Language.GetMenuText("fileOpenToolStripMenuItem.Text");
                if (!TryOpen(out string path, out FileFormat fmt))
                    return;
                State.File = Cardfile.Open(path, fmt);
            }
        }

        private void fileSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            TrySave();
        }

        private void fileSaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            TrySaveAs();
        }

        private void fileMergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (ConfirmUnsaved())
            {
                openDialog.Title = Language.GetMenuText("fileMergeToolStripMenuItem.Text");
                if (!TryOpen(out string path, out FileFormat fmt))
                    return;
                State.File.Merge(path, fmt);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            this.Close();
        }

        private void filePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            cardPrinter = new CardPrinter(State, false);
            if (printDialog.ShowDialog(this) == DialogResult.OK)
                printDocument.Print();
        }

        private void filePrintAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            cardPrinter = new CardPrinter(State, true);
            if (printDialog.ShowDialog(this) == DialogResult.OK)
                printDocument.Print();
        }

        private void filePrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (cardPrinter == null)
                cardPrinter = new CardPrinter(State, false);
            printPreviewDialog.ShowDialog(this);
        }

        private void filePageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (customPageSetupDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.Save();
                ApplySettings();
                OptionHandler.OnOptionUpdate();
            }
            else
            {
                Settings.Default.Reload();
            }
        }

        #endregion

        #region Edit menu

        private void editUndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (State.CanUndo)
                State.File.Undo();
        }

        private void editRedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (State.CanRedo)
                State.File.Redo();
        }

        internal void OpenIndexDialog()
        {
            indexDialog.Value = State.File.FrontCard.Index;
            if (indexDialog.ShowDialog(this) == DialogResult.OK)
                State.File.FrontCard.Index = indexDialog.Value;
        }

        private void editCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            switch (State.ViewMode)
            {
                case ViewMode.Card:
                    (views[State.ViewMode].Control as CardViewUserControl).DoCut();
                    break;
                case ViewMode.Edit:
                    (views[State.ViewMode].Control as EditViewUserControl).DoCut();
                    break;
            }
        }

        private void editCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            switch (State.ViewMode)
            {
                case ViewMode.Card:
                    (views[State.ViewMode].Control as CardViewUserControl).DoCopy();
                    break;
                case ViewMode.Edit:
                    (views[State.ViewMode].Control as EditViewUserControl).DoCopy();
                    break;
            }
        }

        private void editPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            switch (State.ViewMode)
            {
                case ViewMode.Card:
                    (views[State.ViewMode].Control as CardViewUserControl).DoPaste();
                    break;
                case ViewMode.Edit:
                    (views[State.ViewMode].Control as EditViewUserControl).DoPaste();
                    break;
            }
        }

        private void editIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            switch (State.ViewMode)
            {
                case ViewMode.Card:
                    (views[State.ViewMode].Control as CardViewUserControl).FocusIndexBox();
                    break;
                case ViewMode.Edit:
                    (views[State.ViewMode].Control as EditViewUserControl).FocusIndexBox();
                    break;
                case ViewMode.File:
                case ViewMode.List:
                    OpenIndexDialog();
                    break;
            }
        }

        private void editRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            State.File.RestoreFrontCard();
        }

        private void editOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (optionsDialog.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.Save();
                ApplySettings();
                OptionHandler.OnOptionUpdate();
            }
            else
            {
                Settings.Default.Reload();
            }
        }

        private void editShowFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            State.ViewMode = ViewMode.File;
        }

        private void editImportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            State.ViewMode = ViewMode.File;
            TryImportAttachment();
        }

        private void editExportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            State.ViewMode = ViewMode.File;
            TryExportAttachment();
        }

        #endregion

        #region Card menu

        private void cardAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            switch (State.ViewMode)
            {
                case ViewMode.Card:
                    State.File.InsertCard(new Card(""));
                    State.File.NextCard();
                    (views[State.ViewMode].Control as CardViewUserControl).FocusIndexBox();
                    break;
                case ViewMode.Edit:
                    State.File.InsertCard(new Card(""));
                    State.File.NextCard();
                    (views[State.ViewMode].Control as EditViewUserControl).FocusIndexBox();
                    break;
                case ViewMode.File:
                case ViewMode.List:
                    indexDialog.Value = "";
                    if (indexDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        State.File.InsertCard(new Card(indexDialog.Value));
                        State.File.NextCard();
                    }
                    break;
            }
        }

        private void cardDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (State.HasCards)
                State.File.RemoveCardAt(State.File.FrontIndex);
        }

        private void cardDuplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (State.HasCards)
            {
                Commit();
                State.File.InsertCard(State.File.FrontCard.Clone() as Card);
            }
        }

        #endregion

        #region Search menu

        private void searchGoToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            if (goToDialog.ShowDialog(this) == DialogResult.OK)
            {
                int front = State.File.FrontIndex;
                int index;
                for (int i = 1; i <= State.File.CardCount; ++i)
                {
                    index = (front + i) % State.File.CardCount;
                    if (State.File.Cards[index].Index.StartsWith(goToDialog.Value, StringComparison.OrdinalIgnoreCase))
                    {
                        State.File.FrontIndex = index;
                        return;
                    }
                }

                MessageBox.Show(
                    this,
                    string.Format(Language.Get("NoSuchCard", "Card not found: \"{0}\"."), goToDialog.Value),
                    this.ProgramName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void searchFindToolStripMenuItem_Click(object sender, EventArgs _)
        {
            Commit();
            Cardfile file = State.File;
            if (openSearchDialogs.ContainsKey(file))
            {
                openSearchDialogs[file].Activate();
                return;
            }

            var searchDialog = new SearchDialog();
            openSearchDialogs[file] = searchDialog;
            searchDialog.Localize();
            searchDialog.Cardfile = file;
            searchDialog.StartPosition = FormStartPosition.CenterParent;
            searchDialog.Owner = this;
            searchDialog.Show(this);

            searchDialog.FindRequest += (s, e) => DoFind(s as SearchDialog, (s as SearchDialog).Cardfile, e.Request);
            searchDialog.FormClosed += (s, e) => openSearchDialogs.Remove(file);
        }

        private void searchFindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            TryFindNext(this, State.File);
        }

        #endregion

        #region Help menu

        private void helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commit();
            var dialog = new AboutDialog();
            dialog.Localize();
            dialog.ShowDialog(this);
        }

        #endregion
    }

    internal class ViewInfo
    {
        public string Key { get; }
        public LocalizableUserControl Control { get; }

        public ViewInfo(string name, LocalizableUserControl control)
        {
            this.Key = name;
            this.Control = control;
        }
    }
}
