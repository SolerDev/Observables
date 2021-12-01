namespace Observables
{
    public interface IObservable : IReadOnlyObservable
    {
        void Set(object value);
    }
    public interface IObservable<T> : IObservable, IReadOnlyObservable<T>
    {
        void Set(T value);
    }
}