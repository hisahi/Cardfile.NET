using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class SearchDialog : LocalizableForm
    {
        CurrentFindSource source;

        public SearchDialog()
        {
            InitializeComponent();
            source = new CurrentFindSource();

            textBoxSearch.DataBindings.Add("Text", source, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxMatchCase.DataBindings.Add("Checked", source, "MatchCase");

            buttonFindNext.DataBindings.Add("Enabled", source, "CanSearch");

            var directionBackBinding = new Binding("Checked", source, "Direction");
            directionBackBinding.Format += (s, e) => e.Value = (FindDirection)e.Value == FindDirection.Backwards;
            directionBackBinding.Parse += (s, e) => { if ((bool)e.Value) e.Value = FindDirection.Backwards; };
            radioButtonDirectionBack.DataBindings.Add(directionBackBinding);

            var directionForwardBinding = new Binding("Checked", source, "Direction");
            directionForwardBinding.Format += (s, e) => e.Value = (FindDirection)e.Value == FindDirection.Forwards;
            directionForwardBinding.Parse += (s, e) => { if ((bool)e.Value) e.Value = FindDirection.Forwards; };
            radioButtonDirectionForward.DataBindings.Add(directionForwardBinding);
        }

        public override void Localize()
        {
            Language.LocalizeControls(this, new Control[] { });
            this.Text = Language.GetMenuText("searchFindToolStripMenuItem.Text");
            this.buttonCancel.Text = Language.Get("Cancel");
        }

        private void SearchDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonCancel.PerformClick();
                e.Handled = true;
            }
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonFindNext.PerformClick();
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                buttonCancel.PerformClick();
                e.Handled = true;
            }
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            if (source.CanSearch)
                FindRequest?.Invoke(this, new FindRequestEventArgs(source.Bake()));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Cardfile Cardfile { get; set; }
        public delegate void FindRequestEventHandler(object sender, FindRequestEventArgs e);
        public event FindRequestEventHandler FindRequest;
    }

    class CurrentFindSource : VolatileState
    {
        private string _text;
        private FindDirection _dir;
        private bool _matchCase;

        public CurrentFindSource()
        {
            Text = "";
            Direction = FindDirection.Forwards;
            MatchCase = false;
        }

        public string Text
        {
            get => _text;
            set
            {
                Set(ref _text, value);
                Update(nameof(CanSearch));
            }
        }

        public FindDirection Direction
        {
            get => _dir;
            set => Set(ref _dir, value);
        }

        public bool MatchCase
        {
            get => _matchCase;
            set => Set(ref _matchCase, value);
        }

        public bool CanSearch => Text.Length > 0;

        public FindRequest Bake()
        {
            return new FindRequest(Text, Direction, MatchCase);
        }
    }

    public class FindRequestEventArgs : EventArgs
    {
        public FindRequest Request;

        public FindRequestEventArgs(FindRequest req) : base()
        {
            Request = req;
        }
    }
}
