using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CardfileDotNet.Localization
{
    public static class Language
    {
        private static Dictionary<string, string> strings;
        private static Dictionary<string, string> baseStrings;
        private static string activeLangCode = "";
        private const string baseLangCode = "en-US";

        static Language()
        {
            strings = new Dictionary<string, string>();
            baseStrings = new Dictionary<string, string>();
            ReadLanguageFile(baseStrings, languages[baseLangCode]);
            activeLangCode = baseLangCode;
        }

        public static string Get(string key)
        {
            return Get(key, "{" + key + "}");
        }

        public static string GetMenuText(string text)
        {
            return Get(text).Replace("&", "");
        }

        public static string Get(string key, string fallback)
        {
            if (strings.TryGetValue(key, out string str))
                return str;
            if (baseStrings.TryGetValue(key, out string str2))
                return str2;
            return fallback;
        }

        public static string GetCardinalNumber(string key, string fallback, int number)
        {
            return Get(key + "." + Pluralization.GetCardinalNumberKey(activeLangCode, number), fallback);
        }

        private static string GetControlProperty(string controlName, string propertyName)
        {
            return Get(controlName + "." + propertyName);
        }

        private static bool ShouldLocalize(string tag, string field)
        {
            if (tag != null && tag.StartsWith("Localizable:"))
                return tag.Split(':')[1].Split(',').Contains(field);
            return false;
        }

        public static void LocalizeControl(Control control)
        {
            if (ShouldLocalize(control.Tag?.ToString(), "Text"))
                control.Text = GetControlProperty(control.Name, "Text");
        }

        public static void LocalizeControl(ToolStripItem control)
        {
            if (ShouldLocalize(control.Tag?.ToString(), "Text"))
                control.Text = GetControlProperty(control.Name, "Text");
        }

        public static void LocalizeControls(Control parent, Control[] stopControls)
        {
            LocalizeControl(parent);
            foreach (Control c in parent.Controls.OfType<Control>())
            {
                if (!stopControls.Contains(c))
                    LocalizeControls(c, stopControls);
            }
            if (parent is ToolStrip m)
                foreach (ToolStripItem c in m.Items.OfType<ToolStripItem>())
                    LocalizeMenus(c);
        }

        public static void LocalizeMenus(ToolStripItem item)
        {
            LocalizeControl(item);
            if (item is ToolStripDropDownItem d)
                foreach (ToolStripItem c in d.DropDownItems.OfType<ToolStripItem>())
                    LocalizeMenus(c);
        }

        public static void SetLanguage(string code)
        {
            if (code == "" || !languages.ContainsKey(code))
                code = GetBestLanguageCode();
            ReadLanguageFile(strings, languages[code]);
            activeLangCode = code;
            LanguageChanged?.Invoke(null, new EventArgs());
        }

        private static string ReadLanguageEntry(string key, string file)
        {
            foreach (string line in file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!line.StartsWith("#") && line.Contains("="))
                {
                    string[] tok = line.Split(new char[] { '=' }, 2);
                    if (tok[0] == key)
                        return tok[1].Replace("\\n", Environment.NewLine).Replace("\\\\", "\\");
                }
            }
            return null;
        }

        private static void ReadLanguageFile(Dictionary<string, string> result, string file)
        {
            result.Clear();
            foreach (string line in file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!line.StartsWith("#") && line.Contains("="))
                {
                    string[] tok = line.Split(new char[] { '=' }, 2);
                    result[tok[0]] = tok[1].Replace("\\n", Environment.NewLine).Replace("\\\\", "\\");
                }
            }
        }

        public static string GetLanguageName(string code)
        {
            return ReadLanguageEntry("LanguageName", languages[code]);
        }

        public static string GetBestLanguageCode()
        {
            string currentCode = CultureInfo.InstalledUICulture.Name;
            if (languages.ContainsKey(currentCode))
                return currentCode;
            foreach (string code in languages.Keys)
            {
                if (code.Split('-')[0] == currentCode.Split('-')[0])
                    return code;
            }
            return baseLangCode;
        }

        internal static Dictionary<string, string> languages = new Dictionary<string, string>
        {
            { "en-US", Properties.Resources.lang_en_US },
            { "fi-FI", Properties.Resources.lang_fi_FI },
        };

        public static event EventHandler LanguageChanged;
    }
}
