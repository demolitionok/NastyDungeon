using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IDamageProvider, IDamageReceiver
{
    private CharacterStats playerStats;
    private float hp
    {
        get => hp;
        set
        {
            OnHpChange?.Invoke(value);
            hp = value;
        }
    }
    private event Action<float> OnHpChange;

    private void DeathCheck(float value) 
    {
        if (value <= 0) 
        {
            //OnDeath();
            Debug.Log("PLAYER DEAD!!!");
        }
    }

    private void OnEnable()
    {
        OnHpChange += DeathCheck;
    }

    public float GetDamage()
    {
        return playerStats.damage.GetValue();
    }

    public void TakeDamage(float damage)
    {
        var resultDmg = Mathf.Max(0, damage - playerStats.defence.GetValue());
        hp -= resultDmg;
    }
}
