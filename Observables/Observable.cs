namespace Observables
{
    public class Observable<T> : ObservableBase, IObservable<T>
    {
        private T _currentValue;
        public override Type InstanceType => typeof(T);

        public event EventHandler<ValueChangedEventArgs<T>> OnChanged;
        public event EventHandler<ValueChangedEventArgs<T>> OnBeforeChanged;
        public event EventHandler<ValueChangedEventArgs<T>> OnAfterChanged;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnChangedBase;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnBeforeChangedBase;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnAfterChangedBase;

        public bool Equals(T? other)
        {
            throw new NotImplementedException();
        }

        public T Get()
        {
            return _currentValue;
        }

        public void Set(T newValue)
        {
            if (Equals(_currentValue, newValue))
                return;

            var oldValue = _currentValue;

            var e = new ValueChangedEventArgs<T>(oldValue, newValue);
            //todo: come back here when I'm wiser. Is this the best way to create the ValueChangedEventArgs<object>?
            var eBase = new ValueChangedEventArgs<object>(oldValue, newValue);

            OnBeforeChanged?.Invoke(this, e);
            OnBeforeChangedBase?.Invoke(this, eBase);
            _currentValue = newValue;
            OnChanged?.Invoke(this, e);
            OnChangedBase?.Invoke(this, eBase);
            OnAfterChanged?.Invoke(this, e);
            OnAfterChangedBase?.Invoke(this, eBase);
        }

        protected override object GetBase()
        {
            return Get();
        }

        protected override void SetBase(object value)
        {
            Set((T)value);
        }
    }
}