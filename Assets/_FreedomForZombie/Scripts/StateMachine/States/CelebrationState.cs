using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CelebrationState : State
{
    [SerializeField]private Animator _animator;

    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.stoppingDistance = 100;
        _navMeshAgent.enabled = false;
        _animator.SetTrigger("Idle");
    }
    private void Awake()
    {

    }
    private void Update()
    {
        if(_animator != null)
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Celebration"))
            {
                _animator.SetTrigger("Celebration");
            }
    }
   
}
