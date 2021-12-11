namespace Observables
{
    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T? OldValue { get; init; }
        public T? NewValue { get; init; }

        public ValueChangedEventArgs(T? oldValue, T? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}