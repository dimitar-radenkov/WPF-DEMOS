namespace _04.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using _04.Utils.EventArguments;

    public class CollectionVM<T> : TextVM
    {
        private T selected;

        public event EventHandler<ValueChangedEventArgs<T>> SelectionChanged;

        public ObservableCollection<T> Items { get; set; }

        public T Selected
        {
            get { return this.selected; }
            set
            {
                var args = new ValueChangedEventArgs<T>(this.Selected, value);
                if (SetProperty(ref this.selected, value))
                {
                    this.SelectionChanged?.Invoke(this, args);
                }
            }
        }

        public CollectionVM(IEnumerable<T> items)
        {
            this.Items = new ObservableCollection<T>(items);
            this.selected = default(T);
        }

        public CollectionVM()
        {
            this.Items = new ObservableCollection<T>();
            this.selected = default(T);
        }
    }
}
