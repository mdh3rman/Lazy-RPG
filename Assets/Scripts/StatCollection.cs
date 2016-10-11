using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatCollection  {

    private Dictionary<StatType, Stat> _statDict;

    public StatCollection()
    {
        _statDict = new Dictionary<StatType, Stat>();
        ConfigureStats();
    }

    protected virtual void ConfigureStats()
    {

    }

    public bool Contains(StatType statType)
    {
        return _statDict.ContainsKey(statType);
    }

    public Stat GetStat(StatType statType)
    {
        if (Contains(statType))
        {
            return _statDict[statType];
        }
        return null;
    }

    public T GetStat<T>(StatType type) where T: Stat
    {
        return GetStat(type) as T;
    }

    protected T CreateStat<T>(StatType statType) where T: Stat
    {
        T stat = System.Activator.CreateInstance<T>();
        _statDict.Add(statType, stat);
        return stat;
    }

    protected T CreateOrGetStat<T>(StatType statType) where T: Stat
    {
        T stat = GetStat<T>(statType);
        if (stat == null)
        {
            stat = CreateStat<T>(statType);
        }
        return stat;
    }
}
