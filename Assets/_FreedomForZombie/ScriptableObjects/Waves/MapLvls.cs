using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave/MapLvls", order = 51)]
public class MapLvls : ScriptableObject
{
    [SerializeField] private LvlWaves[] _lvlWaves;

    public LvlWaves[] LvlWaves => _lvlWaves;
    public LvlWaves GetCurrentLvl() {

        return _lvlWaves[DataService.LastClickedPoint - 1];
    }
}
