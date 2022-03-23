using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyStateMachine : StateMachine
{

    private void Start()
    {
        _targetEnemyAltar = GetComponent<Enemy>().TargetEnemy;
        _targetEnemy = GetComponent<Enemy>().TargetEnemy;
        _nativeAltar = GetComponent<Enemy>().NativeAltar;
        Reset(_firstState);
    }

}
