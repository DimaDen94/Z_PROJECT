using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Zombies/New Zombie", order = 51)]
public class ZombieSO : InventoryItemSO
{
    public int GetDamageByLvl(int lvl) {
        return  MultiplierService.GetNewParameterValueByLvlAndValue(lvl, FindValueByParameterType(UnitParameter.DAMAGE));
    }
    public int GetHealthByLvl(int lvl)
    {
        return MultiplierService.GetNewParameterValueByLvlAndValue(lvl, FindValueByParameterType(UnitParameter.HEALTH));
    }
    public int GetHealingPowerByLvl(int lvl)
    {
        return MultiplierService.GetNewParameterValueByLvlAndValue(lvl, FindValueByParameterType(UnitParameter.HEALING_POWER));
    }
    public int GetDamageDebuffPowerByLvl(int lvl)
    {
        return MultiplierService.GetNewParameterValueByLvlAndValue(lvl, FindValueByParameterType(UnitParameter.DAMAGE_DEBUFF_POWER));
    }
    public int GetResurrectChanceByLvl(int lvl)
    {
        return MultiplierService.GetResurrectChanceByLvl(lvl);
    }

}
