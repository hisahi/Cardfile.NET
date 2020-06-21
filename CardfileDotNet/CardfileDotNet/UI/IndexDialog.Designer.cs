namespace CardfileDotNet.UI
{
    partial class IndexDialog
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelIndexText = new System.Windows.Forms.Label();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(135, 44);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(225, 44);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelIndexText
            // 
            this.labelIndexText.Location = new System.Drawing.Point(2, 8);
            this.labelIndexText.Name = "labelIndexText";
            this.labelIndexText.Size = new System.Drawing.Size(92, 23);
            this.labelIndexText.TabIndex = 0;
            this.labelIndexText.Text = "Index Text:";
            this.labelIndexText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // indexTextBox
            // 
            this.indexTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexTextBox.Location = new System.Drawing.Point(100, 10);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(322, 20);
            this.indexTextBox.TabIndex = 1;
            this.indexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.indexTextBox_KeyPress);
            // 
            // IndexDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 71);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.labelIndexText);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 110);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 110);
            this.Name = "IndexDialog";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Index...";
            this.Shown += new System.EventHandler(this.IndexDialog_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IndexDialog_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelIndexText;
        private System.Windows.Forms.TextBox indexTextBox;
    }
}