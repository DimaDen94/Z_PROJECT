using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] protected Unit _targetEnemy;
    protected Unit _targetEnemyAltar;
    protected Unit _nativeAltar;

    protected State _currentState;

    [SerializeField] protected State _firstState;

    public State CurrentState => _currentState;

    public Unit TargetEnemy { get => _targetEnemy; set => _targetEnemy = value; }

   
    public void ResetTarget() {
        _targetEnemy = _targetEnemyAltar;
    }
    protected void Reset(State startState)
    {
        _currentState = startState;
        if (_currentState != null)
            _currentState.Enter(_targetEnemy,_targetEnemyAltar, _nativeAltar);
    }
    protected void Update()
    {
        if (_currentState == null)
            return;
        var nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);

    }
    protected void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = nextState;
        if (_currentState != null)
        {
            _currentState.Enter(_targetEnemy,_targetEnemyAltar,_nativeAltar);
        }
    }
}
