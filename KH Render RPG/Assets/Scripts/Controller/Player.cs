﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public CharacterStat stat;
    public CharacterCombat combat;

    private void OnEnable()
    {
        stat.OnHPZero += Die;
    }

    private void OnDisable()
    {
        stat.OnHPZero -= Die;
    }

    void Die()
    {
        Debug.Log("플레이어 사망");
    }

}
