using System.Collections.Generic;
using UnityEngine;

namespace Act.Scripts.OnChanged
{
    public class ObservableLogger : IObserver
    {
        private List<IObservable> _observables;

        public ObservableLogger()
        {
            _observables = new List<IObservable>();
        }

        public ObservableLogger(IObservable observable)
        {
            _observables = new List<IObservable> { observable };
            observable.OnChanged += OnChanged;
        }

        public ObservableLogger(IObservable[] observables)
        {
            _observables = new List<IObservable>(observables);
            foreach (var observable in observables)
                observable.OnChanged += OnChanged;
        }

        public void AddObservable(IObservable observale)
        {
            if (_observables.Contains(observale))
                return;

            _observables.Add(observale);
            observale.OnChanged += OnChanged;
        }

        public void Dispose()
        {
            foreach (var observable in _observables)
                observable.OnChanged -= OnChanged;
        }

        private void OnChanged(object o)
        {
            Debug.Log($"{o.GetType().Name} value changed. New value {o.ToString()}");
        }
    }

}
