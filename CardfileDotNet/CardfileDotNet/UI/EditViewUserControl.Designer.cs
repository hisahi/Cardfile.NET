namespace CardfileDotNet.UI
{
    partial class EditViewUserControl
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.cardIndexListBox = new System.Windows.Forms.ListBox();
            this.cardUserControl = new CardfileDotNet.UI.CardUserControl();
            this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.cardIndexListBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cardUserControl);
            this.splitContainer.Size = new System.Drawing.Size(503, 330);
            this.splitContainer.SplitterDistance = 167;
            this.splitContainer.TabIndex = 0;
            // 
            // cardIndexListBox
            // 
            this.cardIndexListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardIndexListBox.FormattingEnabled = true;
            this.cardIndexListBox.Location = new System.Drawing.Point(0, 0);
            this.cardIndexListBox.Name = "cardIndexListBox";
            this.cardIndexListBox.ScrollAlwaysVisible = true;
            this.cardIndexListBox.Size = new System.Drawing.Size(167, 330);
            this.cardIndexListBox.TabIndex = 0;
            // 
            // cardUserControl
            // 
            this.cardUserControl.Card = null;
            this.cardUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardUserControl.InBackground = false;
            this.cardUserControl.Location = new System.Drawing.Point(0, 0);
            this.cardUserControl.MinimumSize = new System.Drawing.Size(50, 50);
            this.cardUserControl.Name = "cardUserControl";
            this.cardUserControl.Size = new System.Drawing.Size(332, 330);
            this.cardUserControl.TabIndex = 1;
            this.cardUserControl.TabStop = false;
            // 
            // listBindingSource
            // 
            this.listBindingSource.AllowNew = false;
            // 
            // EditViewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "EditViewUserControl";
            this.Size = new System.Drawing.Size(503, 330);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        internal System.Windows.Forms.ListBox cardIndexListBox;
        internal CardUserControl cardUserControl;
        private System.Windows.Forms.BindingSource listBindingSource;
    }
}
