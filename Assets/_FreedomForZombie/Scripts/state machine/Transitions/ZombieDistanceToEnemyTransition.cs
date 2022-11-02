using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDistanceToEnemyTransition : Transition
{
    [SerializeField] private EntranceChecker checker;

    private void OnEnable()
    {
        checker.CollisionEnter += SetTarget;
    }
    private void OnDisable()
    {
        checker.CollisionEnter -= SetTarget;
    }

    private void SetTarget(Unit zombie) {
        GetComponent<ZombieStateMachine>().TargetEnemy = zombie;

        NeedTransit = true;
    }

}
