using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace CardfileDotNet.UI
{
    public class BindableListView : ListView, INotifyPropertyChanged
    {
        List<Getter> columnGetters = new List<Getter>();
        public delegate object Getter(object instance);

        public BindableListView() : base()
        {
            this.ColumnReordered += (s, e) => HandleSource(_dataSource);
            base.SelectedIndexChanged += (s, e) =>
            {
                if (!_ignoreBaseSelectEvent && SelectedIndex >= 0)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
                    SelectedIndexChanged?.Invoke(this, new EventArgs());
                }
            };
        }

        public ListViewItem GetItem<T>(T item)
        {
            IList<T> items = _dataSource as IList<T>;
            int index = items.IndexOf(item);
            return index >= 0 ? this.Items[index] : null;
        }

        public object DataSource
        {
            get => _dataSource;
            set
            {
                if (_dataSource is BindingSource bs1)
                    bs1.DataSourceChanged -= OnBindingSourceUpdated;
                if (_dataSource is IBindingList ibl)
                    ibl.ListChanged -= OnBindingListChanged;
                _dataSource = value;
                HandleSource(_dataSource);
            }
        }

        private void OnBindingSourceUpdated(object sender, EventArgs e)
        {
            HandleSourceInternal((_dataSource as BindingSource).DataSource);
        }

        private void HandleSource(object dataSource)
        {
            if (dataSource is BindingSource bs2)
            {
                bs2.DataSourceChanged += OnBindingSourceUpdated;
                HandleSourceInternal(bs2.DataSource);
            }
            else
            {
                HandleSourceInternal(_dataSource);
            }
        }

        private void HandleSourceInternal(object dataSource)
        {
            _underlyingDataSource = dataSource;
            if (dataSource != null)
            {
                ReadCompleteList(dataSource);
                if (dataSource is IBindingList ibl2)
                    ibl2.ListChanged += OnBindingListChanged;
            }
            else
            {
                this.Items.Clear();
            }
        }

        private ListViewItem ConvertItemToListViewItem(object item)
        {
            string[] subItems = columnGetters.Select(getter => getter == null ? "" : (getter(item)?.ToString() ?? "")).ToArray();
            return new ListViewItem(subItems);
        }

        private void ReadCompleteList(object list)
        {
            PropertyInfo indexer = list.GetType().GetProperty("Item");
            if (mReadCompleteListGeneric == null)
                mReadCompleteListGeneric = GetType().GetMethod(nameof(ReadCompleteListGeneric), BindingFlags.Instance | BindingFlags.NonPublic);
            mReadCompleteListGeneric.MakeGenericMethod(indexer.PropertyType).Invoke(this, new object[] { list });
        }

        private MethodInfo mReadCompleteListGeneric = null;
        private void ReadCompleteListGeneric<T>(object list)
        {
            IList<T> items = list as IList<T>;
            GetListItem = (int index) => items[index];
            this.BeginUpdate();
            RescanColumns(typeof(T));
            this.Items.Clear();
            this.Items.AddRange(items.Select<T, ListViewItem>(x => ConvertItemToListViewItem(x)).ToArray());
            this.EndUpdate();
        }

        private MethodInfo mCreatePropertyGetterDelegate = null;
        private Getter CreatePropertyGetterDelegate<T>(string displayMember)
        {
            PropertyInfo prop = typeof(T).GetProperty(displayMember);
            MethodInfo getm = prop.GetMethod;
            Type gmt = typeof(Func<,>).MakeGenericType(prop.DeclaringType, prop.PropertyType);
            Func<T,object> dlg = (Func<T, object>)getm.CreateDelegate(gmt);
            return (object instance) => dlg((T)instance);
        }

        private void RescanColumns(Type innerType)
        {
            columnGetters.Clear();

            foreach (ColumnHeader column in this.Columns)
            {
                if (column is BindableColumnHeader bch)
                {
                    if (mCreatePropertyGetterDelegate == null)
                        mCreatePropertyGetterDelegate = GetType().GetMethod(nameof(CreatePropertyGetterDelegate), BindingFlags.Instance | BindingFlags.NonPublic);
                    columnGetters.Add((Getter)mCreatePropertyGetterDelegate.MakeGenericMethod(innerType).Invoke(this, new object[] { bch.DisplayMember }));
                }
                else
                    columnGetters.Add(null);
            }
        }

        private void OnBindingListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    HandleSource(_dataSource);
                    break;
                case ListChangedType.ItemChanged:
                    this.BeginUpdate();
                    Items[e.NewIndex] = ConvertItemToListViewItem(GetListItem(e.NewIndex));
                    this.EndUpdate();
                    break;
                case ListChangedType.ItemAdded:
                    this.BeginUpdate();
                    Items.Insert(e.NewIndex, ConvertItemToListViewItem(GetListItem(e.NewIndex)));
                    this.EndUpdate();
                    break;
                case ListChangedType.ItemDeleted:
                    this.BeginUpdate();
                    Items.RemoveAt(e.NewIndex);
                    this.EndUpdate();
                    break;
                case ListChangedType.ItemMoved:
                    this.BeginUpdate();
                    {
                        ListViewItem lvi = Items[e.OldIndex];
                        Items.RemoveAt(e.OldIndex);
                        Items.Insert(e.NewIndex, lvi);
                    }
                    this.EndUpdate();
                    break;
            }
        }

        public int SelectedIndex
        {
            get => SelectedIndices.Count > 0 ? SelectedIndices[0] : (FocusedItem != null ? FocusedItem.Index : -1);
            set
            {
                if (SelectedIndex != value)
                {
                    _ignoreBaseSelectEvent = true;
                    Items[value].Selected = true;
                    if (value >= 0)
                    {
                        EnsureVisible(value);
                        FocusedItem = Items[value];
                    }
                    else
                        FocusedItem = null;
                    _ignoreBaseSelectEvent = false;
                    SelectedIndexChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        private Func<int, object> GetListItem;
        private object _dataSource;
        private object _underlyingDataSource;
        private bool _ignoreBaseSelectEvent;

        public event PropertyChangedEventHandler PropertyChanged;
        public new event EventHandler SelectedIndexChanged;
    }
}