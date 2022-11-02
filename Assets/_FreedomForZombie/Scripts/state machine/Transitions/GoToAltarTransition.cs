using UnityEngine;

public class GoToAltarTransition : Transition
{
    [SerializeField] private EntranceChecker checker;
    private void OnEnable()
    {
        if (checker.AllDetectedEnemy.Count == 0)
        {
            GetComponent<StateMachine>().ResetTarget();
            NeedTransit = true;
        }
       
    }
}
