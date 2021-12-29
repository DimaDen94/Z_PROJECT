using System;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public Unit Target { get;protected set; }
    public Unit TargetAltar { get;protected set; }

    public State TargetState { get => _targetState; set => _targetState = value; }

    public bool NeedTransit { get;protected set; }

    public void Init(Unit target, Unit targetAltar)
    {
        Target = target;
        TargetAltar = targetAltar;
    }

    internal void Deactivate()
    {
        NeedTransit = false;
        enabled = false;
    }
}
