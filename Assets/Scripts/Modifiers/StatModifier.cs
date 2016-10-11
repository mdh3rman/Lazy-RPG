using UnityEngine;
using System.Collections;

public class StatModifier {
     public enum Types
    {
        None,
        BaseValuePercent,
        BaseValueAdd,
        TotalValuePercent,
        TotalValueAdd,
    }

    private Types _type;
    private float _value;
    private StatType _statType;
    
    public Types type
    {
        get { return _type; }
        set { _type = value; }
    }
    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public StatType StatType
    {
        get { return _statType; }
        set { _statType = value; }
    }

    public StatModifier()
    {
        _type = Types.None;
        _value = 0;
        _statType = StatType.None;
    }

    public StatModifier(StatType targetStat, Types modType, float value)
    {
        _type = modType;
        _statType = targetStat;
        _value = value;
    }
}
