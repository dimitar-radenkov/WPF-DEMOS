using System;
using _04.Utils.EventArguments;

namespace _04.Utils
{
    public class TextVM : BaseVM
    {
        private string text;
        private bool isReadOnly;
        private int maxLength;

        public event EventHandler<ValueChangedEventArgs<string>> TextChanged;

        public string Text
        {
            get { return this.text; }
            set
            {
                var args = new ValueChangedEventArgs<string>(this.Text, value);
                if (this.SetProperty(ref this.text, value))
                {
                    this.TextChanged?.Invoke(this, args);      
                }              
            }
        }

        public bool IsReadOnly
        {
            get => this.isReadOnly;
            set => SetProperty(ref this.isReadOnly, value);
        }

        public int MaxLength
        {
            get => this.maxLength;
            set => SetProperty(ref this.maxLength, value);
        }

        public TextVM()
        {
            this.text = string.Empty;
            this.isReadOnly = false;
            this.MaxLength = int.MaxValue;
        }
    }
}
