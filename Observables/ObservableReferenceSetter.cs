using UnityEngine;

namespace Observables
{
    [ExecuteAlways]
    public class ObservableReferenceSetter : MonoBehaviour
    {
        [SerializeField] private IObservable _observable;


        private void Reset()
        {
            SetObservableComponent();
        }

        private void OnValidate()
        {
            SetObservableComponent();
        }

        private void SetObservableComponent()
        {
            var componentType = _observable.InstanceType;
            if (TryGetComponent(componentType, out var component))
                _observable.Set(component);
            else
                Debug.LogError($"Unnable to find component of type {componentType} on {this}", this);
        }
    }
}