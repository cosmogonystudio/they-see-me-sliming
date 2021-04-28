public class Escada : AbilityButton
{

    protected override void Awake()
    {
        base.Awake();

        abilityType = AbilitySwap.AbilityType.Bridge;
    }

}
