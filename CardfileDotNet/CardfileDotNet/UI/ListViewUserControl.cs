using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System;
using System.ComponentModel;

namespace CardfileDotNet.UI
{
    public partial class ListViewUserControl : LocalizableUserControl
    {
        public WindowState State { get; } = null;
        private ListViewDataSource source;

        public ListViewUserControl(WindowState state)
        {
            InitializeComponent();
            State = state;
            source = new ListViewDataSource(State);
            State.BindFile(GotFile);
            listView.DataSource = listBindingSource;
            listView.DataBindings.Add("SelectedIndex", source, "SelectedIndex");
        }

        public void GotFile(Cardfile file)
        {
            listBindingSource.DataSource = file.Cards;
            source.File = file;
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedIndex >= 0)
                State.ViewMode = ViewMode.Edit;
        }

        public override void Localize()
        {
            listViewColumnIndex.Text = Language.Get("ListColumnIndex");
            listViewColumnText.Text = Language.Get("ListColumnContents");
        }
    }

    public class ListViewDataSource : VolatileState
    {
        private Cardfile _file;
        public WindowState State { get; } = null;

        public ListViewDataSource(WindowState state)
        {
            State = state;
        }

        public Cardfile File
        {
            get => _file;
            set
            {
                Set(ref _file, value);
                Update(nameof(SelectedIndex));
                _file.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == "FrontIndex")
                        Update(nameof(SelectedIndex));
                };
            }
        }

        public int SelectedIndex
        {
            get => State.File.FrontIndex;
            set => State.File.FrontIndex = value;
        }
    }
}
