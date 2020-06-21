using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public class CardPrinter
    {
        private static Font printfont = new Font(FontFamily.GenericMonospace, 14f, FontStyle.Regular, GraphicsUnit.Point);
        private static Color printColor = Color.Black;
        private static Brush printBrush = new SolidBrush(printColor);
        private static Pen printPen = new Pen(printColor);

        private bool printAll;
        private float lineHeight;
        private int endCard;

        private string headerLeft;
        private string headerCenter;
        private string headerRight;

        private string footerLeft;
        private string footerCenter;
        private string footerRight;

        public CardPrinter(WindowState state, bool printAllPages)
        {
            printAll = printAllPages;
            State = state;
            Reset();
        }

        public WindowState State { get; }

        public void Reset()
        {
            PageNumber = 1;
            if (printAll)
            {
                CardIndex = 0;
                endCard = State.File.CardCount - 1;
            }
            else
            {
                CardIndex = State.File.FrontIndex;
                endCard = State.File.FrontIndex;
            }

            lineHeight = TextRenderer.MeasureText("A\nA", printfont).Height - TextRenderer.MeasureText("A", printfont).Height;
            ParseHeaderFooter(OptionHandler.PageHeader, ref headerLeft, ref headerCenter, ref headerRight);
            ParseHeaderFooter(OptionHandler.PageFooter, ref footerLeft, ref footerCenter, ref footerRight);
        }

        private void ParseHeaderFooter(string format, ref string left, ref string center, ref string right)
        {
            left = center = right = "";
            ref string output = ref center;
            bool ampersand = false;
            foreach (char c in format)
            {
                if (ampersand)
                {
                    ampersand = false;
                    char cl = Char.ToLowerInvariant(c);
                    if (cl == '&')
                        output += '&';
                    else if (cl == 'd')
                        output += DateTime.Now.ToShortDateString();
                    else if (cl == 't')
                        output += DateTime.Now.ToShortTimeString();
                    else if (cl == 'f')
                        output += State.File.FilePath != null ? Path.GetFileName(State.File.FilePath) : Language.Get("Unnamed", "(UNNAMED)");
                    else if (cl == 'p')
                        output += PageNumber.ToString();
                    else if (cl == 'l')
                        output = ref left;
                    else if (cl == 'c')
                        output = ref center;
                    else if (cl == 'r')
                        output = ref right;
                    else
                    {
                        output += '&';
                        output += cl;
                    }
                }
                else if (c == '&')
                    ampersand = true;
                else
                    output += c;
            }
            if (ampersand) output += '&';
        }

        public int CardIndex { get; set; }
        public int PageNumber { get; private set; }

        private void PrintText(Graphics g, Rectangle bounds, string text, ContentAlignment align)
        {
            if (text == "") return;
            g.DrawString(text, printfont, printBrush, bounds, MakeStringFormat(align));
        }

        private StringFormat MakeStringFormat(ContentAlignment align)
        {
            StringFormat fmt = new StringFormat();
            switch (align)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    fmt.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    fmt.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    fmt.Alignment = StringAlignment.Far;
                    break;
            }
            switch (align)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    fmt.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    fmt.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    fmt.LineAlignment = StringAlignment.Far;
                    break;
            }
            return fmt;
        }

        private static float DisplayToInch(float disp) => (float)PrinterUnitConvert.Convert(disp, PrinterUnit.Display, PrinterUnit.ThousandthsOfAnInch) / 1000f;
        private static float InchToDisplay(float disp) => (float)PrinterUnitConvert.Convert(disp * 1000f, PrinterUnit.ThousandthsOfAnInch, PrinterUnit.Display);

        public void PrintPage(Form owner, PrintPageEventArgs e)
        {
            float lineHeightDots = e.Graphics.MeasureString("A\nA", printfont).Height - e.Graphics.MeasureString("A", printfont).Height;
            Font font = printfont;
            RectangleF cardRect = e.MarginBounds;
            cardRect.Inflate(0, -3 * lineHeightDots);

            if (OptionHandler.PrintMode == CardPrintMode.CardFrame &&
                    ((OptionHandler.CardWidthInches > DisplayToInch(cardRect.Width))
                  || (OptionHandler.CardHeightInches > DisplayToInch(cardRect.Height))))
            {
                e.HasMorePages = false;
                e.Cancel = true;
                MessageBox.Show(owner,
                    Language.Get("CardTooLargeToFitOnPage", "CardTooLargeToFitOnPage"),
                    Language.Get("ShortName", "Cardfile.NET"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            PrintText(e.Graphics, e.MarginBounds, headerLeft, ContentAlignment.TopLeft);
            PrintText(e.Graphics, e.MarginBounds, headerCenter, ContentAlignment.TopCenter);
            PrintText(e.Graphics, e.MarginBounds, headerRight, ContentAlignment.TopRight);

            PrintText(e.Graphics, e.MarginBounds, footerLeft, ContentAlignment.BottomLeft);
            PrintText(e.Graphics, e.MarginBounds, footerCenter, ContentAlignment.BottomCenter);
            PrintText(e.Graphics, e.MarginBounds, footerRight, ContentAlignment.BottomRight);

            if (OptionHandler.PrintMode == CardPrintMode.CardFrame)
            {
                // print as many cards as will fit
                float inchUnits = 100f;
                float cardHeightDots = inchUnits * OptionHandler.CardHeightInches;
                e.HasMorePages = false;
                for (; CardIndex <= endCard; )
                {
                    if (cardRect.Height < cardHeightDots)
                    {
                        e.HasMorePages = true;
                        break;
                    }
                    DrawCard(e.Graphics, font, State.File.Cards[CardIndex], cardRect);
                    cardRect = ShrinkFromTop(cardRect, cardHeightDots + inchUnits);
                    ++CardIndex;
                }
            }
            else if (OptionHandler.PrintMode == CardPrintMode.FullPage)
            {
                Card card = State.File.Cards[CardIndex++];
                PrintText(e.Graphics, Rectangle.Truncate(cardRect), card.Index, ContentAlignment.TopCenter);
                cardRect.Inflate(0, -2 * lineHeightDots);
                e.Graphics.DrawString(card.Text, font, printBrush, cardRect, new StringFormat(StringFormatFlags.LineLimit) { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
                e.HasMorePages = CardIndex <= endCard;
            }
        }

        private void DrawCard(Graphics g, Font font, Card card, RectangleF rect)
        {
            float dotsCardWidth = InchToDisplay(OptionHandler.CardWidthInches);
            float dotsCardHeight = InchToDisplay(OptionHandler.CardHeightInches);
            float dotsLineHeight = dotsCardHeight / OptionHandler.CardHeight;
            RectangleF cardRect = new RectangleF(rect.Left, rect.Top, dotsCardWidth, dotsCardHeight);
            RectangleF indexRect = new RectangleF(cardRect.Left, cardRect.Top + 1f, cardRect.Width, dotsLineHeight);
            RectangleF contentsRect = new RectangleF(cardRect.Left, cardRect.Top + dotsLineHeight, cardRect.Width, cardRect.Height - dotsLineHeight);
            float dotsTargetWidth = g.MeasureString(new string('A', OptionHandler.CardWidth), font).Width;
            float widthOffset = (dotsCardWidth - dotsTargetWidth) * .5f;
            string[] lines = card.Text.Replace("\r", "").Split('\n');

            indexRect.Inflate(-widthOffset, 0);
            g.DrawRectangle(printPen, cardRect.Left, cardRect.Top, cardRect.Width, cardRect.Height);
            g.DrawLine(printPen, cardRect.Left, cardRect.Top + dotsLineHeight, cardRect.Right, cardRect.Top + dotsLineHeight);

            StringFormat fmt = new StringFormat(StringFormatFlags.NoFontFallback) { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far };
            g.DrawString(card.Index, font, printBrush, indexRect, fmt);
            for (int i = 0; i < Math.Min(OptionHandler.CardHeight - 1, lines.Length); ++i)
                g.DrawString(lines[i], font, printBrush,
                            new RectangleF(indexRect.Left, indexRect.Top + dotsLineHeight * (i + 1), indexRect.Width, dotsLineHeight), fmt);
        }

        private RectangleF ShrinkFromTop(RectangleF rect, float dist)
        {
            return new RectangleF(rect.X, rect.Y + dist, rect.Width, rect.Height - dist);
        }
    }

    public enum CardPrintMode
    {
        CardFrame, FullPage
    }
}