using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Zombie))]
public class ZombieStateMachine : StateMachine
{
    private void Start()
    {
        _targetEnemyAltar = GetComponent<Zombie>().TargetEnemy;
        _targetEnemy = GetComponent<Zombie>().TargetEnemy;
        _nativeAltar = GetComponent<Zombie>().NativeAltar;
        Reset(_firstState);
    }
}
