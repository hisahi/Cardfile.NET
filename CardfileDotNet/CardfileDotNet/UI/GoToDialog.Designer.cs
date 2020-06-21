namespace CardfileDotNet.UI
{
    partial class GoToDialog
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
            this.labelGoToText = new System.Windows.Forms.Label();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(35, 44);
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
            this.buttonCancel.Location = new System.Drawing.Point(125, 44);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelGoToText
            // 
            this.labelGoToText.Location = new System.Drawing.Point(2, 8);
            this.labelGoToText.Name = "labelGoToText";
            this.labelGoToText.Size = new System.Drawing.Size(79, 23);
            this.labelGoToText.TabIndex = 0;
            this.labelGoToText.Text = "Go To:";
            this.labelGoToText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // indexTextBox
            // 
            this.indexTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indexTextBox.Location = new System.Drawing.Point(87, 10);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(135, 20);
            this.indexTextBox.TabIndex = 1;
            this.indexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.indexTextBox_KeyPress);
            // 
            // GoToDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 71);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.labelGoToText);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 110);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(220, 110);
            this.Name = "GoToDialog";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Go To...";
            this.Shown += new System.EventHandler(this.IndexDialog_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GoToDialog_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelGoToText;
        private System.Windows.Forms.TextBox indexTextBox;
    }
}