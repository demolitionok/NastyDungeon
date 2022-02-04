using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStats
{
    public Stat maxHp;
    public Stat defence;
    public Stat damage;

    public CharacterStats(Stat maxHp, Stat defence, Stat damage)
    {
        this.maxHp = maxHp;
        this.defence = defence;
        this.damage = damage;
    }
}
