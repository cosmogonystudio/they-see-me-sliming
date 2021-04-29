using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private AbilitySwap abilitySwap;

    [SerializeField]
    private SlimeSpawner currentSpawner;

    private Slime.SlimeStatus gameOverSlimeStatus;

    private int slimesItCount;
    private int slimesUsedCount;
    private int slimesDeadCount;
    private int slimesDeeperCount;
    
    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void SlimeIt(Slime.SlimeStatus slimeStatus)
    {
        switch (slimeStatus)
        {
            case Slime.SlimeStatus.Used:
                slimesUsedCount++;
                break;
            case Slime.SlimeStatus.Dead:
                slimesDeadCount++;
                break;
            case Slime.SlimeStatus.Deeper:
                slimesDeeperCount++;
                break;
            default:
                break;
        }

        slimesItCount = slimesUsedCount + slimesDeadCount + slimesDeeperCount;

        Debug.Log("slimesUsedCount: " + slimesUsedCount);
        Debug.Log("slimesDeadCount: " + slimesDeadCount);
        Debug.Log("slimesDeeperCount: " + slimesDeeperCount);
        Debug.Log("slimesItCount: " + slimesItCount);

        if (CheckGameOver() == true)
        {
            gameOverSlimeStatus = slimeStatus;

            switch (gameOverSlimeStatus)
            {
                case Slime.SlimeStatus.Used:
                    Debug.Log("Restart");
                    break;
                case Slime.SlimeStatus.Dead:
                    Debug.Log("Game Over");
                    break;
                case Slime.SlimeStatus.Deeper:
                    Debug.Log("Passed");
                    break;
                default:
                    Debug.Log("[?]");
                    break;
            }
        }
    }

    public Slime.SlimeStatus GetGameOverSlimeStatus()
    {
        return gameOverSlimeStatus;
    }

    public AbilitySwap.AbilityType GetAbilityType()
    {
        return abilitySwap.GetCurrentAbilityType();
    }

    public void SetAbilityType(AbilitySwap.AbilityType abilityType)
    {
        abilitySwap.SetAbilityType(abilityType);
    }

    public void SetCurrentSpawner(SlimeSpawner slimeSpawner)
    {
        currentSpawner = slimeSpawner;
    }

    public void UseAbility(Slime slime)
    {
        abilitySwap.UseAbility(slime);
    }

    public void OnAbilityUse()
    {
        abilitySwap.OnAbilityUse(currentSpawner.GetAbleSlimes());
    }

    public void ResetCounters()
    {
        slimesItCount = 0;
        slimesDeadCount = 0;
        slimesDeeperCount = 0;
        slimesUsedCount = 0;
    }

    public bool CheckGameOver()
    {
        return (slimesItCount >= currentSpawner.SpawnNumber());
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetCounters();
    }

}
