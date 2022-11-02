using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Powers/New Power", order = 51)]
public class SpecialPowerSO : InventoryItemSO
{
    public int GetCooldownByLvl()
    {
        return MultiplierService.GetCooldownByLvl(DataService.GetUnitLvlById(_name));
    }
}