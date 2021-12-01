namespace Observables
{
    public class ObservableReference<T> : ObservableReferenceBase, IObservable<T>
    {
        private IObservable<T> _observable;

        public override Type InstanceType => _observable.InstanceType;

        protected override event EventHandler<ValueChangedEventArgs<object>> OnChangedBase;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnBeforeChangedBase;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnAfterChangedBase;

        public event EventHandler<ValueChangedEventArgs<T>> OnChanged
        {
            add
            {
                _observable.OnChanged += value;
            }

            remove
            {
                _observable.OnChanged -= value;
            }
        }

        public event EventHandler<ValueChangedEventArgs<T>> OnBeforeChanged
        {
            add
            {
                _observable.OnBeforeChanged += value;
            }

            remove
            {
                _observable.OnBeforeChanged -= value;
            }
        }

        public event EventHandler<ValueChangedEventArgs<T>> OnAfterChanged
        {
            add
            {
                _observable.OnAfterChanged += value;
            }

            remove
            {
                _observable.OnAfterChanged -= value;
            }
        }

        protected override object GetBase()
        {
            return Get();
        }

        protected override void SetBase(object value)
        {
            Set((T)value);
        }




        protected override void InstantiateObservable()
        {
            _observable = new Observable<T>();
        }

        public void Set(T value)
        {
            _observable.Set(value);
        }

        public T Get()
        {
            return _observable.Get();
        }

        public bool Equals(T? other)
        {
            return _observable.Equals(other);
        }
    }
}