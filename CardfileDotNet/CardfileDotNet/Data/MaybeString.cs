using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfileDotNet.Data
{
    [Serializable]
    public class MaybeString
    {
        private bool hasValue;
        private string inner;

        public MaybeString()
        {
            hasValue = false;
            inner = null;
        }

        public MaybeString(string s)
        {
            hasValue = true;
            inner = s;
        }

        public string Value
        {
            get => hasValue ? inner : null;
            set
            {
                inner = value;
                hasValue = value != null;
            }
        }

        public static explicit operator string(MaybeString m) => m.hasValue ? ":" + (m.Value ?? "") : "";
        public static explicit operator MaybeString(string s) => s.StartsWith(":") ? new MaybeString(s.Substring(1)) : new MaybeString();
    }
}
