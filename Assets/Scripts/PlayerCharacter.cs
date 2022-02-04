using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IDamageProvider, IDamageReceiver
{
    [SerializeField]
    private CharacterStats playerStats;
    private float _hp;
    private float hp
    {
        get => _hp;
        set
        {
            OnHpChange?.Invoke(value);
            _hp = value;
        }
    }
    [SerializeField]
    private float attackSpeed;


    private event Action<float> OnHpChange;

    private void Start()
    {
        hp = playerStats.maxHp.GetValue();
    }

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

    private void OnDisable()
    {
        OnHpChange -= DeathCheck;
    }

    public float GetDamage()
    {
        return playerStats.damage.GetValue();
    }

    public void ReceiveDamage(float damage)
    {
        var resultDmg = Mathf.Max(0, damage - playerStats.defence.GetValue());
        hp -= resultDmg;
    }

    private void DoDamage(IDamageReceiver receiver) 
    {
        receiver.ReceiveDamage(GetDamage());
    }

    private void Attack() 
    {
    }
}
