using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfileDotNet.Logic
{
    public class FindRequest
    {
        public string Text { get; }
        public FindDirection Direction { get; }
        public bool MatchCase { get; }

        public FindRequest(string findText, FindDirection direction, bool matchCase)
        {
            Text = findText;
            Direction = direction;
            MatchCase = matchCase;
        }
    }

    public enum FindDirection
    {
        Forwards, Backwards
    }
}
