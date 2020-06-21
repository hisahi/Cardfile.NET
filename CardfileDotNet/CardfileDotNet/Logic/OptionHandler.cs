using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.UI;
using CardfileDotNet.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfileDotNet.Logic
{
    public static class OptionHandler
    {
        public const int CARD_MINIMUM_WIDTH = 1;
        public const int CARD_MAXIMUM_WIDTH = 100;
        public const int CARD_MINIMUM_HEIGHT = 2;
        public const int CARD_MAXIMUM_HEIGHT = 50;
        public const int FONT_MINIMUM_SIZE = 6;
        public const int FONT_MAXIMUM_SIZE = 24;

        public static int CardWidth => Properties.Settings.Default.CardSize.GetCardColumns(ClampCardWidth(Properties.Settings.Default.CardWidth));
        public static int CardHeight => Properties.Settings.Default.CardSize.GetCardRows(ClampCardHeight(Properties.Settings.Default.CardHeight));
        public static float CardWidthInches => Properties.Settings.Default.CardSize.GetCardWidthPt() / 72f;
        public static float CardHeightInches => Properties.Settings.Default.CardSize.GetCardHeightPt() / 72f;
        public static float CardWidthMm => Properties.Settings.Default.CardSize.GetCardWidthPt() / 72f * 25.4f;
        public static float CardHeightMm => Properties.Settings.Default.CardSize.GetCardHeightPt() / 72f * 25.4f;
        public static int FontSize => ClampFontSize(Properties.Settings.Default.FontSize);

        public static string PageHeader => GetMaybeStringValue(Properties.Settings.Default.PrintHeader) ?? Language.Get("DefaultPrintHeader", "{file}");
        public static string PageFooter => GetMaybeStringValue(Properties.Settings.Default.PrintFooter) ?? Language.Get("DefaultPrintFooter", "Page {page}");

        public static CardPrintMode PrintMode => Properties.Settings.Default.PrintMode;

        public static int ClampCardWidth(int width)
        {
            return MathUtil.Clamp(width, CARD_MINIMUM_WIDTH, CARD_MAXIMUM_WIDTH);
        }

        public static int ClampCardHeight(int height)
        {
            return MathUtil.Clamp(height, CARD_MINIMUM_HEIGHT, CARD_MAXIMUM_HEIGHT);
        }

        public static int ClampFontSize(int size)
        {
            return MathUtil.Clamp(size, FONT_MINIMUM_SIZE, FONT_MAXIMUM_SIZE);
        }

        internal static void OnOptionUpdate()
        {
            OptionsUpdated?.Invoke(null, new EventArgs());
        }

        public static string GetMaybeStringValue(string v) => v.StartsWith(":") ? v.Substring(1) : null;
        public static string SetMaybeStringValue(string v) => v != null ? ":" + v : "";

        public static event EventHandler OptionsUpdated;
    }
}
