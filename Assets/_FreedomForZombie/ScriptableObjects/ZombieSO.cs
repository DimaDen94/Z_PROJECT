using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Zombies/New Zombie", order = 51)]
public class ZombieSO : ScriptableObject
{
    [Header("Title")]
    [SerializeField] private Zombie _prefab;
    [SerializeField] private Sprite _preview;
    [SerializeField] private string _name;
    [SerializeField] private string _descripription;

    [Header("Params")]
    [SerializeField] private List<UnitParametersValue> _parameters;

    public List<UnitParametersValue> Parameters => _parameters;



    public Zombie Prefab => _prefab;
    public Sprite Preview => _preview;
    public string Name => _name;
    public string Descripription => _descripription;

    public int PowerCost => (int)FindValueByParameterType(UnitParameter.POWER_COST);
    public int DefaultAtackSpeed => (int)FindValueByParameterType(UnitParameter.ATTACK_SPEED);
    public float DefaultSpeed => FindValueByParameterType(UnitParameter.SPEED) / 2;//значение зарание увеличено для визуального отображения на экране апдейта (что бы число выглядило внушительней)


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


    private float FindValueByParameterType(UnitParameter type)
    {
        foreach (UnitParametersValue value in _parameters)
        {
            if (value.parameterType == type)
                return value.Value;
        }
        return 0;
    }
}
