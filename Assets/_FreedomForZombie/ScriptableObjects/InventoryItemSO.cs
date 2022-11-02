using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemSO : ScriptableObject
{
    [Header("Title")]
    [SerializeField] protected Zombie _prefab;
    [SerializeField] protected Sprite _preview;
    [SerializeField] protected string _name;
    [SerializeField] protected string _descripription;
    [SerializeField] private int price;

    [Header("Params")]
    [SerializeField] protected List<UnitParametersValue> _parameters;

    public List<UnitParametersValue> Parameters => _parameters;

    public Zombie Prefab => _prefab;
    public Sprite Preview => _preview;
    public string Name => _name;
    public string Descripription => _descripription;
    public int Price => price;

    public int PowerCost => (int)FindValueByParameterType(UnitParameter.POWER_COST);
    public int DefaultAtackSpeed => (int)FindValueByParameterType(UnitParameter.ATTACK_SPEED);
    public float DefaultSpeed => FindValueByParameterType(UnitParameter.SPEED) / 2;//значение зарание увеличено для визуального отображения на экране апдейта (что бы число выглядило внушительней)


    protected float FindValueByParameterType(UnitParameter type)
    {
        foreach (UnitParametersValue value in _parameters)
        {
            if (value.parameterType == type)
                return value.Value;
        }
        return 0;
    }
}
