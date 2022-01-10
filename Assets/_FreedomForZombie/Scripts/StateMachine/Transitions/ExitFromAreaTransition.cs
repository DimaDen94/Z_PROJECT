using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromAreaTransition : Transition
{
    [SerializeField] private ExitChecker checker;

    private void OnEnable()
    {
        checker.CollisionExit += SetTarget;
    }
    private void OnDisable()
    {
        checker.CollisionExit -= SetTarget;
    }

    private void SetTarget(Unit zombie) {
        GetComponent<StateMachine>().TargetEnemy = zombie;
        NeedTransit = true;
    }

}
