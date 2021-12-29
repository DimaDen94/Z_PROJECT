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


    private NavMeshAgent _agent;
    private Unit _targetEnemy;

    public Unit TargetEnemy => _targetEnemy;
    public State CurrentState => _currentState; 

    private State _currentState;

    public event UnityAction Dying;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    internal void SetTargetAltarPosition(Unit enemy)
    {
        _targetEnemy = enemy;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " die");
        Destroy(gameObject);
    }

   
}
