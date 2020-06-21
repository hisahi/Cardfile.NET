using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class EditViewUserControl : LocalizableUserControl, ICommitable
    {
        internal EditViewDataSource source;
        public WindowState State { get; } = null;

        public EditViewUserControl(WindowState state)
        {
            InitializeComponent();
            State = state;
            source = new EditViewDataSource(state);
            State.BindFile(GotFile);
            State.BindFrontCard(GotCard);
            cardIndexListBox.DisplayMember = "Index";
            cardIndexListBox.DataSource = listBindingSource;
            cardIndexListBox.DataBindings.Add(new Binding("SelectedIndex", source, "SelectedIndex", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        internal void FocusIndexBox()
        {
            cardUserControl.Focus();
            cardUserControl.FocusIndexBox();
        }

        public void GotFile(Cardfile file)
        {
            listBindingSource.DataSource = State.File.Cards;
            source.Update();
        }

        public void GotCard(Card card)
        {
            cardUserControl.Card = card;
        }

        public void Commit()
        {
            cardUserControl.Commit();
        }

        public void DoCut() => cardUserControl.DoCut();
        public void DoCopy() => cardUserControl.DoCopy();
        public void DoPaste() => cardUserControl.DoPaste();

        public int ContentsSelectionStart => cardUserControl.ContentsSelectionStart;
        public int ContentsSelectionLength => cardUserControl.ContentsSelectionLength;

        public void SelectText(int start, int length)
        {
            cardUserControl.SelectText(start, length);
        }

        public override void Localize()
        {

        }
    }

    internal class EditViewDataSource : VolatileState
    {
        private WindowState state;

        public EditViewDataSource(WindowState state)
        {
            this.state = state;
        }

        public int SelectedIndex
        {
            get => state.File.FrontIndex;
            set => state.File.FrontIndex = value;
        }

        public void Update()
        {
            Update(nameof(SelectedIndex));
            this.state.File.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "FrontIndex")
                    Update(nameof(SelectedIndex));
            };
        }
    }
}
