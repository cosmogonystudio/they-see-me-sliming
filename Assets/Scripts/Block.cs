public class Block : SlimeTrigger
{
    protected override void OnSlime(Slime slime)
    {
        slime.Invert();
    }

}
