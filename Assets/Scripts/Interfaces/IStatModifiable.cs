using UnityEngine;
using System.Collections;

public interface IStatModifiable{
    int StatModifierValue { get; }

    void AddModifier(StatModifier mod);
    void ClearModifiers();
    void UpdateModifiers();
}
