using CardfileDotNet.Data;
using CardfileDotNet.Logic;
using System;
using System.Drawing;
using System.Management.Instrumentation;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class CardUserControl : UserControl, ICommitable
    {
        private CardDataSource cardDataSource;
        private Binding indexBinding;
        private Binding contentsBinding;
        private bool _inBackground;
        private bool _tabStop;
        private int lastColumns = 40;
        private int lastRows = 12;

        public CardUserControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            Font font = new Font(FontFamily.GenericMonospace, OptionHandler.FontSize);
            indexTextBox.Font = font;
            contentsTextBox.Font = font;
            contentsTextBox.SelectionFont = font;

            cardDataSource = new CardDataSource();
            this.indexTextBox.DataBindings.Add(new Binding("Enabled", cardDataSource, "HasCard"));
            this.indexTextBox.DataBindings.Add(indexBinding = new Binding("Text", cardDataSource, "CardIndex", false, DataSourceUpdateMode.OnPropertyChanged, ""));
            this.contentsTextBox.DataBindings.Add(new Binding("Enabled", cardDataSource, "HasCard"));
            this.contentsTextBox.DataBindings.Add(contentsBinding = new Binding("Rtf", cardDataSource, "CardContents", false, DataSourceUpdateMode.OnValidation, ""));

            this.InBackground = false;
            this.Click += CardUserControl_Click;
            this.indexTextBox.Click += CardUserControl_Click;
            this.contentsTextBox.Click += CardUserControl_Click;
            this._tabStop = base.TabStop;
            OptionHandler.OptionsUpdated += OptionHandler_OptionsUpdated;
        }

        public Card Card
        {
            get => cardDataSource.Card;
            set
            {
                Commit();
                cardDataSource.Card = value;
            }
        }

        public bool InBackground
        {
            get => _inBackground;
            set
            {
                if (_inBackground != value)
                {
                    _inBackground = value;
                    indexTextBox.ReadOnly = contentsTextBox.ReadOnly = _inBackground;
                    indexTextBox.Cursor = contentsTextBox.Cursor = _inBackground ? Cursors.Default : Cursors.IBeam;
                    base.TabStop = TabStop;
                }
            }
        }

        internal int ContentsSelectionStart => contentsTextBox.SelectionStart;
        internal int ContentsSelectionLength => contentsTextBox.SelectionLength;

        private void CardUserControl_Click(object sender, EventArgs e)
        {
            if (this.InBackground)
                BackgroundClicked?.Invoke(this, new EventArgs());
        }

        public void Commit()
        {
            if (cardDataSource.Card != null)
            {
                this.ValidateChildren();
                indexBinding.WriteValue();
                contentsBinding.WriteValue();
            }
        }

        internal void DoCut()
        {
            if (indexTextBox.Focused)
                indexTextBox.Cut();
            else if (contentsTextBox.Focused)
                contentsTextBox.Cut();
        }

        internal void DoCopy()
        {
            if (indexTextBox.Focused)
                indexTextBox.Copy();
            else if (contentsTextBox.Focused)
                contentsTextBox.Copy();
        }

        internal void DoPaste()
        {
            if (indexTextBox.Focused)
                indexTextBox.Paste();
            else if (contentsTextBox.Focused)
                contentsTextBox.Paste();
        }

        internal void FocusIndexBox()
        {
            indexTextBox.Select();
        }

        internal void FocusContentsBox()
        {
            contentsTextBox.Select();
        }

        public new bool TabStop
        {
            get => _tabStop && !InBackground;
            set
            {
                _tabStop = value;
                base.TabStop = TabStop;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, SystemColors.ControlText, ButtonBorderStyle.Solid);
        }

        private void OptionHandler_OptionsUpdated(object sender, EventArgs e)
        {
            ResizeTo(lastColumns, lastRows);
        }

        public void ResizeTo(int columns, int rows)
        {
            Font font = new Font(FontFamily.GenericMonospace, OptionHandler.FontSize);

            int selStart = contentsTextBox.SelectionStart, selLen = contentsTextBox.SelectionLength;
            indexTextBox.Font = font;
            contentsTextBox.SelectAll();
            contentsTextBox.SelectionFont = font;
            contentsTextBox.Font = font;
            contentsTextBox.SelectionStart = selStart;
            contentsTextBox.SelectionLength = selLen;

            var size = TextRenderer.MeasureText(new string('0', columns), contentsTextBox.Font);
            this.Width = size.Width;
            string n = "";
            for (int i = 0; i < rows - 1; ++i)
                n += "\n0";
            var nSize = TextRenderer.MeasureText(n.Trim(), contentsTextBox.Font);
            this.Size = new Size(this.Width, nSize.Height + indexTextBox.Height + contentsTextBox.Margin.Vertical);
            lastColumns = columns;
            lastRows = rows;
        }

        private void indexTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                contentsTextBox.Focus();
                e.Handled = true;
            }
        }

        internal void SelectText(int start, int length)
        {
            contentsTextBox.Select(start, length);
        }

        public event EventHandler BackgroundClicked;
    }

    public class CardDataSource : VolatileState
    {
        private Card _card;

        public Card Card
        {
            get => _card;
            set
            {
                if (_card != null) _card.CardChanged -= OnCardChanged;
                Set(ref _card, value);
                Update(nameof(CardIndex));
                Update(nameof(CardContents));
                if (_card != null) _card.CardChanged += OnCardChanged;
            }
        }

        private void OnCardChanged(object sender, CardChangedEventArgs e)
        {
            if (e.PropertyName == "Index")
                Update(nameof(CardIndex));
            if (e.PropertyName == "Contents")
                Update(nameof(CardContents));
        }

        public bool HasCard => _card != null;

        public string CardIndex
        {
            get => Card?.Index;
            set { if (Card != null) Card.Index = value; }
        }
        public string CardContents
        {
            get => Card?.Contents;
            set { if (Card != null) Card.Contents = value; }
        }
    }
}
