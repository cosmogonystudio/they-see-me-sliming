public class Boat : SlimeTrigger
{
    protected override void OnSlime(Slime slime)
    {
        slime.KeepWalking();
    }

}