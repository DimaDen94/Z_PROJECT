using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : StateMachine
{
    public Unit TargetEnemyAltar { get => _targetEnemyAltar; set => _targetEnemyAltar = value; }

    private void Start()
    {
        Reset(_firstState);
    }

}
