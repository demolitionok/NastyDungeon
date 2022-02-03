using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    private Stat maxHp;
    private Stat defence;
    private Stat damage;

    public CharacterStats(Stat maxHp, Stat defence, Stat damage)
    {
        this.maxHp = maxHp;
        this.defence = defence;
        this.damage = damage;
    }
}
