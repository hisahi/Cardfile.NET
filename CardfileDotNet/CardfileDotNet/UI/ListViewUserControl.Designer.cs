namespace CardfileDotNet.UI
{
    partial class ListViewUserControl
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
            this.listView = new CardfileDotNet.UI.BindableListView();
            this.listViewColumnIndex = ((CardfileDotNet.UI.BindableColumnHeader)(new CardfileDotNet.UI.BindableColumnHeader()));
            this.listViewColumnText = ((CardfileDotNet.UI.BindableColumnHeader)(new CardfileDotNet.UI.BindableColumnHeader()));
            this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewColumnIndex,
            this.listViewColumnText});
            this.listView.DataSource = null;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.SelectedIndex = -1;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(402, 388);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // listViewColumnIndex
            // 
            this.listViewColumnIndex.DisplayMember = "Index";
            this.listViewColumnIndex.Name = "listViewColumnIndex";
            this.listViewColumnIndex.Text = "Index";
            this.listViewColumnIndex.Width = 200;
            // 
            // listViewColumnText
            // 
            this.listViewColumnText.DisplayMember = "ShortText";
            this.listViewColumnText.Name = "listViewColumnText";
            this.listViewColumnText.Text = "Text";
            this.listViewColumnText.Width = 400;
            // 
            // ListViewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.DoubleBuffered = true;
            this.Name = "ListViewUserControl";
            this.Size = new System.Drawing.Size(402, 388);
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CardfileDotNet.UI.BindableListView listView;
        private CardfileDotNet.UI.BindableColumnHeader listViewColumnIndex;
        private CardfileDotNet.UI.BindableColumnHeader listViewColumnText;
        private System.Windows.Forms.BindingSource listBindingSource;
    }
}
