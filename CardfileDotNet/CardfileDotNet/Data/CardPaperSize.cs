using CardfileDotNet.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfileDotNet.Data
{
    public enum CardPaperSize
    {
        CUSTOM, US3_5, US4_6, US5_8, ISO
    }

    public static class CardPaperSizeExtensions
    {
        public static int GetCardColumns(this CardPaperSize size, int defaultValue)
        {
            switch (size)
            {
                case CardPaperSize.US3_5:
                    return 40;
                case CardPaperSize.US4_6:
                    return 48;
                case CardPaperSize.US5_8:
                    return 64;
                case CardPaperSize.ISO:
                    return 32;
            }
            return defaultValue;
        }

        public static int GetCardRows(this CardPaperSize size, int defaultValue)
        {
            switch (size)
            {
                case CardPaperSize.US3_5:
                    return 12;
                case CardPaperSize.US4_6:
                    return 16;
                case CardPaperSize.US5_8:
                    return 20;
                case CardPaperSize.ISO:
                    return 12;
            }
            return defaultValue;
        }

        public static float GetCardWidthPt(this CardPaperSize size)
        {
            switch (size)
            {
                case CardPaperSize.US3_5:
                    return 360f;
                case CardPaperSize.US4_6:
                    return 432f;
                case CardPaperSize.US5_8:
                    return 576f;
                case CardPaperSize.ISO:
                    return 105 * 72 / 25.4f;
            }
            return Properties.Settings.Default.CardWidth * 9f;
        }

        public static float GetCardHeightPt(this CardPaperSize size)
        {
            switch (size)
            {
                case CardPaperSize.US3_5:
                    return 216f;
                case CardPaperSize.US4_6:
                    return 288f;
                case CardPaperSize.US5_8:
                    return 360f;
                case CardPaperSize.ISO:
                    return 74 * 72 / 25.4f;
            }
            return Properties.Settings.Default.CardHeight * 18f;
        }
    }
}
