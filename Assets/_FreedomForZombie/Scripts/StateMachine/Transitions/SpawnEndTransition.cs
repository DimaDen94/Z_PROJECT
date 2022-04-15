using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEndTransition : Transition
{
    [SerializeField] private Animator _animator;
    public UnityEvent SpawnEnd;
     void Update()
    {
        
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Emerge"))
        {
            NeedTransit = true;
            SpawnEnd?.Invoke();
        }
    }
}
