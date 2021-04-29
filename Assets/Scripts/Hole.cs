public class Hole : SlimeTrigger
{

    protected override void OnSlime(Slime slime)
    {
        slime.Die();
    }

}
