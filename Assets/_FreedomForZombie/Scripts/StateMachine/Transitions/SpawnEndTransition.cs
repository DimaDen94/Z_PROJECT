using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEndTransition : Transition
{
    [SerializeField] private Animator _animator;
     void Update()
    {
        
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Emerge"))
        {
            NeedTransit = true;
        }
    }
}
