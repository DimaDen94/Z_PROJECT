using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Zombie))]
public class ZombieStateMachine : StateMachine
{
    private void Start()
    {
        _targetEnemyAltar = GetComponent<Zombie>().TargetEnemy;
        Reset(_firstState);
    }
}
