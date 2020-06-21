namespace CardfileDotNet.UI
{
    partial class SearchDialog
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
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelFindWhat = new System.Windows.Forms.Label();
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.groupBoxDirection = new System.Windows.Forms.GroupBox();
            this.radioButtonDirectionForward = new System.Windows.Forms.RadioButton();
            this.radioButtonDirectionBack = new System.Windows.Forms.RadioButton();
            this.groupBoxDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Location = new System.Drawing.Point(72, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(192, 20);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindNext.Location = new System.Drawing.Point(272, 10);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(95, 23);
            this.buttonFindNext.TabIndex = 4;
            this.buttonFindNext.Tag = "Localizable:Text";
            this.buttonFindNext.Text = "&Find Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(272, 39);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelFindWhat
            // 
            this.labelFindWhat.Location = new System.Drawing.Point(0, 10);
            this.labelFindWhat.Name = "labelFindWhat";
            this.labelFindWhat.Size = new System.Drawing.Size(66, 23);
            this.labelFindWhat.TabIndex = 0;
            this.labelFindWhat.Tag = "Localizable:Text";
            this.labelFindWhat.Text = "Fi&nd what:";
            this.labelFindWhat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxMatchCase
            // 
            this.checkBoxMatchCase.Location = new System.Drawing.Point(3, 68);
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.Size = new System.Drawing.Size(131, 24);
            this.checkBoxMatchCase.TabIndex = 2;
            this.checkBoxMatchCase.Tag = "Localizable:Text";
            this.checkBoxMatchCase.Text = "Match &case";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // groupBoxDirection
            // 
            this.groupBoxDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDirection.Controls.Add(this.radioButtonDirectionForward);
            this.groupBoxDirection.Controls.Add(this.radioButtonDirectionBack);
            this.groupBoxDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxDirection.Location = new System.Drawing.Point(162, 39);
            this.groupBoxDirection.Name = "groupBoxDirection";
            this.groupBoxDirection.Size = new System.Drawing.Size(102, 66);
            this.groupBoxDirection.TabIndex = 3;
            this.groupBoxDirection.TabStop = false;
            this.groupBoxDirection.Tag = "Localizable:Text";
            this.groupBoxDirection.Text = "Direction";
            // 
            // radioButtonDirectionForward
            // 
            this.radioButtonDirectionForward.Checked = true;
            this.radioButtonDirectionForward.Location = new System.Drawing.Point(11, 36);
            this.radioButtonDirectionForward.Name = "radioButtonDirectionForward";
            this.radioButtonDirectionForward.Size = new System.Drawing.Size(85, 24);
            this.radioButtonDirectionForward.TabIndex = 7;
            this.radioButtonDirectionForward.TabStop = true;
            this.radioButtonDirectionForward.Tag = "Localizable:Text";
            this.radioButtonDirectionForward.Text = "&Forwards";
            this.radioButtonDirectionForward.UseVisualStyleBackColor = true;
            // 
            // radioButtonDirectionBack
            // 
            this.radioButtonDirectionBack.Location = new System.Drawing.Point(11, 16);
            this.radioButtonDirectionBack.Name = "radioButtonDirectionBack";
            this.radioButtonDirectionBack.Size = new System.Drawing.Size(85, 24);
            this.radioButtonDirectionBack.TabIndex = 6;
            this.radioButtonDirectionBack.Tag = "Localizable:Text";
            this.radioButtonDirectionBack.Text = "&Backwards";
            this.radioButtonDirectionBack.UseVisualStyleBackColor = true;
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 110);
            this.Controls.Add(this.groupBoxDirection);
            this.Controls.Add(this.checkBoxMatchCase);
            this.Controls.Add(this.labelFindWhat);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonFindNext);
            this.Controls.Add(this.textBoxSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find...";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchDialog_KeyPress);
            this.groupBoxDirection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonFindNext;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelFindWhat;
        private System.Windows.Forms.CheckBox checkBoxMatchCase;
        private System.Windows.Forms.GroupBox groupBoxDirection;
        private System.Windows.Forms.RadioButton radioButtonDirectionForward;
        private System.Windows.Forms.RadioButton radioButtonDirectionBack;
    }
}