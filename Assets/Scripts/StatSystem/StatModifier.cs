using System;
using UnityEngine;

[Serializable]
public class StatModifier
{
    [SerializeField]
    private float value;

    public float GetValue() => value;

    public static StatModifier operator +(StatModifier a, StatModifier b) 
    {
        return new StatModifier(a.GetValue() + b.GetValue());
    } 

    public StatModifier(float value) 
    {
        this.value = value;
    }
}
