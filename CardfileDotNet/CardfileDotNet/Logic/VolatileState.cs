using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CardfileDotNet.Logic
{
    public abstract class VolatileState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void Update(string name)
        {
            OnPropertyChanged(name);
        }

        protected bool Swap<T>(ref T variable, T value, [CallerMemberName] string name = "")
        {
            bool changed = !EqualityComparer<T>.Default.Equals(variable, value);
            variable = value;
            if (changed) OnPropertyChanged(name);
            return changed;
        }

        protected bool Swap<T>(ref T variable, T value, out T oldValue, [CallerMemberName] string name = "")
        {
            bool changed = !EqualityComparer<T>.Default.Equals(variable, value);
            oldValue = variable;
            variable = value;
            if (changed) OnPropertyChanged(name);
            return changed;
        }

        protected void Set<T>(ref T variable, T value, [CallerMemberName] string name = "")
        {
            variable = value;
            OnPropertyChanged(name);
        }

        public virtual T Get<T>(string key) where T : class
        {
            PropertyInfo prop = this.GetType().GetProperty(key, BindingFlags.Public);
            return prop.GetValue(this) as T;
        }
    }
}
