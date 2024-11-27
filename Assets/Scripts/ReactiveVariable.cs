using System;

public class ReactiveVariable<T> : IReadOnlyVariable<T> where T : IComparable 
{
    public event Action<T,T> Changed;

    private T _value;

    public ReactiveVariable()
    {
        Value = default(T);
    }

    public ReactiveVariable(T value)
    {
        _value = value;
    }

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value;

            _value = value;

            if (_value.CompareTo(oldValue) != 0)
            {
                Changed?.Invoke(oldValue, _value);
            }
        }
    }
}
