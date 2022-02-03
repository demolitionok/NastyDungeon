using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stat
{
    private float startValue;
    private float value;

    private HashSet<StatModifier> statModifiers;

    public Stat(float startValue) 
    {
        statModifiers = new HashSet<StatModifier>();
        this.startValue = startValue;
        value = startValue;
    }

    public float GetValue() => value;  

    public void AddModifier(StatModifier statModifier) 
    {
        statModifiers.Add(statModifier);
        value = startValue * statModifiers.Aggregate(0f, (a, b) => a + b.GetValue());
    }
    public void RemoveModifier(StatModifier statModifier)
    {
        statModifiers.Remove(statModifier);
        value = startValue / statModifiers.Aggregate(0f, (a, b) => a + b.GetValue());
    }
}
