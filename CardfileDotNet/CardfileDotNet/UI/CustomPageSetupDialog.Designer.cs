namespace CardfileDotNet.UI
{
    partial class CustomPageSetupDialog
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonNormalPageSetup = new System.Windows.Forms.Button();
            this.labelPageSetupButton = new System.Windows.Forms.Label();
            this.labelPageHeader = new System.Windows.Forms.Label();
            this.textBoxPageHeader = new System.Windows.Forms.TextBox();
            this.labelPageFooter = new System.Windows.Forms.Label();
            this.textBoxPageFooter = new System.Windows.Forms.TextBox();
            this.labelPrintMode = new System.Windows.Forms.Label();
            this.radioButtonPrintCard = new System.Windows.Forms.RadioButton();
            this.radioButtonPrintPage = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(157, 144);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 101;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(67, 144);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 100;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonNormalPageSetup
            // 
            this.buttonNormalPageSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNormalPageSetup.Location = new System.Drawing.Point(157, 12);
            this.buttonNormalPageSetup.Name = "buttonNormalPageSetup";
            this.buttonNormalPageSetup.Size = new System.Drawing.Size(129, 23);
            this.buttonNormalPageSetup.TabIndex = 1;
            this.buttonNormalPageSetup.Tag = "Localizable:Text";
            this.buttonNormalPageSetup.Text = "Page &Setup";
            this.buttonNormalPageSetup.UseVisualStyleBackColor = true;
            this.buttonNormalPageSetup.Click += new System.EventHandler(this.buttonNormalPageSetup_Click);
            // 
            // labelPageSetupButton
            // 
            this.labelPageSetupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPageSetupButton.Location = new System.Drawing.Point(5, 9);
            this.labelPageSetupButton.Name = "labelPageSetupButton";
            this.labelPageSetupButton.Size = new System.Drawing.Size(146, 26);
            this.labelPageSetupButton.TabIndex = 0;
            this.labelPageSetupButton.Tag = "Localizable:Text";
            this.labelPageSetupButton.Text = "Adjust page orientation, paper size and margins.";
            this.labelPageSetupButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPageHeader
            // 
            this.labelPageHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPageHeader.Location = new System.Drawing.Point(5, 56);
            this.labelPageHeader.Name = "labelPageHeader";
            this.labelPageHeader.Size = new System.Drawing.Size(121, 23);
            this.labelPageHeader.TabIndex = 2;
            this.labelPageHeader.Tag = "Localizable:Text";
            this.labelPageHeader.Text = "Page &Header:";
            this.labelPageHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPageHeader
            // 
            this.textBoxPageHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPageHeader.Location = new System.Drawing.Point(132, 59);
            this.textBoxPageHeader.Name = "textBoxPageHeader";
            this.textBoxPageHeader.Size = new System.Drawing.Size(154, 20);
            this.textBoxPageHeader.TabIndex = 3;
            // 
            // labelPageFooter
            // 
            this.labelPageFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPageFooter.Location = new System.Drawing.Point(5, 83);
            this.labelPageFooter.Name = "labelPageFooter";
            this.labelPageFooter.Size = new System.Drawing.Size(121, 23);
            this.labelPageFooter.TabIndex = 4;
            this.labelPageFooter.Tag = "Localizable:Text";
            this.labelPageFooter.Text = "Page &Footer:";
            this.labelPageFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPageFooter
            // 
            this.textBoxPageFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPageFooter.Location = new System.Drawing.Point(132, 85);
            this.textBoxPageFooter.Name = "textBoxPageFooter";
            this.textBoxPageFooter.Size = new System.Drawing.Size(154, 20);
            this.textBoxPageFooter.TabIndex = 5;
            // 
            // labelPrintMode
            // 
            this.labelPrintMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrintMode.Location = new System.Drawing.Point(5, 110);
            this.labelPrintMode.Name = "labelPrintMode";
            this.labelPrintMode.Size = new System.Drawing.Size(121, 23);
            this.labelPrintMode.TabIndex = 6;
            this.labelPrintMode.Tag = "Localizable:Text";
            this.labelPrintMode.Text = "Print &Mode:";
            this.labelPrintMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButtonPrintCard
            // 
            this.radioButtonPrintCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonPrintCard.Location = new System.Drawing.Point(132, 111);
            this.radioButtonPrintCard.Name = "radioButtonPrintCard";
            this.radioButtonPrintCard.Size = new System.Drawing.Size(73, 24);
            this.radioButtonPrintCard.TabIndex = 7;
            this.radioButtonPrintCard.TabStop = true;
            this.radioButtonPrintCard.Tag = "Localizable:Text";
            this.radioButtonPrintCard.Text = "&Card";
            this.radioButtonPrintCard.UseVisualStyleBackColor = true;
            // 
            // radioButtonPrintPage
            // 
            this.radioButtonPrintPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonPrintPage.Location = new System.Drawing.Point(213, 111);
            this.radioButtonPrintPage.Name = "radioButtonPrintPage";
            this.radioButtonPrintPage.Size = new System.Drawing.Size(73, 24);
            this.radioButtonPrintPage.TabIndex = 8;
            this.radioButtonPrintPage.Tag = "Localizable:Text";
            this.radioButtonPrintPage.Text = "&Page";
            this.radioButtonPrintPage.UseVisualStyleBackColor = true;
            // 
            // CustomPageSetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 179);
            this.Controls.Add(this.radioButtonPrintPage);
            this.Controls.Add(this.radioButtonPrintCard);
            this.Controls.Add(this.labelPrintMode);
            this.Controls.Add(this.textBoxPageFooter);
            this.Controls.Add(this.labelPageFooter);
            this.Controls.Add(this.textBoxPageHeader);
            this.Controls.Add(this.labelPageHeader);
            this.Controls.Add(this.labelPageSetupButton);
            this.Controls.Add(this.buttonNormalPageSetup);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomPageSetupDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Page Setup";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomPageSetupDialog_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonNormalPageSetup;
        private System.Windows.Forms.Label labelPageSetupButton;
        private System.Windows.Forms.Label labelPageHeader;
        private System.Windows.Forms.TextBox textBoxPageHeader;
        private System.Windows.Forms.Label labelPageFooter;
        private System.Windows.Forms.TextBox textBoxPageFooter;
        private System.Windows.Forms.Label labelPrintMode;
        private System.Windows.Forms.RadioButton radioButtonPrintCard;
        private System.Windows.Forms.RadioButton radioButtonPrintPage;
    }
}