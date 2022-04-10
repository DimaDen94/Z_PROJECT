using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
   
    [SerializeField] private int _defaultDeathCost;
    public int DeathCost => _defaultDeathCost * _lvl;
}
