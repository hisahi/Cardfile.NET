using System.Drawing;

namespace CardfileDotNet.UI
{
    partial class CardUserControl
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
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.contentsTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // indexTextBox
            // 
            this.indexTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indexTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.indexTextBox.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.indexTextBox.Location = new System.Drawing.Point(0, 0);
            this.indexTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(198, 20);
            this.indexTextBox.TabIndex = 0;
            this.indexTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.indexTextBox_KeyPress);
            // 
            // contentsTextBox
            // 
            this.contentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentsTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentsTextBox.Location = new System.Drawing.Point(0, 20);
            this.contentsTextBox.Name = "contentsTextBox";
            this.contentsTextBox.Size = new System.Drawing.Size(198, 178);
            this.contentsTextBox.TabIndex = 1;
            this.contentsTextBox.Text = "";
            // 
            // CardUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.contentsTextBox);
            this.Controls.Add(this.indexTextBox);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "CardUserControl";
            this.Size = new System.Drawing.Size(198, 198);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.RichTextBox contentsTextBox;
    }
}
