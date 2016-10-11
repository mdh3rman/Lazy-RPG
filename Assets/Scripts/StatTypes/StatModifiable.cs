using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StatModifiable : Stat, IStatModifiable
{
    private List<StatModifier> _statMods;
    private int _statModValue;

    public override int StatValue
    {
        get{ return base.StatValue + StatModifierValue; }
    }

    public int StatModifierValue
    {
        get
        {
            return _statModValue;
        }
    }

    public StatModifiable()
    {
        _statMods = new List<StatModifier>();
        _statModValue = 0;
    }

    public void AddModifier(StatModifier mod)
    {
        _statMods.Add(mod);
    }

    public void ClearModifiers()
    {
        _statMods.Clear();
    }

    public void UpdateModifiers()
    {
        _statModValue = 0;

        float statModBaseValueAdd = 0;
        float statModBaseValuePercent = 0;
        float statModTotalValueAdd = 0;
        float statModTotalValuePercent = 0;

        foreach(StatModifier mod in _statMods)
        {
            switch (mod.type)
            {
                case StatModifier.Types.BaseValueAdd:
                    statModBaseValueAdd += mod.Value;
                    break;
                case StatModifier.Types.BaseValuePercent:
                    statModBaseValuePercent += mod.Value;
                    break;
                case StatModifier.Types.TotalValueAdd:
                    statModTotalValueAdd += mod.Value;
                    break;
                case StatModifier.Types.TotalValuePercent:
                    statModTotalValuePercent += mod.Value;
                    break;
            }
        }

        _statModValue = (int)((StatBaseValue * statModBaseValuePercent) + statModBaseValueAdd);
        _statModValue += (int)((StatValue * statModTotalValuePercent) + statModTotalValueAdd);
    }


}
