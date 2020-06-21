namespace CardfileDotNet.UI
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxLicense = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(222, 291);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(50, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(200, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Cardfile.NET";
            // 
            // labelAuthor
            // 
            this.labelAuthor.Location = new System.Drawing.Point(50, 66);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(247, 37);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "...";
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.Location = new System.Drawing.Point(9, 291);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(200, 20);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "program version ";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(12, 16);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxIcon.TabIndex = 4;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(50, 29);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(247, 37);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "...";
            // 
            // textBoxLicense
            // 
            this.textBoxLicense.Location = new System.Drawing.Point(12, 106);
            this.textBoxLicense.Multiline = true;
            this.textBoxLicense.Name = "textBoxLicense";
            this.textBoxLicense.ReadOnly = true;
            this.textBoxLicense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLicense.Size = new System.Drawing.Size(285, 179);
            this.textBoxLicense.TabIndex = 6;
            this.textBoxLicense.Text = resources.GetString("textBoxLicense.Text");
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 326);
            this.Controls.Add(this.textBoxLicense);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About...";
            this.Load += new System.EventHandler(this.AboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxLicense;
    }
}