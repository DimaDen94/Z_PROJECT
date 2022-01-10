using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private int _delay;

    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;
    private float _lastAttackTime;
    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(Target.gameObject.transform.position);
        //_navMeshAgent.
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
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            _animator.SetTrigger("Attack");
        }
    }
    private void Attack(Unit enemy) {
        
        if(enemy != null)
        {
            enemy.ApplyDamage(_damage);
        }
    }
}
