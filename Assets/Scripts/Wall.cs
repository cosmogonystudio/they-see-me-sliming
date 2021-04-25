public class Wall : SlimeCollider
{
    protected override void OnSlime(Slime slime)
    {
        slime.Invert();
    }

}
