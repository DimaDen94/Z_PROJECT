using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEndTransition : Transition
{
    private Animator _animator;
    public UnityEvent SpawnEnd;
    private bool isStarted = false;
    private void OnEnable()
    {
        if(_animator == null)
            _animator = GetComponent<Unit>().Animator;
    }
    void Update()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Emerge") && !isStarted)
        {
            NeedTransit = true;
            SpawnEnd?.Invoke();
            isStarted = true;
        }
    }
}
