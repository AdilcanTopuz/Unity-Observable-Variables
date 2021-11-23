using System;

public interface IObservable
{
    event Action<object> OnChanged;
}
