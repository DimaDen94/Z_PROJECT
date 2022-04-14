using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie :  Unit
{

    public State CurrentState => _currentState;

    private State _currentState;
    internal void SetDefaultParams(float defaultDamage, int defaultHealth, float defaultSpeed, int _zombieLvl)
    {
        _damage = defaultDamage;
        _maxHealth = defaultHealth;
        _health = defaultHealth;
        _lvl = _zombieLvl;
        LvlUpdate?.Invoke(_lvl);
        GetComponent<NavMeshAgent>().speed = defaultSpeed;
    }

   
}
