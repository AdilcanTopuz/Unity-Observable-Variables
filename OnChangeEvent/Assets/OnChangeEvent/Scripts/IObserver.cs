using System;

namespace Act.Scripts.OnChanged
{
    public interface IObserver : IDisposable
    {
        void AddObservable(IObservable observale);
    }

}
