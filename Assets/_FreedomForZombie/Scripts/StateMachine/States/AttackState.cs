using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private int _delay;

        
    [SerializeField] private Animator _animator;
    private float _lastAttackTime;
    private void OnEnable()
    {

        if (_animator != null)
            _animator.SetTrigger("Attack");
    }

    void Update()
    {
        if (_lastAttackTime <= 0) {
            Attack(Target);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }
    private void Attack(Unit enemy) {
        
        if(enemy != null)
        {
            enemy.ApplyDamage(_damage);
        }
    }
}
