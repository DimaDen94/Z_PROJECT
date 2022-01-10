using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private Animator _animator;

 
    private void OnEnable()
    {
        
    }
    private void Update()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            _animator.SetTrigger("Idle");
        }
    }
}
