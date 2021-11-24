using System;

public class KeyHolder
{
    public static event Action<int> OnKeyChange;

    private int _keys = 0;
    public int Keys {
        get => _keys;
        set {
            _keys = value;
            if (_keys < 0) _keys = 0;
            OnKeyChange?.Invoke(_keys);
        }
    }
}
