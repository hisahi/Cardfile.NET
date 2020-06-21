using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public class BindableToolStripMenuItem : ToolStripMenuItem, IBindableComponent
    {
        private ControlBindingsCollection _dataBindings;
        private BindingContext _bindingContext;

        public ControlBindingsCollection DataBindings => _dataBindings ?? (_dataBindings = new ControlBindingsCollection(this));

        public BindingContext BindingContext
        {
            get => _bindingContext ?? (_bindingContext = new BindingContext());
            set => _bindingContext = value;
        }
    }
}
