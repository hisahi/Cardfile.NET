using CardfileDotNet.Logic;
using System;
using System.Runtime.CompilerServices;

namespace CardfileDotNet.Data
{
    public class Card : VolatileState, ICloneable
    {
        private string _index;
        private string _rtf;
        private string _text;
        private AttachmentFile _file;

        internal Card() : this("") { }
        internal Card(string index) : this(index, "") { }
        internal Card(string index, string text)
        {
            Index = index;
            Contents = RtfTextConverter.ToRtf(text);
        }

        public string Index
        {
            get => _index;
            set
            {
                if (Swap(ref _index, value, out string old))
                    CardChanged?.Invoke(this, new CardChangedEventArgs(old, value));
            }
        }
        public string Contents
        {
            get => _rtf;
            set
            {
                if (Swap(ref _rtf, value, out string old))
                {
                    CardChanged?.Invoke(this, new CardChangedEventArgs(old, value));
                    Set(ref _text, RtfTextConverter.ToText(_rtf));
                    Update(nameof(ShortText));
                }
            }
        }
        public string Text
        {
            get => _text;
        }
        public string ShortText
        {
            get => Text.Replace("\r", "").Replace("\n", " ");
        }

        public AttachmentFile Attachment
        {
            get => _file;
            set
            {
                if (Swap(ref _file, value, out AttachmentFile old))
                    CardChanged?.Invoke(this, new CardChangedEventArgs(old, value));
            }
        }

        public void Clear()
        {
            Index = "";
            Contents = RtfTextConverter.ToRtf("");
            Attachment = null;
        }

        public object Clone()
        {
            Card clone = new Card();
            clone._index = this._index;
            clone._rtf = this._rtf;
            clone._text = this._text;
            return clone;
        }

        public delegate void CardChangedEventHandler(object sender, CardChangedEventArgs e);
        public event CardChangedEventHandler CardChanged;
    }

    public class CardChangedEventArgs : EventArgs
    {
        public string PropertyName { get; }
        public object OldValue { get; }
        public object NewValue { get; }

        public CardChangedEventArgs(object oldValue, object newValue, [CallerMemberName] string propertyName = "")
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}