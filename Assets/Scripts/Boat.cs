public class Boat : SlimeCollider
{

    protected override void OnSlime(Slime slime)
    {
        slime.KeepWalking();
    }

}