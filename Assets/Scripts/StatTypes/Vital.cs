using UnityEngine;
using System;
using System.Collections;

public class Vital : Attribute {
    private int _statCurrentValue;

    public event EventHandler OnCurrentValueChange;

    public int StatCurrentValue
    {
        get {
            if (_statCurrentValue > StatValue)
                _statCurrentValue = StatValue;
            else if (_statCurrentValue < 0)
                _statCurrentValue = 0;

            return _statCurrentValue;
        }

        set {
            if (_statCurrentValue != value)
            {
                _statCurrentValue = value;
                TriggerCurrentValueChange();
            }
        }
    }

    public Vital()
    {
        _statCurrentValue = 0;
    }

    public void SetCurrentValueToMax()
    {
        StatCurrentValue = StatValue;
    }

    private void TriggerCurrentValueChange()
    {
        if(OnCurrentValueChange != null)
        {
            OnCurrentValueChange(this, null);
        }
    }
}
