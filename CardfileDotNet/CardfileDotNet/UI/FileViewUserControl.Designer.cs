namespace CardfileDotNet.UI
{
    partial class FileViewUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonImportAttachment = new System.Windows.Forms.Button();
            this.buttonExportAttachment = new System.Windows.Forms.Button();
            this.buttonOpenAttachment = new System.Windows.Forms.Button();
            this.buttonRemoveAttachment = new System.Windows.Forms.Button();
            this.panelFilePreview = new System.Windows.Forms.Panel();
            this.pictureBoxImagePreview = new System.Windows.Forms.PictureBox();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.iconImageList = new System.Windows.Forms.ImageList(this.components);
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.textBoxIndex = new System.Windows.Forms.TextBox();
            this.panelFilePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImportAttachment
            // 
            this.buttonImportAttachment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonImportAttachment.Location = new System.Drawing.Point(222, 3);
            this.buttonImportAttachment.Name = "buttonImportAttachment";
            this.buttonImportAttachment.Size = new System.Drawing.Size(75, 23);
            this.buttonImportAttachment.TabIndex = 0;
            this.buttonImportAttachment.Tag = "Localizable:Text";
            this.buttonImportAttachment.Text = "&Import...";
            this.buttonImportAttachment.UseVisualStyleBackColor = true;
            this.buttonImportAttachment.Click += new System.EventHandler(this.buttonImportAttachment_Click);
            // 
            // buttonExportAttachment
            // 
            this.buttonExportAttachment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonExportAttachment.Location = new System.Drawing.Point(303, 3);
            this.buttonExportAttachment.Name = "buttonExportAttachment";
            this.buttonExportAttachment.Size = new System.Drawing.Size(75, 23);
            this.buttonExportAttachment.TabIndex = 1;
            this.buttonExportAttachment.Tag = "Localizable:Text";
            this.buttonExportAttachment.Text = "&Export...";
            this.buttonExportAttachment.UseVisualStyleBackColor = true;
            this.buttonExportAttachment.Click += new System.EventHandler(this.buttonExportAttachment_Click);
            // 
            // buttonOpenAttachment
            // 
            this.buttonOpenAttachment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonOpenAttachment.Location = new System.Drawing.Point(141, 3);
            this.buttonOpenAttachment.Name = "buttonOpenAttachment";
            this.buttonOpenAttachment.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenAttachment.TabIndex = 2;
            this.buttonOpenAttachment.Tag = "Localizable:Text";
            this.buttonOpenAttachment.Text = "&Open";
            this.buttonOpenAttachment.UseVisualStyleBackColor = true;
            this.buttonOpenAttachment.Click += new System.EventHandler(this.buttonOpenAttachment_Click);
            // 
            // buttonRemoveAttachment
            // 
            this.buttonRemoveAttachment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRemoveAttachment.Location = new System.Drawing.Point(384, 3);
            this.buttonRemoveAttachment.Name = "buttonRemoveAttachment";
            this.buttonRemoveAttachment.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAttachment.TabIndex = 3;
            this.buttonRemoveAttachment.Tag = "Localizable:Text";
            this.buttonRemoveAttachment.Text = "&Remove";
            this.buttonRemoveAttachment.UseVisualStyleBackColor = true;
            this.buttonRemoveAttachment.Click += new System.EventHandler(this.buttonRemoveAttachment_Click);
            // 
            // panelFilePreview
            // 
            this.panelFilePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilePreview.AutoScroll = true;
            this.panelFilePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFilePreview.Controls.Add(this.pictureBoxImagePreview);
            this.panelFilePreview.Controls.Add(this.listViewFile);
            this.panelFilePreview.Location = new System.Drawing.Point(3, 58);
            this.panelFilePreview.Name = "panelFilePreview";
            this.panelFilePreview.Size = new System.Drawing.Size(594, 364);
            this.panelFilePreview.TabIndex = 4;
            // 
            // pictureBoxImagePreview
            // 
            this.pictureBoxImagePreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImagePreview.Name = "pictureBoxImagePreview";
            this.pictureBoxImagePreview.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxImagePreview.TabIndex = 1;
            this.pictureBoxImagePreview.TabStop = false;
            this.pictureBoxImagePreview.Visible = false;
            // 
            // listViewFile
            // 
            this.listViewFile.AutoArrange = false;
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFile.HideSelection = false;
            this.listViewFile.LargeImageList = this.iconImageList;
            this.listViewFile.Location = new System.Drawing.Point(0, 0);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.ShowGroups = false;
            this.listViewFile.Size = new System.Drawing.Size(590, 360);
            this.listViewFile.TabIndex = 0;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.Visible = false;
            // 
            // iconImageList
            // 
            this.iconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iconImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.iconImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.Filter = "*";
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_Renamed);
            // 
            // textBoxIndex
            // 
            this.textBoxIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIndex.Location = new System.Drawing.Point(3, 32);
            this.textBoxIndex.Name = "textBoxIndex";
            this.textBoxIndex.ReadOnly = true;
            this.textBoxIndex.Size = new System.Drawing.Size(594, 20);
            this.textBoxIndex.TabIndex = 5;
            this.textBoxIndex.DoubleClick += new System.EventHandler(this.textBoxIndex_DoubleClick);
            // 
            // FileViewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxIndex);
            this.Controls.Add(this.buttonOpenAttachment);
            this.Controls.Add(this.panelFilePreview);
            this.Controls.Add(this.buttonImportAttachment);
            this.Controls.Add(this.buttonExportAttachment);
            this.Controls.Add(this.buttonRemoveAttachment);
            this.MinimumSize = new System.Drawing.Size(324, 100);
            this.Name = "FileViewUserControl";
            this.Size = new System.Drawing.Size(600, 425);
            this.panelFilePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImportAttachment;
        private System.Windows.Forms.Button buttonExportAttachment;
        private System.Windows.Forms.Button buttonOpenAttachment;
        private System.Windows.Forms.Button buttonRemoveAttachment;
        private System.Windows.Forms.Panel panelFilePreview;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.PictureBox pictureBoxImagePreview;
        private System.Windows.Forms.ImageList iconImageList;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.TextBox textBoxIndex;
    }
}
