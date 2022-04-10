using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Multiplier/New DamageMultiplier", order = 51)]
public class DamageMultiplierSO : ScriptableObject
{
    [SerializeField] private List<float> multiplierList;

    public List<float> MultiplierList => multiplierList;
}