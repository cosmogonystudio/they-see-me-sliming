using UnityEngine;

public class Exit : SlimeTrigger
{
    protected override void OnSlime(Slime slime)
    {
        slime.DeeperAndDeeper();
    }

}
