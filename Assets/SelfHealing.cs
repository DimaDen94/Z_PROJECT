using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHealing : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private float _damagePercentage;

    public void StartSelfHealing() {
       float healingValue = (int)(_unit.Damage * (_damagePercentage/100));
        Debug.Log("damage - "+_unit.Damage.ToString() + "heal - " + healingValue.ToString() + "_damagePercentage - " + _damagePercentage.ToString());
        _unit.ApplyHealth(healingValue);
    }
}
