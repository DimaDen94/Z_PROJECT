using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField]private Animator _animator;
    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator.SetTrigger("Walk");
    }
    private void Update()
    {
        if (Target != null)
        {
            _navMeshAgent.SetDestination(Target.gameObject.transform.position);
            
        }

    }

    [System.Obsolete]
    private void OnDisable()
    {
    }


}
