using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Zombie))]
public class ZombieStateMachine : StateMachine
{
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _targetEnemyAltar = GetComponent<Zombie>().TargetEnemyAltar;
        _targetEnemy = GetComponent<Zombie>().TargetEnemyAltar;
        _nativeAltar = GetComponent<Zombie>().NativeAltar;
        GetComponent<DeathState>().enabled = false;
        Reset(_firstState);
        ResetTarget();
    }

    internal void SerTargetAltar(Unit targetEnemyAltar)
    {
        //throw new NotImplementedException();
    }
}
