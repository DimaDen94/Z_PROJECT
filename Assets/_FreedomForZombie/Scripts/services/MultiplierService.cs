using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierService : MonoBehaviour
{
    public static int GetNewParameterValueByLvlAndValue(int lvl, float value)
    {
        return (int)(GetParameterMultiplierByLvl(lvl) * value);
    }

    public static int GetCooldownByLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return 60;
            case 2:
                return 55;
            case 3:
                return 50;
            case 4:
                return 45;
            case 5:
                return 40;
            case 6:
                return 35;
            case 7:
                return 30;
            case 8:
                return 25;
            case 9:
                return 20;
            case 10:
                return 15;
            default:
                return 15;
        }
    }

    public static int GetValueByParameterAndLvl(UnitParametersValue parameter, int lvl)
    {
        if (lvl == -1)
            lvl = 1;
        int value;
        if (parameter.parameterType == UnitParameter.RESURRECT_CHANCE)
            value = GetResurrectChanceByLvl(lvl);
        else if (parameter.parameterType == UnitParameter.COOLDOWN)
            value =  GetCooldownByLvl(lvl);
        else if (!parameter.isStaticParameter)
            value = GetNewParameterValueByLvlAndValue(lvl, parameter.Value);
        else
            value = (int)parameter.Value;
        return value;
    }

    public static int GetExplosionDamageByLvl(int lvl, float value)
    {
        return (int)(GetParameterMultiplierByLvl(lvl) * value);
    }

    public static int GetNewLvlBonusValueByParameterAndLvl(UnitParametersValue parameter, int lvl)
    {
        if (lvl == 10 || lvl == -1)
            return 0;

        int value = 0;
        if (parameter.parameterType == UnitParameter.RESURRECT_CHANCE)
            value = GetResurrectChanceByLvl(lvl + 1) - GetResurrectChanceByLvl(lvl);
        else if(parameter.parameterType == UnitParameter.COOLDOWN)
            value = GetCooldownByLvl(lvl + 1) - GetCooldownByLvl(lvl);
        else if (!parameter.isStaticParameter)
            value = GetNewParameterValueByLvlAndValue(lvl +1, parameter.Value) - GetNewParameterValueByLvlAndValue(lvl, parameter.Value);
        return value;
    }
    private static float GetParameterMultiplierByLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return 1;
            case 2:
                return 1.25f;
            case 3:
                return 1.5f;
            case 4:
                return 2;
            case 5:
                return 3;
            case 6:
                return 5;
            case 7:
                return 7;
            case 8:
                return 9;
            case 9:
                return 12;
            case 10:
                return 15;
            default:
                return 15;
        }
    }


    public static int GetPriceForNewLvlByCurrentLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return 25;
            case 2:
                return 50;
            case 3:
                return 100;
            case 4:
                return 250;
            case 5:
                return 500;
            case 6:
                return 1000;
            case 7:
                return 2000;
            case 8:
                return 5000;
            case 9:
                return 10000;
            default:
                return 0;
        }
    }

    internal static int GetResurrectChanceByLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return 50;
            case 2:
                return 55;
            case 3:
                return 60;
            case 4:
                return 65;
            case 5:
                return 70;
            case 6:
                return 75;
            case 7:
                return 80;
            case 8:
                return 85;
            case 9:
                return 90;
            case 10:
                return 100;
            default:
                return 100;
        }
    }
}
