public class Gancho : AbilityButton
{

    protected override void Awake()
    {
        base.Awake();

        abilityType = AbilitySwap.AbilityType.Hook;
    }

}
