using CardfileDotNet.Logic;
using System.Drawing;
using System.Windows.Forms;

namespace CardfileDotNet.Data
{
    internal class RtfTextConverter
    {
        private static RichTextBox box = new RichTextBox();

        static RtfTextConverter()
        {
            box.Font = new Font(FontFamily.GenericMonospace, OptionHandler.FontSize);
            OptionHandler.OptionsUpdated += OptionHandler_OptionsUpdated;
        }

        private static void OptionHandler_OptionsUpdated(object sender, System.EventArgs e)
        {
            box.SelectAll();
            box.Font = box.SelectionFont = new Font(FontFamily.GenericMonospace, OptionHandler.FontSize);
        }

        /*
         * you call it ugly. I call it fast - I can rely on Windows to do the
         * conversion instead of having to parse it myself. of course, it would
         * be better if .NET actually provided a class to do this sort of thing,
         * but that would probably end up using this method initially anyway.
         */

        public static string ToRtf(string text)
        {
            box.Text = text;
            return box.Rtf;
        }

        public static string ToText(string rtf)
        {
            box.Rtf = rtf;
            return box.Text;
        }

        private RtfTextConverter() { }
    }
}