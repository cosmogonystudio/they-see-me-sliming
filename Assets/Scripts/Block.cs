public class Block : SlimeCollider
{

    protected override void OnSlime(Slime slime)
    {
        slime.Invert();
    }

}
