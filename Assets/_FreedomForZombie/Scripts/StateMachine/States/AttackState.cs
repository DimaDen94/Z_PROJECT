using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//[RequireComponent(typeof(Animator))]
public class AttackState : State
{

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

        _navMeshAgent.velocity = Vector3.zero;
        //_navMeshAgent.enabled = true;
    }

    private void FaceTarget(Vector3 destination, float speed)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
        
    }

    void Update()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            _animator.SetTrigger("Attack");
        if(Target != null)
            FaceTarget(Target.gameObject.transform.position,Time.deltaTime * 10);
        
    }

}
