public class Exit : SlimeTrigger
{

    protected override void OnAllSmiles()
    {
        GameManager.GetInstance().NextLevel();
    }

}
