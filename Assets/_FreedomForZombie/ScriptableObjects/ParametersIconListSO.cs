using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ParametersIcon/New Icons", order = 51)]
public class ParametersIconListSO : ScriptableObject
{
    [SerializeField] private List<ParametersIcon> _parametersIcons;

    public Sprite FindIcon(UnitParameter parameter) {
        foreach (ParametersIcon parametersIcon in _parametersIcons) 
            if (parametersIcon.Parameter == parameter)
                return parametersIcon.Icon;
        
        return null;
    }
}
