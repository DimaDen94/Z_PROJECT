using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShamanizeState : State
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Unit>().Animator;
        //_healthZone.gameObject.SetActive(true);
        if (Target != null)
            _navMeshAgent.SetDestination(Target.gameObject.transform.position);

        if (_animator != null)
            _animator.SetTrigger("Healing");

        _navMeshAgent.velocity = Vector3.zero;
    }
    private void OnDisable()
    {
        //_healthZone.gameObject.SetActive(false);
    }


    void Update()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Healing"))
            _animator.SetTrigger("Healing");
    }
}
