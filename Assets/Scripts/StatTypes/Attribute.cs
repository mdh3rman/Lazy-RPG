using UnityEngine;
using System.Collections;
using System;

public class Attribute : StatModifiable, IStatScalable
{
    private int _statLevelValue;
    
    public int StatLevelValue {
        get { return _statLevelValue; }
    }

    public override int StatBaseValue {
        get { return base.StatBaseValue + StatLevelValue; }
    }

    public void ScaleStat(int level) {
        _statLevelValue = level;
    }
}
