namespace CardfileDotNet.UI
{
    partial class OptionsDialog
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
            this.optionsLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.optionsLabelLanguage = new System.Windows.Forms.Label();
            this.labelCardSize = new System.Windows.Forms.Label();
            this.numericUpDownCardWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCardHeight = new System.Windows.Forms.NumericUpDown();
            this.labelTimes = new System.Windows.Forms.Label();
            this.comboBoxCardSize = new System.Windows.Forms.ComboBox();
            this.labelCardSizeIn = new System.Windows.Forms.Label();
            this.labelCardSizeMm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonSizeMm = new System.Windows.Forms.RadioButton();
            this.radioButtonSizeIn = new System.Windows.Forms.RadioButton();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCardWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCardHeight)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(200, 173);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 99;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(110, 173);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 98;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // optionsLanguageComboBox
            // 
            this.optionsLanguageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionsLanguageComboBox.FormattingEnabled = true;
            this.optionsLanguageComboBox.Location = new System.Drawing.Point(95, 12);
            this.optionsLanguageComboBox.Name = "optionsLanguageComboBox";
            this.optionsLanguageComboBox.Size = new System.Drawing.Size(277, 21);
            this.optionsLanguageComboBox.TabIndex = 1;
            // 
            // optionsLabelLanguage
            // 
            this.optionsLabelLanguage.Location = new System.Drawing.Point(6, 10);
            this.optionsLabelLanguage.Name = "optionsLabelLanguage";
            this.optionsLabelLanguage.Size = new System.Drawing.Size(83, 23);
            this.optionsLabelLanguage.TabIndex = 0;
            this.optionsLabelLanguage.Tag = "Localizable:Text";
            this.optionsLabelLanguage.Text = "&Language:";
            this.optionsLabelLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCardSize
            // 
            this.labelCardSize.Location = new System.Drawing.Point(6, 45);
            this.labelCardSize.Name = "labelCardSize";
            this.labelCardSize.Size = new System.Drawing.Size(83, 23);
            this.labelCardSize.TabIndex = 2;
            this.labelCardSize.Tag = "Localizable:Text";
            this.labelCardSize.Text = "Card Si&ze:";
            this.labelCardSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownCardWidth
            // 
            this.numericUpDownCardWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCardWidth.Location = new System.Drawing.Point(95, 84);
            this.numericUpDownCardWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCardWidth.Name = "numericUpDownCardWidth";
            this.numericUpDownCardWidth.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownCardWidth.TabIndex = 4;
            this.numericUpDownCardWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCardWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownCardHeight
            // 
            this.numericUpDownCardHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCardHeight.Location = new System.Drawing.Point(165, 84);
            this.numericUpDownCardHeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownCardHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCardHeight.Name = "numericUpDownCardHeight";
            this.numericUpDownCardHeight.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownCardHeight.TabIndex = 6;
            this.numericUpDownCardHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCardHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // labelTimes
            // 
            this.labelTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimes.Location = new System.Drawing.Point(141, 82);
            this.labelTimes.Name = "labelTimes";
            this.labelTimes.Size = new System.Drawing.Size(18, 20);
            this.labelTimes.TabIndex = 5;
            this.labelTimes.Text = "x";
            this.labelTimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCardSize
            // 
            this.comboBoxCardSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardSize.FormattingEnabled = true;
            this.comboBoxCardSize.Location = new System.Drawing.Point(95, 47);
            this.comboBoxCardSize.Name = "comboBoxCardSize";
            this.comboBoxCardSize.Size = new System.Drawing.Size(277, 21);
            this.comboBoxCardSize.TabIndex = 3;
            // 
            // labelCardSizeIn
            // 
            this.labelCardSizeIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCardSizeIn.Location = new System.Drawing.Point(211, 74);
            this.labelCardSizeIn.Name = "labelCardSizeIn";
            this.labelCardSizeIn.Size = new System.Drawing.Size(93, 20);
            this.labelCardSizeIn.TabIndex = 7;
            this.labelCardSizeIn.Text = "labelCardSizeIN";
            this.labelCardSizeIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCardSizeMm
            // 
            this.labelCardSizeMm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCardSizeMm.Location = new System.Drawing.Point(211, 94);
            this.labelCardSizeMm.Name = "labelCardSizeMm";
            this.labelCardSizeMm.Size = new System.Drawing.Size(93, 20);
            this.labelCardSizeMm.TabIndex = 8;
            this.labelCardSizeMm.Text = "labelCardSizeMM";
            this.labelCardSizeMm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.radioButtonSizeMm);
            this.panel1.Controls.Add(this.radioButtonSizeIn);
            this.panel1.Location = new System.Drawing.Point(310, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 40);
            this.panel1.TabIndex = 100;
            // 
            // radioButtonSizeMm
            // 
            this.radioButtonSizeMm.AutoSize = true;
            this.radioButtonSizeMm.Location = new System.Drawing.Point(0, 23);
            this.radioButtonSizeMm.Name = "radioButtonSizeMm";
            this.radioButtonSizeMm.Size = new System.Drawing.Size(41, 17);
            this.radioButtonSizeMm.TabIndex = 1;
            this.radioButtonSizeMm.Tag = "Localizable:Text";
            this.radioButtonSizeMm.Text = "mm";
            this.radioButtonSizeMm.UseVisualStyleBackColor = true;
            // 
            // radioButtonSizeIn
            // 
            this.radioButtonSizeIn.AutoSize = true;
            this.radioButtonSizeIn.Location = new System.Drawing.Point(0, 2);
            this.radioButtonSizeIn.Name = "radioButtonSizeIn";
            this.radioButtonSizeIn.Size = new System.Drawing.Size(33, 17);
            this.radioButtonSizeIn.TabIndex = 0;
            this.radioButtonSizeIn.TabStop = true;
            this.radioButtonSizeIn.Tag = "Localizable:Text";
            this.radioButtonSizeIn.Text = "in";
            this.radioButtonSizeIn.UseVisualStyleBackColor = true;
            // 
            // labelFontSize
            // 
            this.labelFontSize.Location = new System.Drawing.Point(6, 117);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(83, 23);
            this.labelFontSize.TabIndex = 9;
            this.labelFontSize.Tag = "Localizable:Text";
            this.labelFontSize.Text = "&Font Size:";
            this.labelFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFontSize.Location = new System.Drawing.Point(95, 120);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownFontSize.TabIndex = 10;
            this.numericUpDownFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 208);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.labelFontSize);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelCardSizeMm);
            this.Controls.Add(this.labelCardSizeIn);
            this.Controls.Add(this.comboBoxCardSize);
            this.Controls.Add(this.labelTimes);
            this.Controls.Add(this.numericUpDownCardHeight);
            this.Controls.Add(this.numericUpDownCardWidth);
            this.Controls.Add(this.labelCardSize);
            this.Controls.Add(this.optionsLabelLanguage);
            this.Controls.Add(this.optionsLanguageComboBox);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options...";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OptionsDialog_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCardWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCardHeight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox optionsLanguageComboBox;
        private System.Windows.Forms.Label optionsLabelLanguage;
        private System.Windows.Forms.Label labelCardSize;
        private System.Windows.Forms.NumericUpDown numericUpDownCardWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownCardHeight;
        private System.Windows.Forms.Label labelTimes;
        private System.Windows.Forms.ComboBox comboBoxCardSize;
        private System.Windows.Forms.Label labelCardSizeIn;
        private System.Windows.Forms.Label labelCardSizeMm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonSizeMm;
        private System.Windows.Forms.RadioButton radioButtonSizeIn;
        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
    }
}