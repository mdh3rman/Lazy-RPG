using UnityEngine;
using System.Collections;

public class PlayerStats : StatCollection {
    protected override void ConfigureStats()
    {
        var hp = CreateOrGetStat<Vital>(StatType.Health);
        hp.StatName = "HP";
        hp.StatBaseValue= 100;
        hp.SetCurrentValueToMax();

        var mp = CreateOrGetStat<Vital>(StatType.Mana);
        mp.StatName = "MP";
        mp.StatBaseValue = 2000;
        mp.SetCurrentValueToMax();

        var str = CreateOrGetStat<StatModifiable>(StatType.Strength);
        str.StatName = "STR";
        str.StatBaseValue = 50;

        var def = CreateOrGetStat<StatModifiable>(StatType.Defense);
        def.StatName = "DEF";
        def.StatBaseValue = 50;

        var mov = CreateOrGetStat<StatModifiable>(StatType.Movement);
        mov.StatName = "MOV";
        mov.StatBaseValue = 100;
    }
}
