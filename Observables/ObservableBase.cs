namespace Observables
{
    public abstract class ObservableBase : IObservable
    {
        public abstract Type GenericType { get; }

        protected abstract event EventHandler<ValueChangedEventArgs<object>> OnChangedBase;
        protected abstract event EventHandler<ValueChangedEventArgs<object>> OnBeforeChangedBase;

        event EventHandler<ValueChangedEventArgs<object>> IReadOnlyObservable.OnChanged
        {
            add { OnChangedBase += value; }
            remove { OnChangedBase -= value; }
        }

        event EventHandler<ValueChangedEventArgs<object>> IReadOnlyObservable.OnBeforeChanged
        {
            add { OnBeforeChangedBase += value; }
            remove { OnBeforeChangedBase -= value; }
        }



        protected abstract object GetBase();
        protected abstract bool SetBase(object value);



        object IReadOnlyObservable.Get()
        {
            return GetBase();
        }

        bool IObservable.Set(object value)
        {
            return SetBase(value);
        }
    }
}