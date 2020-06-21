using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class OptionsDialog : LocalizableForm
    {
        OptionsDataSource source;
        private static List<LanguageEntry> languageList;
        private static List<CardSizeOption> sizeList;

        static OptionsDialog()
        {
            languageList = new List<LanguageEntry>();
            languageList.Add(new LanguageEntry(Language.Get("DefaultLanguage"), ""));
            foreach (var pair in Language.languages)
                languageList.Add(new LanguageEntry(Language.GetLanguageName(pair.Key), pair.Key));
            sizeList = new List<CardSizeOption>();
            foreach (CardPaperSize size in Enum.GetValues(typeof(CardPaperSize)))
                sizeList.Add(new CardSizeOption(size));
        }

        public OptionsDialog()
        {
            InitializeComponent();
            source = new OptionsDataSource();
            optionsLanguageComboBox.DataSource = languageList;
            optionsLanguageComboBox.DisplayMember = "Name";
            optionsLanguageComboBox.ValueMember = "Code";
            optionsLanguageComboBox.DataBindings.Add(new Binding("SelectedValue", source, "LanguageCode"));
            comboBoxCardSize.DataSource = sizeList;
            comboBoxCardSize.DisplayMember = "Text";
            comboBoxCardSize.ValueMember = "Size";
            comboBoxCardSize.DataBindings.Add(new Binding("SelectedValue", source, "CardSize", false, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownCardWidth.Minimum = OptionHandler.CARD_MINIMUM_WIDTH;
            numericUpDownCardWidth.Maximum = OptionHandler.CARD_MAXIMUM_WIDTH;
            numericUpDownCardHeight.Minimum = OptionHandler.CARD_MINIMUM_HEIGHT;
            numericUpDownCardHeight.Maximum = OptionHandler.CARD_MAXIMUM_HEIGHT;
            numericUpDownCardWidth.DataBindings.Add(new Binding("Value", source, "CardWidth", false, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownCardHeight.DataBindings.Add(new Binding("Value", source, "CardHeight", false, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownFontSize.DataBindings.Add(new Binding("Value", source, "FontSize", false, DataSourceUpdateMode.OnPropertyChanged));

            numericUpDownCardWidth.DataBindings.Add(MakeCustomCardEnableBinding());
            numericUpDownCardHeight.DataBindings.Add(MakeCustomCardEnableBinding());
            radioButtonSizeIn.DataBindings.Add(MakeCustomCardEnableBinding());
            radioButtonSizeMm.DataBindings.Add(MakeCustomCardEnableBinding());
            labelCardSizeIn.DataBindings.Add("Text", source, "CardSizeInText");
            labelCardSizeMm.DataBindings.Add("Text", source, "CardSizeMmText");
            radioButtonSizeIn.DataBindings.Add("Checked", source, "CustomUseInches");
            radioButtonSizeMm.DataBindings.Add("Checked", source, "CustomUseMm");
        }

        private Binding MakeCustomCardEnableBinding()
        {
            Binding enableBinding = new Binding("Enabled", source, "CardSize");
            enableBinding.Format += (s, e) => e.Value = (CardPaperSize)e.Value == CardPaperSize.CUSTOM;
            return enableBinding;
        }

        public override void Localize()
        {
            this.Text = Language.GetMenuText("editOptionsToolStripMenuItem.Text");
            this.buttonOk.Text = Language.Get("OK");
            this.buttonCancel.Text = Language.Get("Cancel");
            Language.LocalizeControls(this, new Control[] { });
            languageList[0].Name = Language.Get("DefaultLanguage");
        }

        private void OptionsDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                buttonCancel.PerformClick();
        }
    }

    public class CardSizeOption
    {
        public CardPaperSize Size { get; }

        public CardSizeOption(CardPaperSize s)
        {
            Size = s;
        }

        public string Text => Language.Get("comboBoxCardSize." + this.Size.ToString() + ".Text");
    }

    public class OptionsDataSource : VolatileState
    {
        public string LanguageCode
        {
            get => Properties.Settings.Default.Language;
            set => Properties.Settings.Default.Language = value;
        }

        public CardPaperSize CardSize
        {
            get => Properties.Settings.Default.CardSize;
            set
            {
                Properties.Settings.Default.CardSize = value;
                Update(nameof(CardWidth));
                Update(nameof(CardHeight));
                Update(nameof(CardSizeMmText));
                Update(nameof(CardSizeInText));
            }
        }

        public int CardWidth
        {
            get => OptionHandler.CardWidth;
            set
            {
                Properties.Settings.Default.CardWidth = OptionHandler.ClampCardWidth(value);
                Update(nameof(CardSizeMmText));
                Update(nameof(CardSizeInText));
            }
        }

        public int CardHeight
        {
            get => OptionHandler.CardHeight;
            set
            {
                Properties.Settings.Default.CardHeight = OptionHandler.ClampCardHeight(value);
                Update(nameof(CardSizeMmText));
                Update(nameof(CardSizeInText));
            }
        }

        public int FontSize
        {
            get => OptionHandler.FontSize;
            set => Properties.Settings.Default.FontSize = OptionHandler.ClampFontSize(value);
        }

        public bool CustomUseInches
        {
            get => !Properties.Settings.Default.RoundCustomToNearestMm;
            set
            {
                if (value)
                    Properties.Settings.Default.RoundCustomToNearestMm = false;
            }
        }

        public bool CustomUseMm
        {
            get => Properties.Settings.Default.RoundCustomToNearestMm;
            set
            {
                if (value)
                    Properties.Settings.Default.RoundCustomToNearestMm = true;
            }
        }

        public string CardSizeInText => string.Format(Language.Get("labelCardSizeMeasurements", "{1:0.#} x {0:0.#}"), OptionHandler.CardWidthInches, OptionHandler.CardHeightInches);
        public string CardSizeMmText => string.Format(Language.Get("labelCardSizeMeasurements", "{1:0.#} x {0:0.#}"), OptionHandler.CardWidthMm, OptionHandler.CardHeightMm);
    }

    internal class LanguageEntry : VolatileState
    {
        private string _name;
        private string _code;

        public LanguageEntry(string name, string code)
        {
            _name = name;
            _code = code;
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Code
        {
            get => _code;
        }
    }
}
