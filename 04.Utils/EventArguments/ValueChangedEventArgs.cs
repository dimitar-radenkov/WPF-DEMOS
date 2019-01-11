namespace _04.Utils.EventArguments
{
    using System;

    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T PreviousValue { get; }
        public T CurrentValue { get; }

        public ValueChangedEventArgs(T previousValue, T currentValue)
        {
            this.PreviousValue = previousValue;
            this.CurrentValue = currentValue;
        }
    }
}
