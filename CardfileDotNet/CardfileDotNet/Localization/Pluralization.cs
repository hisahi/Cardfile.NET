using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfileDotNet.Localization
{
    public static class Pluralization
    {
        // based on CLDR data

        public static NumberCategory GetCardinalNumberKey(string langCode, int number)
        {
            if (cardinalNumFuncs.ContainsKey(langCode))
                return cardinalNumFuncs[langCode](number);
            string langCodePrefix = langCode.Split('-')[0];
            if (cardinalNumFuncs.ContainsKey(langCodePrefix))
                return cardinalNumFuncs[langCodePrefix](number);

            return NumberCategory.Other;
        }

        private delegate NumberCategory CardinalNumberKeyFunction(int number);

        #region Dictionary
        private static Dictionary<string, CardinalNumberKeyFunction> cardinalNumFuncs = new Dictionary<string, CardinalNumberKeyFunction>()
        {
            { "af", GetCardinalNumberKey_one1_other },
            { "ak", GetCardinalNumberKey_one01_other },
            { "am", GetCardinalNumberKey_one01_other },
            { "an", GetCardinalNumberKey_one1_other },
            { "ar", GetCardinalNumberKey_ar },
            { "ars", GetCardinalNumberKey_ar },
            { "as", GetCardinalNumberKey_one01_other },
            { "asa", GetCardinalNumberKey_one1_other },
            { "ast", GetCardinalNumberKey_one1_other },
            { "az", GetCardinalNumberKey_one1_other },
            { "be", GetCardinalNumberKey_ru_uk_be },
            { "bem", GetCardinalNumberKey_one1_other },
            { "bez", GetCardinalNumberKey_one1_other },
            { "bg", GetCardinalNumberKey_one1_other },
            { "bho", GetCardinalNumberKey_one01_other },
            { "bn", GetCardinalNumberKey_one01_other },
            { "br", GetCardinalNumberKey_br },
            { "brx", GetCardinalNumberKey_one1_other },
            { "bs", GetCardinalNumberKey_sh },
            { "ca", GetCardinalNumberKey_one1_other },
            { "ce", GetCardinalNumberKey_one1_other },
            { "ceb", GetCardinalNumberKey_tl_ceb },
            { "cgg", GetCardinalNumberKey_one1_other },
            { "chr", GetCardinalNumberKey_one1_other },
            { "ckb", GetCardinalNumberKey_one1_other },
            { "cs", GetCardinalNumberKey_cs_sk },
            { "cy", GetCardinalNumberKey_cy },
            { "da", GetCardinalNumberKey_one1_other },
            { "de", GetCardinalNumberKey_one1_other },
            { "dsb", GetCardinalNumberKey_dsb_hsb },
            { "dv", GetCardinalNumberKey_one1_other },
            { "ee", GetCardinalNumberKey_one1_other },
            { "el", GetCardinalNumberKey_one1_other },
            { "en", GetCardinalNumberKey_one1_other },
            { "eo", GetCardinalNumberKey_one1_other },
            { "es", GetCardinalNumberKey_one1_other },
            { "et", GetCardinalNumberKey_one1_other },
            { "eu", GetCardinalNumberKey_one1_other },
            { "fa", GetCardinalNumberKey_one01_other },
            { "ff", GetCardinalNumberKey_one01_other },
            { "fi", GetCardinalNumberKey_one1_other },
            { "fil", GetCardinalNumberKey_tl_ceb },
            { "fo", GetCardinalNumberKey_one1_other },
            { "fr", GetCardinalNumberKey_one01_other },
            { "fur", GetCardinalNumberKey_one1_other },
            { "fy", GetCardinalNumberKey_one1_other },
            { "ga", GetCardinalNumberKey_ga },
            { "gd", GetCardinalNumberKey_gd },
            { "gl", GetCardinalNumberKey_one1_other },
            { "gsw", GetCardinalNumberKey_one1_other },
            { "gu", GetCardinalNumberKey_one01_other },
            { "guw", GetCardinalNumberKey_one01_other },
            { "gv", GetCardinalNumberKey_gv },
            { "ha", GetCardinalNumberKey_one1_other },
            { "haw", GetCardinalNumberKey_one1_other },
            { "he", GetCardinalNumberKey_he },
            { "hi", GetCardinalNumberKey_one01_other },
            { "hr", GetCardinalNumberKey_sh },
            { "hsb", GetCardinalNumberKey_dsb_hsb },
            { "hu", GetCardinalNumberKey_one1_other },
            { "hy", GetCardinalNumberKey_one01_other },
            { "ia", GetCardinalNumberKey_one1_other },
            { "io", GetCardinalNumberKey_one1_other },
            { "is", GetCardinalNumberKey_is_mk },
            { "it", GetCardinalNumberKey_one1_other },
            { "iu", GetCardinalNumberKey_one1_two2_other },
            { "jgo", GetCardinalNumberKey_one1_other },
            { "ji", GetCardinalNumberKey_one1_other },
            { "jmc", GetCardinalNumberKey_one1_other },
            { "ka", GetCardinalNumberKey_one1_other },
            { "kab", GetCardinalNumberKey_one01_other },
            { "kaj", GetCardinalNumberKey_one1_other },
            { "kcg", GetCardinalNumberKey_one1_other },
            { "kk", GetCardinalNumberKey_one1_other },
            { "kkj", GetCardinalNumberKey_one1_other },
            { "kl", GetCardinalNumberKey_one1_other },
            { "kn", GetCardinalNumberKey_one01_other },
            { "ks", GetCardinalNumberKey_one1_other },
            { "ksb", GetCardinalNumberKey_one1_other },
            { "ksh", GetCardinalNumberKey_zero0_one1_other },
            { "ku", GetCardinalNumberKey_one1_other },
            { "kw", GetCardinalNumberKey_one1_two2_other },
            { "ky", GetCardinalNumberKey_one1_other },
            { "lag", GetCardinalNumberKey_one01_other },
            { "lb", GetCardinalNumberKey_one1_other },
            { "lg", GetCardinalNumberKey_one1_other },
            { "ln", GetCardinalNumberKey_one01_other },
            { "lt", GetCardinalNumberKey_lt },
            { "lv", GetCardinalNumberKey_lv },
            { "mas", GetCardinalNumberKey_one1_other },
            { "mg", GetCardinalNumberKey_one01_other },
            { "mgo", GetCardinalNumberKey_one1_other },
            { "mk", GetCardinalNumberKey_is_mk },
            { "ml", GetCardinalNumberKey_one1_other },
            { "mn", GetCardinalNumberKey_one1_other },
            { "mr", GetCardinalNumberKey_one01_other },
            { "mt", GetCardinalNumberKey_mt },
            { "nah", GetCardinalNumberKey_one1_other },
            { "naq", GetCardinalNumberKey_one1_two2_other },
            { "nb", GetCardinalNumberKey_one1_other },
            { "nd", GetCardinalNumberKey_one1_other },
            { "ne", GetCardinalNumberKey_one1_other },
            { "nl", GetCardinalNumberKey_one1_other },
            { "nn", GetCardinalNumberKey_one1_other },
            { "nnh", GetCardinalNumberKey_one1_other },
            { "no", GetCardinalNumberKey_one1_other },
            { "nr", GetCardinalNumberKey_one1_other },
            { "nso", GetCardinalNumberKey_one01_other },
            { "ny", GetCardinalNumberKey_one1_other },
            { "nyn", GetCardinalNumberKey_one1_other },
            { "om", GetCardinalNumberKey_one1_other },
            { "or", GetCardinalNumberKey_one1_other },
            { "os", GetCardinalNumberKey_one1_other },
            { "pa", GetCardinalNumberKey_one01_other },
            { "pap", GetCardinalNumberKey_one1_other },
            { "pl", GetCardinalNumberKey_pl },
            { "prg", GetCardinalNumberKey_lv },
            { "ps", GetCardinalNumberKey_one1_other },
            { "pt", GetCardinalNumberKey_one1_other },
            { "pt-BR", GetCardinalNumberKey_one01_other },
            { "pt-PT", GetCardinalNumberKey_one1_other },
            { "rm", GetCardinalNumberKey_one1_other },
            { "ro", GetCardinalNumberKey_ro },
            { "rof", GetCardinalNumberKey_one1_other },
            { "ru", GetCardinalNumberKey_ru_uk_be },
            { "rwk", GetCardinalNumberKey_one1_other },
            { "saq", GetCardinalNumberKey_one1_other },
            { "sat", GetCardinalNumberKey_one1_two2_other },
            { "sc", GetCardinalNumberKey_one1_other },
            { "scn", GetCardinalNumberKey_one1_other },
            { "sd", GetCardinalNumberKey_one1_other },
            { "sdh", GetCardinalNumberKey_one1_other },
            { "se", GetCardinalNumberKey_one1_two2_other },
            { "seh", GetCardinalNumberKey_one1_other },
            { "sh", GetCardinalNumberKey_sh },
            { "shi", GetCardinalNumberKey_shi },
            { "si", GetCardinalNumberKey_one01_other },
            { "sk", GetCardinalNumberKey_cs_sk },
            { "sl", GetCardinalNumberKey_sl },
            { "sma", GetCardinalNumberKey_one1_two2_other },
            { "smi", GetCardinalNumberKey_one1_two2_other },
            { "smj", GetCardinalNumberKey_one1_two2_other },
            { "smn", GetCardinalNumberKey_one1_two2_other },
            { "sms", GetCardinalNumberKey_one1_two2_other },
            { "sn", GetCardinalNumberKey_one1_other },
            { "so", GetCardinalNumberKey_one1_other },
            { "sq", GetCardinalNumberKey_one1_other },
            { "sr", GetCardinalNumberKey_sh },
            { "ss", GetCardinalNumberKey_one1_other },
            { "ssy", GetCardinalNumberKey_one1_other },
            { "st", GetCardinalNumberKey_one1_other },
            { "sv", GetCardinalNumberKey_one1_other },
            { "sw", GetCardinalNumberKey_one1_other },
            { "syr", GetCardinalNumberKey_one1_other },
            { "ta", GetCardinalNumberKey_one1_other },
            { "te", GetCardinalNumberKey_one1_other },
            { "teo", GetCardinalNumberKey_one1_other },
            { "ti", GetCardinalNumberKey_one01_other },
            { "tig", GetCardinalNumberKey_one1_other },
            { "tk", GetCardinalNumberKey_one1_other },
            { "tl", GetCardinalNumberKey_tl_ceb },
            { "tn", GetCardinalNumberKey_one1_other },
            { "tr", GetCardinalNumberKey_one1_other },
            { "ts", GetCardinalNumberKey_one1_other },
            { "tzm", GetCardinalNumberKey_tzm },
            { "ug", GetCardinalNumberKey_one1_other },
            { "uk", GetCardinalNumberKey_ru_uk_be },
            { "ur", GetCardinalNumberKey_one1_other },
            { "uz", GetCardinalNumberKey_one1_other },
            { "ve", GetCardinalNumberKey_one1_other },
            { "vo", GetCardinalNumberKey_one1_other },
            { "vun", GetCardinalNumberKey_one1_other },
            { "wa", GetCardinalNumberKey_one01_other },
            { "wae", GetCardinalNumberKey_one1_other },
            { "xh", GetCardinalNumberKey_one1_other },
            { "xog", GetCardinalNumberKey_one1_other },
            { "yi", GetCardinalNumberKey_one1_other },
            { "zu", GetCardinalNumberKey_one01_other },
        };
        #endregion

        #region Implementations
        private static NumberCategory GetCardinalNumberKey_one01_other(int number)
        {
            return (number == 0 || number == 1) ? NumberCategory.One : NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_one1_other(int number)
        {
            return number == 1 ? NumberCategory.One : NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_zero0_one1_other(int number)
        {
            switch (number)
            {
                case 0: return NumberCategory.Zero;
                case 1: return NumberCategory.One;
                default: return NumberCategory.Other;
            }
        }

        private static NumberCategory GetCardinalNumberKey_one1_two2_other(int number)
        {
            switch (number)
            {
                case 1: return NumberCategory.One;
                case 2: return NumberCategory.Two;
                default: return NumberCategory.Other;
            }
        }

        private static NumberCategory GetCardinalNumberKey_ro(int number)
        {
            int n = number % 100;
            if (number == 1)
                return NumberCategory.One;
            if (number == 0 || (2 <= n && n <= 19))
                return NumberCategory.Few;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_sh(int number)
        {
            int n = number % 100;
            if (n < 10 || n > 20)
            {
                int v = number % 10;
                if (2 <= v && v <= 4)
                    return NumberCategory.Few;
            }
            return number == 1 ? NumberCategory.One : NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_sl(int number)
        {
            int n = number % 100;
            if (n == 1)
                return NumberCategory.One;
            if (n == 2)
                return NumberCategory.Two;
            if (n == 3 || n == 4)
                return NumberCategory.Few;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_dsb_hsb(int number)
        {
            int n = number % 100;
            switch (n)
            {
                case 1: return NumberCategory.One;
                case 2: return NumberCategory.Two;
                case 3:
                case 4: return NumberCategory.Few;
                default: return NumberCategory.Other;
            }
        }

        private static NumberCategory GetCardinalNumberKey_cs_sk(int number)
        {
            if (number == 1)
                return NumberCategory.One;
            if (2 <= number && number <= 4)
                return NumberCategory.Few;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_pl(int number)
        {
            int d = number % 10;
            if (number == 1)
                return NumberCategory.One;
            if (11 <= number && number <= 19)
                return NumberCategory.Many;
            if (2 <= d && d <= 4)
                return NumberCategory.Few;
            return NumberCategory.Many;
        }

        private static NumberCategory GetCardinalNumberKey_ru_uk_be(int number)
        {
            int d = number % 10, n = number % 100;
            if (d == 0 || (5 <= n && n <= 14) || (5 <= d && d <= 9))
                return NumberCategory.Many;
            if (d == 1)
                return NumberCategory.One;
            if (2 <= d && d <= 4)
                return NumberCategory.Few;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_is_mk(int number)
        {
            int d = number % 10, n = number % 100;
            return (d == 1 && n != 11) ? NumberCategory.One : NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_lt(int number)
        {
            int d = number % 10, n = number % 100;
            if (d == 0 || (11 <= n && n <= 19))
                return NumberCategory.Other;
            if (d == 1)
                return NumberCategory.One;
            return NumberCategory.Few;
        }

        private static NumberCategory GetCardinalNumberKey_lv(int number)
        {
            int d = number % 10, n = number % 100;
            if (d == 0 || (11 <= n && n <= 19))
                return NumberCategory.Zero;
            if (d == 1)
                return NumberCategory.One;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_br(int number)
        {
            int d = number % 10, n = number % 100, h = n / 10;
            if (h == 1 || h == 7 || h == 9)
                return NumberCategory.Other;
            if (d == 1)
                return NumberCategory.One;
            if (d == 2)
                return NumberCategory.Two;
            if (d == 3 || d == 4 || d == 9)
                return NumberCategory.Few;
            if (number > 0 && (number % 1000000) == 0)
                return NumberCategory.Many;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_ga(int number)
        {
            switch (number)
            {
                case 1: return NumberCategory.One;
                case 2: return NumberCategory.Two;
                case 3:
                case 4:
                case 5:
                case 6: return NumberCategory.Few;
                case 7:
                case 8:
                case 9:
                case 10: return NumberCategory.Many;
                default: return NumberCategory.Other;
            }
        }

        private static NumberCategory GetCardinalNumberKey_gd(int number)
        {
            if (number == 1 || number == 11)
                return NumberCategory.One;
            if (number == 2 || number == 12)
                return NumberCategory.Two;
            if (3 <= number && number <= 19)
                return NumberCategory.Few;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_cy(int number)
        {
            if (number == 0)
                return NumberCategory.Zero;
            if (number == 1)
                return NumberCategory.One;
            if (number == 2)
                return NumberCategory.Two;
            if (number == 3)
                return NumberCategory.Few;
            if (number == 6)
                return NumberCategory.Many;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_gv(int number)
        {
            int d = number % 10;
            if (d == 1)
                return NumberCategory.One;
            if (d == 2)
                return NumberCategory.Two;
            if ((number % 20) == 0)
                return NumberCategory.Few;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_ar(int number)
        {
            int n = number % 100;
            if (number == 0)
                return NumberCategory.Zero;
            if (number == 1)
                return NumberCategory.One;
            if (number == 2)
                return NumberCategory.Two;
            if (3 <= n && n <= 10)
                return NumberCategory.Few;
            if (n > 10)
                return NumberCategory.Many;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_he(int number)
        {
            int d = number % 10, n = number % 100;
            if (number == 1)
                return NumberCategory.One;
            if (number == 2)
                return NumberCategory.Two;
            return (number > 10 && d == 0) ? NumberCategory.Many : NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_mt(int number)
        {
            int n = number % 100;
            if (number == 1)
                return NumberCategory.One;
            if (number == 0 || (2 <= n && n <= 10))
                return NumberCategory.Few;
            if (11 <= n && n <= 19)
                return NumberCategory.Many;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_tzm(int number)
        {
            if (number < 2 || (11 <= number && number <= 99))
                return NumberCategory.One;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_shi(int number)
        {
            if (number == 0 || number == 1)
                return NumberCategory.One;
            if (number <= 10)
                return NumberCategory.Few;
            return NumberCategory.Other;
        }

        private static NumberCategory GetCardinalNumberKey_tl_ceb(int number)
        {
            int n = number % 100;
            return (n == 4 || n == 6 || n == 9) ? NumberCategory.Other : NumberCategory.One;
        }

        #endregion
    }

    public enum NumberCategory
    {
        Other, Zero, One, Two, Few, Many
    }
}
