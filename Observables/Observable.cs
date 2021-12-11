namespace Observables
{
    public class Observable<T> : ObservableBase, IObservable<T>
    {
        private T? _currentValue;
        public override Type GenericType => typeof(T);

        public event EventHandler<ValueChangedEventArgs<T>> OnChanged;
        public event EventHandler<ValueChangedEventArgs<T>> OnBeforeChanged;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnChangedBase;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnBeforeChangedBase;

        public bool Equals(T? other)
        {
            return other != null && other.Equals(_currentValue);
        }

        public T Get()
        {
            return _currentValue;
        }

        public bool Set(T newValue)
        {
            if (Equals(_currentValue, newValue))
                return false;

            var oldValue = _currentValue;


            //todo: return here when I'm wiser. Is this the best way to create the ValueChangedEventArgs<object>?
            var e = new ValueChangedEventArgs<T>(oldValue, newValue);
            var eBase = new ValueChangedEventArgs<object>(oldValue, newValue);

            OnBeforeChanged?.Invoke(this, e);
            OnBeforeChangedBase?.Invoke(this, eBase);
            _currentValue = newValue;
            OnChanged?.Invoke(this, e);
            OnChangedBase?.Invoke(this, eBase);

            return true;
        }

        protected override object GetBase()
        {
            return Get();
        }

        protected override bool SetBase(object value)
        {
            return Set((T)value);
        }
    }
}