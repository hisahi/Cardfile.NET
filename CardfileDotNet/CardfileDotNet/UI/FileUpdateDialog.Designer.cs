namespace CardfileDotNet.UI
{
    partial class FileUpdateDialog
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
            this.fileListView = new CardfileDotNet.UI.BindableListView();
            this.columnCardIndex = ((CardfileDotNet.UI.BindableColumnHeader)(new CardfileDotNet.UI.BindableColumnHeader()));
            this.columnCardFileName = ((CardfileDotNet.UI.BindableColumnHeader)(new CardfileDotNet.UI.BindableColumnHeader()));
            this.labelUpdateFiles = new System.Windows.Forms.Label();
            this.buttonFileCheckAll = new System.Windows.Forms.Button();
            this.buttonInvertCheck = new System.Windows.Forms.Button();
            this.buttonCheckNone = new System.Windows.Forms.Button();
            this.buttonFilesUpdate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileListView
            // 
            this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListView.CheckBoxes = true;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnCardIndex,
            this.columnCardFileName});
            this.fileListView.DataSource = null;
            this.fileListView.FullRowSelect = true;
            this.fileListView.HideSelection = false;
            this.fileListView.Location = new System.Drawing.Point(4, 72);
            this.fileListView.Name = "fileListView";
            this.fileListView.SelectedIndex = -1;
            this.fileListView.Size = new System.Drawing.Size(262, 301);
            this.fileListView.TabIndex = 1;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            // 
            // columnCardIndex
            // 
            this.columnCardIndex.Text = "Index";
            this.columnCardIndex.Width = 100;
            // 
            // columnCardFileName
            // 
            this.columnCardFileName.Text = "Name";
            this.columnCardFileName.Width = 400;
            // 
            // labelUpdateFiles
            // 
            this.labelUpdateFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUpdateFiles.Location = new System.Drawing.Point(4, 9);
            this.labelUpdateFiles.Name = "labelUpdateFiles";
            this.labelUpdateFiles.Size = new System.Drawing.Size(262, 60);
            this.labelUpdateFiles.TabIndex = 0;
            this.labelUpdateFiles.Tag = "Localizable:Text";
            this.labelUpdateFiles.Text = "The following attached files have been modified. You can select which files to up" +
    "date in the card file.";
            // 
            // buttonFileCheckAll
            // 
            this.buttonFileCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFileCheckAll.Location = new System.Drawing.Point(4, 379);
            this.buttonFileCheckAll.Name = "buttonFileCheckAll";
            this.buttonFileCheckAll.Size = new System.Drawing.Size(84, 23);
            this.buttonFileCheckAll.TabIndex = 2;
            this.buttonFileCheckAll.Tag = "Localizable:Text";
            this.buttonFileCheckAll.Text = "Check &All";
            this.buttonFileCheckAll.UseVisualStyleBackColor = true;
            this.buttonFileCheckAll.Click += new System.EventHandler(this.buttonFileCheckAll_Click);
            // 
            // buttonInvertCheck
            // 
            this.buttonInvertCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInvertCheck.Location = new System.Drawing.Point(182, 379);
            this.buttonInvertCheck.Name = "buttonInvertCheck";
            this.buttonInvertCheck.Size = new System.Drawing.Size(84, 23);
            this.buttonInvertCheck.TabIndex = 4;
            this.buttonInvertCheck.Tag = "Localizable:Text";
            this.buttonInvertCheck.Text = "&Invert";
            this.buttonInvertCheck.UseVisualStyleBackColor = true;
            this.buttonInvertCheck.Click += new System.EventHandler(this.buttonInvertCheck_Click);
            // 
            // buttonCheckNone
            // 
            this.buttonCheckNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCheckNone.Location = new System.Drawing.Point(93, 379);
            this.buttonCheckNone.Name = "buttonCheckNone";
            this.buttonCheckNone.Size = new System.Drawing.Size(84, 23);
            this.buttonCheckNone.TabIndex = 3;
            this.buttonCheckNone.Tag = "Localizable:Text";
            this.buttonCheckNone.Text = "Check &None";
            this.buttonCheckNone.UseVisualStyleBackColor = true;
            this.buttonCheckNone.Click += new System.EventHandler(this.buttonCheckNone_Click);
            // 
            // buttonFilesUpdate
            // 
            this.buttonFilesUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonFilesUpdate.Location = new System.Drawing.Point(51, 415);
            this.buttonFilesUpdate.Name = "buttonFilesUpdate";
            this.buttonFilesUpdate.Size = new System.Drawing.Size(80, 23);
            this.buttonFilesUpdate.TabIndex = 5;
            this.buttonFilesUpdate.Tag = "Localizable:Text";
            this.buttonFilesUpdate.Text = "&Update";
            this.buttonFilesUpdate.UseVisualStyleBackColor = true;
            this.buttonFilesUpdate.Click += new System.EventHandler(this.buttonFilesUpdate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.Location = new System.Drawing.Point(137, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Tag = "";
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FileUpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonFilesUpdate);
            this.Controls.Add(this.buttonCheckNone);
            this.Controls.Add(this.buttonInvertCheck);
            this.Controls.Add(this.buttonFileCheckAll);
            this.Controls.Add(this.labelUpdateFiles);
            this.Controls.Add(this.fileListView);
            this.Icon = global::CardfileDotNet.Properties.Resources.cardfile;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(284, 300);
            this.Name = "FileUpdateDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Localizable:Text";
            this.Text = "Update files";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileUpdateDialog_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FileUpdateDialog_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private BindableListView fileListView;
        private System.Windows.Forms.Label labelUpdateFiles;
        private System.Windows.Forms.Button buttonFileCheckAll;
        private System.Windows.Forms.Button buttonInvertCheck;
        private System.Windows.Forms.Button buttonCheckNone;
        private System.Windows.Forms.Button buttonFilesUpdate;
        private System.Windows.Forms.Button buttonCancel;
        private BindableColumnHeader columnCardIndex;
        private BindableColumnHeader columnCardFileName;
    }
}