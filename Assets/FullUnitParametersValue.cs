public class FullUnitParametersValue : UnitParametersValue
{
    public int BonusValue;

    public FullUnitParametersValue(int value, UnitParameter parameterType, int bonusValue)
    {
        BonusValue = bonusValue;
        Value = value;
        this.parameterType = parameterType;
    }
}