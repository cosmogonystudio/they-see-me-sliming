public class Exit : SlimeCollider
{

    protected override void OnSlime(Slime slime)
    {
        slime.DeeperAndDeeper();
    }

}
