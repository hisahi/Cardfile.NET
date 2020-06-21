namespace CardfileDotNet.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.toolBarTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cardCountLabel = new System.Windows.Forms.Label();
            this.viewModeLabel = new System.Windows.Forms.Label();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.leftRightControl = new CardfileDotNet.UI.LeftRightControl();
            this.fileToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.fileNewToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.fileOpenToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.fileSaveToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.fileSaveAsToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.filePrintToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.filePrintAllToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.filePrintPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filePageSetupToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.fileMergeToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editUndoToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editRedoToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editCutToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editCopyToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editPasteToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editIndexToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editRestoreToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editShowFileToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editImportFileToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.editExportFileToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.editOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.viewCardToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.viewEditToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.viewFileToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.viewListToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.cardToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.cardAddToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.cardDeleteToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.cardDuplicateToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.searchToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.searchGoToToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.searchFindToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.searchFindNextToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.helpToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.helpOnlineToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.helpAboutToolStripMenuItem = new CardfileDotNet.UI.BindableToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolBarTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.cardToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // viewPanel
            // 
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 54);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(800, 396);
            this.viewPanel.TabIndex = 2;
            // 
            // toolBarTableLayoutPanel
            // 
            this.toolBarTableLayoutPanel.ColumnCount = 3;
            this.toolBarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.toolBarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.toolBarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.toolBarTableLayoutPanel.Controls.Add(this.cardCountLabel, 2, 0);
            this.toolBarTableLayoutPanel.Controls.Add(this.leftRightControl, 1, 0);
            this.toolBarTableLayoutPanel.Controls.Add(this.viewModeLabel, 0, 0);
            this.toolBarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.toolBarTableLayoutPanel.Name = "toolBarTableLayoutPanel";
            this.toolBarTableLayoutPanel.RowCount = 1;
            this.toolBarTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolBarTableLayoutPanel.Size = new System.Drawing.Size(800, 30);
            this.toolBarTableLayoutPanel.TabIndex = 0;
            // 
            // cardCountLabel
            // 
            this.cardCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardCountLabel.Location = new System.Drawing.Point(420, 0);
            this.cardCountLabel.Name = "cardCountLabel";
            this.cardCountLabel.Size = new System.Drawing.Size(377, 30);
            this.cardCountLabel.TabIndex = 2;
            this.cardCountLabel.Text = "0 Cards";
            this.cardCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewModeLabel
            // 
            this.viewModeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewModeLabel.Location = new System.Drawing.Point(3, 0);
            this.viewModeLabel.Name = "viewModeLabel";
            this.viewModeLabel.Size = new System.Drawing.Size(377, 30);
            this.viewModeLabel.TabIndex = 1;
            this.viewModeLabel.Text = "Card View";
            this.viewModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.ShowIcon = false;
            this.printPreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // leftRightControl
            // 
            this.leftRightControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftRightControl.Location = new System.Drawing.Point(386, 3);
            this.leftRightControl.MaximumSize = new System.Drawing.Size(34, 9999);
            this.leftRightControl.MinimumSize = new System.Drawing.Size(34, 0);
            this.leftRightControl.Name = "leftRightControl";
            this.leftRightControl.Size = new System.Drawing.Size(34, 24);
            this.leftRightControl.TabIndex = 0;
            this.leftRightControl.LeftButton += new System.EventHandler(this.leftRightControl_LeftButton);
            this.leftRightControl.RightButton += new System.EventHandler(this.leftRightControl_RightButton);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNewToolStripMenuItem,
            this.fileOpenToolStripMenuItem,
            this.fileSaveToolStripMenuItem,
            this.fileSaveAsToolStripMenuItem,
            this.filePrintToolStripMenuItem,
            this.filePrintAllToolStripMenuItem,
            this.filePrintPreviewToolStripMenuItem,
            this.filePageSetupToolStripMenuItem,
            this.fileMergeToolStripMenuItem,
            this.toolStripSeparator1,
            this.fileExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Tag = "Localizable:Text";
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // fileNewToolStripMenuItem
            // 
            this.fileNewToolStripMenuItem.Name = "fileNewToolStripMenuItem";
            this.fileNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.fileNewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.fileNewToolStripMenuItem.Tag = "Localizable:Text";
            this.fileNewToolStripMenuItem.Text = "&New";
            this.fileNewToolStripMenuItem.Click += new System.EventHandler(this.fileNewToolStripMenuItem_Click);
            // 
            // fileOpenToolStripMenuItem
            // 
            this.fileOpenToolStripMenuItem.Name = "fileOpenToolStripMenuItem";
            this.fileOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.fileOpenToolStripMenuItem.Tag = "Localizable:Text";
            this.fileOpenToolStripMenuItem.Text = "&Open...";
            this.fileOpenToolStripMenuItem.Click += new System.EventHandler(this.fileOpenToolStripMenuItem_Click);
            // 
            // fileSaveToolStripMenuItem
            // 
            this.fileSaveToolStripMenuItem.Name = "fileSaveToolStripMenuItem";
            this.fileSaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileSaveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.fileSaveToolStripMenuItem.Tag = "Localizable:Text";
            this.fileSaveToolStripMenuItem.Text = "&Save";
            this.fileSaveToolStripMenuItem.Click += new System.EventHandler(this.fileSaveToolStripMenuItem_Click);
            // 
            // fileSaveAsToolStripMenuItem
            // 
            this.fileSaveAsToolStripMenuItem.Name = "fileSaveAsToolStripMenuItem";
            this.fileSaveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.fileSaveAsToolStripMenuItem.Tag = "Localizable:Text";
            this.fileSaveAsToolStripMenuItem.Text = "Save &As...";
            this.fileSaveAsToolStripMenuItem.Click += new System.EventHandler(this.fileSaveAsToolStripMenuItem_Click);
            // 
            // filePrintToolStripMenuItem
            // 
            this.filePrintToolStripMenuItem.Name = "filePrintToolStripMenuItem";
            this.filePrintToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.filePrintToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.filePrintToolStripMenuItem.Tag = "Localizable:Text";
            this.filePrintToolStripMenuItem.Text = "&Print";
            this.filePrintToolStripMenuItem.Click += new System.EventHandler(this.filePrintToolStripMenuItem_Click);
            // 
            // filePrintAllToolStripMenuItem
            // 
            this.filePrintAllToolStripMenuItem.Name = "filePrintAllToolStripMenuItem";
            this.filePrintAllToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.filePrintAllToolStripMenuItem.Tag = "Localizable:Text";
            this.filePrintAllToolStripMenuItem.Text = "Print A&ll...";
            this.filePrintAllToolStripMenuItem.Click += new System.EventHandler(this.filePrintAllToolStripMenuItem_Click);
            // 
            // filePrintPreviewToolStripMenuItem
            // 
            this.filePrintPreviewToolStripMenuItem.Name = "filePrintPreviewToolStripMenuItem";
            this.filePrintPreviewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.filePrintPreviewToolStripMenuItem.Tag = "Localizable:Text";
            this.filePrintPreviewToolStripMenuItem.Text = "Print Previe&w";
            this.filePrintPreviewToolStripMenuItem.Click += new System.EventHandler(this.filePrintPreviewToolStripMenuItem_Click);
            // 
            // filePageSetupToolStripMenuItem
            // 
            this.filePageSetupToolStripMenuItem.Name = "filePageSetupToolStripMenuItem";
            this.filePageSetupToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.filePageSetupToolStripMenuItem.Tag = "Localizable:Text";
            this.filePageSetupToolStripMenuItem.Text = "Page Se&tup";
            this.filePageSetupToolStripMenuItem.Click += new System.EventHandler(this.filePageSetupToolStripMenuItem_Click);
            // 
            // fileMergeToolStripMenuItem
            // 
            this.fileMergeToolStripMenuItem.Name = "fileMergeToolStripMenuItem";
            this.fileMergeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.fileMergeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.fileMergeToolStripMenuItem.Tag = "Localizable:Text";
            this.fileMergeToolStripMenuItem.Text = "&Merge...";
            this.fileMergeToolStripMenuItem.Click += new System.EventHandler(this.fileMergeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // fileExitToolStripMenuItem
            // 
            this.fileExitToolStripMenuItem.Name = "fileExitToolStripMenuItem";
            this.fileExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.fileExitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.fileExitToolStripMenuItem.Tag = "Localizable:Text";
            this.fileExitToolStripMenuItem.Text = "E&xit";
            this.fileExitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editUndoToolStripMenuItem,
            this.editRedoToolStripMenuItem,
            this.toolStripSeparator2,
            this.editCutToolStripMenuItem,
            this.editCopyToolStripMenuItem,
            this.editPasteToolStripMenuItem,
            this.editIndexToolStripMenuItem,
            this.editRestoreToolStripMenuItem,
            this.toolStripSeparator3,
            this.editShowFileToolStripMenuItem,
            this.editImportFileToolStripMenuItem,
            this.editExportFileToolStripMenuItem,
            this.toolStripSeparator5,
            this.editOptionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Tag = "Localizable:Text";
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // editUndoToolStripMenuItem
            // 
            this.editUndoToolStripMenuItem.Name = "editUndoToolStripMenuItem";
            this.editUndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.editUndoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editUndoToolStripMenuItem.Tag = "Localizable:Text";
            this.editUndoToolStripMenuItem.Text = "&Undo";
            this.editUndoToolStripMenuItem.Click += new System.EventHandler(this.editUndoToolStripMenuItem_Click);
            // 
            // editRedoToolStripMenuItem
            // 
            this.editRedoToolStripMenuItem.Name = "editRedoToolStripMenuItem";
            this.editRedoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.editRedoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editRedoToolStripMenuItem.Tag = "Localizable:Text";
            this.editRedoToolStripMenuItem.Text = "Redo";
            this.editRedoToolStripMenuItem.Click += new System.EventHandler(this.editRedoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // editCutToolStripMenuItem
            // 
            this.editCutToolStripMenuItem.Name = "editCutToolStripMenuItem";
            this.editCutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.editCutToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editCutToolStripMenuItem.Tag = "Localizable:Text";
            this.editCutToolStripMenuItem.Text = "&Cut";
            this.editCutToolStripMenuItem.Click += new System.EventHandler(this.editCutToolStripMenuItem_Click);
            // 
            // editCopyToolStripMenuItem
            // 
            this.editCopyToolStripMenuItem.Name = "editCopyToolStripMenuItem";
            this.editCopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.editCopyToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editCopyToolStripMenuItem.Tag = "Localizable:Text";
            this.editCopyToolStripMenuItem.Text = "&Copy";
            this.editCopyToolStripMenuItem.Click += new System.EventHandler(this.editCopyToolStripMenuItem_Click);
            // 
            // editPasteToolStripMenuItem
            // 
            this.editPasteToolStripMenuItem.Name = "editPasteToolStripMenuItem";
            this.editPasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.editPasteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editPasteToolStripMenuItem.Tag = "Localizable:Text";
            this.editPasteToolStripMenuItem.Text = "&Paste";
            this.editPasteToolStripMenuItem.Click += new System.EventHandler(this.editPasteToolStripMenuItem_Click);
            // 
            // editIndexToolStripMenuItem
            // 
            this.editIndexToolStripMenuItem.Name = "editIndexToolStripMenuItem";
            this.editIndexToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.editIndexToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editIndexToolStripMenuItem.Tag = "Localizable:Text";
            this.editIndexToolStripMenuItem.Text = "&Index...";
            this.editIndexToolStripMenuItem.Click += new System.EventHandler(this.editIndexToolStripMenuItem_Click);
            // 
            // editRestoreToolStripMenuItem
            // 
            this.editRestoreToolStripMenuItem.Name = "editRestoreToolStripMenuItem";
            this.editRestoreToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editRestoreToolStripMenuItem.Tag = "Localizable:Text";
            this.editRestoreToolStripMenuItem.Text = "&Restore";
            this.editRestoreToolStripMenuItem.Click += new System.EventHandler(this.editRestoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // editShowFileToolStripMenuItem
            // 
            this.editShowFileToolStripMenuItem.Name = "editShowFileToolStripMenuItem";
            this.editShowFileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.editShowFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editShowFileToolStripMenuItem.Tag = "Localizable:Text";
            this.editShowFileToolStripMenuItem.Text = "&Show Attachment";
            this.editShowFileToolStripMenuItem.Click += new System.EventHandler(this.editShowFileToolStripMenuItem_Click);
            // 
            // editImportFileToolStripMenuItem
            // 
            this.editImportFileToolStripMenuItem.Name = "editImportFileToolStripMenuItem";
            this.editImportFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editImportFileToolStripMenuItem.Tag = "Localizable:Text";
            this.editImportFileToolStripMenuItem.Text = "I&mport Attachment...";
            this.editImportFileToolStripMenuItem.Click += new System.EventHandler(this.editImportFileToolStripMenuItem_Click);
            // 
            // editExportFileToolStripMenuItem
            // 
            this.editExportFileToolStripMenuItem.Name = "editExportFileToolStripMenuItem";
            this.editExportFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editExportFileToolStripMenuItem.Tag = "Localizable:Text";
            this.editExportFileToolStripMenuItem.Text = "E&xport Attachment...";
            this.editExportFileToolStripMenuItem.Click += new System.EventHandler(this.editExportFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(185, 6);
            // 
            // editOptionsToolStripMenuItem
            // 
            this.editOptionsToolStripMenuItem.Name = "editOptionsToolStripMenuItem";
            this.editOptionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editOptionsToolStripMenuItem.Tag = "Localizable:Text";
            this.editOptionsToolStripMenuItem.Text = "&Options...";
            this.editOptionsToolStripMenuItem.Click += new System.EventHandler(this.editOptionsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCardToolStripMenuItem,
            this.viewEditToolStripMenuItem,
            this.viewFileToolStripMenuItem,
            this.viewListToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Tag = "Localizable:Text";
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // viewCardToolStripMenuItem
            // 
            this.viewCardToolStripMenuItem.CheckOnClick = true;
            this.viewCardToolStripMenuItem.Name = "viewCardToolStripMenuItem";
            this.viewCardToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.viewCardToolStripMenuItem.Tag = "Localizable:Text";
            this.viewCardToolStripMenuItem.Text = "&Card";
            // 
            // viewEditToolStripMenuItem
            // 
            this.viewEditToolStripMenuItem.CheckOnClick = true;
            this.viewEditToolStripMenuItem.Name = "viewEditToolStripMenuItem";
            this.viewEditToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.viewEditToolStripMenuItem.Tag = "Localizable:Text";
            this.viewEditToolStripMenuItem.Text = "&Edit";
            // 
            // viewFileToolStripMenuItem
            // 
            this.viewFileToolStripMenuItem.CheckOnClick = true;
            this.viewFileToolStripMenuItem.Name = "viewFileToolStripMenuItem";
            this.viewFileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.viewFileToolStripMenuItem.Tag = "Localizable:Text";
            this.viewFileToolStripMenuItem.Text = "&Attachment";
            // 
            // viewListToolStripMenuItem
            // 
            this.viewListToolStripMenuItem.CheckOnClick = true;
            this.viewListToolStripMenuItem.Name = "viewListToolStripMenuItem";
            this.viewListToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.viewListToolStripMenuItem.Tag = "Localizable:Text";
            this.viewListToolStripMenuItem.Text = "&List";
            // 
            // cardToolStripMenuItem
            // 
            this.cardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cardAddToolStripMenuItem,
            this.cardDeleteToolStripMenuItem,
            this.cardDuplicateToolStripMenuItem});
            this.cardToolStripMenuItem.Name = "cardToolStripMenuItem";
            this.cardToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.cardToolStripMenuItem.Tag = "Localizable:Text";
            this.cardToolStripMenuItem.Text = "&Card";
            // 
            // cardAddToolStripMenuItem
            // 
            this.cardAddToolStripMenuItem.Name = "cardAddToolStripMenuItem";
            this.cardAddToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.cardAddToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cardAddToolStripMenuItem.Tag = "Localizable:Text";
            this.cardAddToolStripMenuItem.Text = "&Add";
            this.cardAddToolStripMenuItem.Click += new System.EventHandler(this.cardAddToolStripMenuItem_Click);
            // 
            // cardDeleteToolStripMenuItem
            // 
            this.cardDeleteToolStripMenuItem.Name = "cardDeleteToolStripMenuItem";
            this.cardDeleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cardDeleteToolStripMenuItem.Tag = "Localizable:Text";
            this.cardDeleteToolStripMenuItem.Text = "&Delete";
            this.cardDeleteToolStripMenuItem.Click += new System.EventHandler(this.cardDeleteToolStripMenuItem_Click);
            // 
            // cardDuplicateToolStripMenuItem
            // 
            this.cardDuplicateToolStripMenuItem.Name = "cardDuplicateToolStripMenuItem";
            this.cardDuplicateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cardDuplicateToolStripMenuItem.Tag = "Localizable:Text";
            this.cardDuplicateToolStripMenuItem.Text = "Du&plicate";
            this.cardDuplicateToolStripMenuItem.Click += new System.EventHandler(this.cardDuplicateToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchGoToToolStripMenuItem,
            this.searchFindToolStripMenuItem,
            this.searchFindNextToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Tag = "Localizable:Text";
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // searchGoToToolStripMenuItem
            // 
            this.searchGoToToolStripMenuItem.Name = "searchGoToToolStripMenuItem";
            this.searchGoToToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.searchGoToToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.searchGoToToolStripMenuItem.Tag = "Localizable:Text";
            this.searchGoToToolStripMenuItem.Text = "&Go To...";
            this.searchGoToToolStripMenuItem.Click += new System.EventHandler(this.searchGoToToolStripMenuItem_Click);
            // 
            // searchFindToolStripMenuItem
            // 
            this.searchFindToolStripMenuItem.Name = "searchFindToolStripMenuItem";
            this.searchFindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchFindToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.searchFindToolStripMenuItem.Tag = "Localizable:Text";
            this.searchFindToolStripMenuItem.Text = "&Find...";
            this.searchFindToolStripMenuItem.Click += new System.EventHandler(this.searchFindToolStripMenuItem_Click);
            // 
            // searchFindNextToolStripMenuItem
            // 
            this.searchFindNextToolStripMenuItem.Name = "searchFindNextToolStripMenuItem";
            this.searchFindNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.searchFindNextToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.searchFindNextToolStripMenuItem.Tag = "Localizable:Text";
            this.searchFindNextToolStripMenuItem.Text = "Find &Next";
            this.searchFindNextToolStripMenuItem.Click += new System.EventHandler(this.searchFindNextToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpOnlineToolStripMenuItem,
            this.toolStripSeparator4,
            this.helpAboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Tag = "Localizable:Text";
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpOnlineToolStripMenuItem
            // 
            this.helpOnlineToolStripMenuItem.Name = "helpOnlineToolStripMenuItem";
            this.helpOnlineToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpOnlineToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.helpOnlineToolStripMenuItem.Tag = "Localizable:Text";
            this.helpOnlineToolStripMenuItem.Text = "&Help (Online)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // helpAboutToolStripMenuItem
            // 
            this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
            this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.helpAboutToolStripMenuItem.Tag = "Localizable:Text";
            this.helpAboutToolStripMenuItem.Text = "&About";
            this.helpAboutToolStripMenuItem.Click += new System.EventHandler(this.helpAboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.toolBarTableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = global::CardfileDotNet.Properties.Resources.cardfile;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Cardfile.NET";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolBarTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private CardfileDotNet.UI.BindableToolStripMenuItem fileToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem viewToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem cardToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem searchToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.TableLayoutPanel toolBarTableLayoutPanel;
        private System.Windows.Forms.Label cardCountLabel;
        private CardfileDotNet.UI.LeftRightControl leftRightControl;
        private System.Windows.Forms.Label viewModeLabel;
        private CardfileDotNet.UI.BindableToolStripMenuItem fileNewToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem fileOpenToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem fileSaveToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem fileSaveAsToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem filePrintToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem filePrintAllToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem filePageSetupToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem fileMergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private CardfileDotNet.UI.BindableToolStripMenuItem fileExitToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editUndoToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editRedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private CardfileDotNet.UI.BindableToolStripMenuItem editCutToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editCopyToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editPasteToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editIndexToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private CardfileDotNet.UI.BindableToolStripMenuItem editShowFileToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editImportFileToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem editExportFileToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem viewCardToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem viewEditToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem viewListToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem cardAddToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem cardDeleteToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem cardDuplicateToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem searchGoToToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem searchFindToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem searchFindNextToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem helpOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private CardfileDotNet.UI.BindableToolStripMenuItem helpAboutToolStripMenuItem;
        private CardfileDotNet.UI.BindableToolStripMenuItem viewFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem editOptionsToolStripMenuItem;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripMenuItem filePrintPreviewToolStripMenuItem;
    }
}