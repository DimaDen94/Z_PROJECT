using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
   
    [SerializeField] private int _defaultDeathCost;
    public int DeathCost => _defaultDeathCost * _lvl;

    internal void SetEnemyLvl(int enemyLvl)
    {
        _damage = MultiplierService.GetNewParameterValueByLvlAndValue(enemyLvl, _damage);
        _maxHealth = MultiplierService.GetNewParameterValueByLvlAndValue(enemyLvl, _maxHealth); 
        _health = _maxHealth;
        _lvl = enemyLvl;
        LvlUpdate?.Invoke(_lvl);
    }
}
