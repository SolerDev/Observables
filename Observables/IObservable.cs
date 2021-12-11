namespace Observables
{
    public interface IObservable : IReadOnlyObservable
    {
        bool Set(object value);
    }
    public interface IObservable<T> : IObservable, IReadOnlyObservable<T>
    {
        bool Set(T value);
    }
}