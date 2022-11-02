using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemyTransition : Transition
{
    [SerializeField] private EntranceChecker checker;
    private void OnEnable()
    {
        if (checker.AllDetectedEnemy.Count != 0)
        {
            Debug.Log("Enemy was faund " + checker.AllDetectedEnemy.Count) ;
            GetComponent<StateMachine>().TargetEnemy = checker.AllDetectedEnemy[0];
            NeedTransit = true;
        }
    }

}
