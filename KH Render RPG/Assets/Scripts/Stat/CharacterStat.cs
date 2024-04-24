using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public event Action OnHPZero;

    int currentHP;
    public int maxHP;

    public int power = 10;

    public bool isDebug = false;

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if(isDebug)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Hitted(10);
            }
            Debug.Log(currentHP);
        }

    }

    public void Heal(int heal)
    {
        currentHP += heal;

        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }

    public void Hitted(int damage)
    {
        Mathf.Clamp(damage, 0, int.MaxValue);
        currentHP -= damage;

        if ( currentHP <=0)
        {
            // Die();
            OnHPZero?.Invoke();
        }

    }

   
}
