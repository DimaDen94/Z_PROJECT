using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie :  Unit
{
    [SerializeField] private float _damage;

    public State CurrentState => _currentState;

    public float Damage  => _damage; 
    private State _currentState;

    internal void SetDefaultParams(float defaultDamage, int defaultHealth, float defaultSpeed)
    {
        _damage = defaultDamage;
        _maxHealth = defaultHealth;
        _health = defaultHealth;
        GetComponent<NavMeshAgent>().speed = defaultSpeed;
    }

   
}
