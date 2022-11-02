using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntranceChecker : MonoBehaviour
{
    public UnityAction<Unit> CollisionEnter;
    [SerializeField]protected List<Unit> _allDetectedEnemy = new List<Unit>();

    public List<Unit> AllDetectedEnemy => _allDetectedEnemy;
    protected void RemoveUnit(Unit unit)
    {
        AllDetectedEnemy.Remove(unit);
    }
}
