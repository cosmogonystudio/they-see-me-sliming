public class Parede : AbilityButton
{

    protected override void Awake()
    {
        base.Awake();

        abilityType = AbilitySwap.AbilityType.Wall;
    }

}
