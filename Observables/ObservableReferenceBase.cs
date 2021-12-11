using UnityEngine;

namespace Observables
{
    [ExecuteAlways]
    public abstract class ObservableReferenceBase : ScriptableObject, IObservable
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


        bool IObservable.Set(object value)
        {
            return SetBase(value);
        }
        object IReadOnlyObservable.Get()
        {
            return GetBase();
        }


        protected abstract bool SetBase(object value);
        protected abstract object GetBase();



        private void Awake()
        {
            InstantiateObservable();
        }

        protected abstract void InstantiateObservable();
    }
}
