namespace Observables
{
    public class ObservableReference<T> : ObservableReferenceBase, IObservable<T>
    {
        private IObservable<T> _observable;

        public override Type GenericType => _observable.GenericType;

        protected override event EventHandler<ValueChangedEventArgs<object>> OnChangedBase;
        protected override event EventHandler<ValueChangedEventArgs<object>> OnBeforeChangedBase;

        public event EventHandler<ValueChangedEventArgs<T>> OnChanged
        {
            add { _observable.OnChanged += value; }
            remove { _observable.OnChanged -= value; }
        }

        public event EventHandler<ValueChangedEventArgs<T>> OnBeforeChanged
        {
            add { _observable.OnBeforeChanged += value; }
            remove { _observable.OnBeforeChanged -= value; }
        }

        protected override object GetBase()
        {
            return Get();
        }

        protected override bool SetBase(object value)
        {
            return Set((T)value);
        }




        protected override void InstantiateObservable()
        {
            _observable = new Observable<T>();
        }

        public bool Set(T value)
        {
            return _observable.Set(value);
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