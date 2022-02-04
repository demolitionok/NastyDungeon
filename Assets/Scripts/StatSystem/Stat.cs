using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Stat
{
    private float startValue;
    [SerializeField]
    private float value;

    private HashSet<StatModifier> statModifiers = new HashSet<StatModifier>();

    public Stat(float startValue) 
    {
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
