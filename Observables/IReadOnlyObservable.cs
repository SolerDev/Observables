namespace Observables
{
    public interface IReadOnlyObservable : IGeneric
    {
        object Get();
        event EventHandler<ValueChangedEventArgs<object>> OnBeforeChanged;
        event EventHandler<ValueChangedEventArgs<object>> OnChanged;
    }

    public interface IReadOnlyObservable<T> : IReadOnlyObservable, IEquatable<T>
    {
        new T Get();
        new event EventHandler<ValueChangedEventArgs<T>> OnBeforeChanged;
        new event EventHandler<ValueChangedEventArgs<T>> OnChanged;
    }
}