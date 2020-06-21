using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    internal class BindableColumnHeader : ColumnHeader
    {
        public BindableColumnHeader() : base()
        {
        }

        public string DisplayMember { get; internal set; }
    }
}