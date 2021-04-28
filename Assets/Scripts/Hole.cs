public class Hole : SlimeCollider
{

    protected override void OnSlime(Slime slime)
    {
        slime.Die();
    }

}
