using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceToEnemyTransition : Transition
{
    [SerializeField] private EnemyEntranceChecker checker;

    private void OnEnable()
    {
        checker.CollisionEnter += SetTarget;
    }
    private void OnDisable()
    {
        checker.CollisionEnter -= SetTarget;
    }

    private void SetTarget(Unit zombie) {
        GetComponent<StateMachine>().TargetEnemy = zombie;

        NeedTransit = true;
    }

}
