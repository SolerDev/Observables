using UnityEngine;

namespace Observables
{
    [ExecuteAlways]
    public abstract class ObservableReferenceBase : ScriptableObject, IObservable
    {
        public abstract Type InstanceType { get; }

        protected abstract event EventHandler<ValueChangedEventArgs<object>> OnChangedBase;
        protected abstract event EventHandler<ValueChangedEventArgs<object>> OnBeforeChangedBase;
        protected abstract event EventHandler<ValueChangedEventArgs<object>> OnAfterChangedBase;

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
        event EventHandler<ValueChangedEventArgs<object>> IReadOnlyObservable.OnAfterChanged
        {
            add { OnAfterChangedBase += value; }
            remove { OnAfterChangedBase -= value; }
        }


        void IObservable.Set(object value)
        {
            SetBase(value);
        }
        object IReadOnlyObservable.Get()
        {
            return GetBase();
        }


        protected abstract void SetBase(object value);
        protected abstract object GetBase();



        private void Awake()
        {
            InstantiateObservable();
        }

        protected abstract void InstantiateObservable();
    }
}
