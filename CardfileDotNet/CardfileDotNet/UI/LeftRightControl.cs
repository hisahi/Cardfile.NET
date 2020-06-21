using System;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public partial class LeftRightControl : UserControl
    {
        public LeftRightControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallDecrement || e.Type == ScrollEventType.SmallIncrement)
            {
                if (e.NewValue < 0)
                    LeftButton?.Invoke(this, new EventArgs());
                else if (e.NewValue > 0)
                    RightButton?.Invoke(this, new EventArgs());
            }
            e.NewValue = 0;
        }

        public event EventHandler LeftButton;
        public event EventHandler RightButton;
    }
}
