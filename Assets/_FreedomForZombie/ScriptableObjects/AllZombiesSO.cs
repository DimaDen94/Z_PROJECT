using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Zombies/New All Zombies", order = 51)]
public class AllZombiesSO : ScriptableObject
{
    [SerializeField] private List<ZombieSO> _zombies;

    public List<ZombieSO> Zombies => _zombies;

    public ZombieSO GetZombiByID(string id) {
        foreach (ZombieSO zombie in _zombies) 
            if (zombie.Name.Equals(id))
                return zombie;
        return null;
    }
}
