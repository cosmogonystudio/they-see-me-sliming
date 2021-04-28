using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] levels;

    [SerializeField]
    private GameObject deeperMessage;
    [SerializeField]
    private GameObject andDeeperMessage;

    [SerializeField]
    private float deepTextSeconds;

    [SerializeField]
    private AbilitySwap abilitySwap;

    private SlimeSpawner currentSpawner;

    private int levelIndex = 0;

    private int slimesItCount;
    private int slimesUsedCount;
    private int slimesDeadCount;
    private int slimesDeeperCount;

    private static TestManager instance = null;

    public static TestManager GetInstance()
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

        if (slimesItCount >= currentSpawner.SpawnNumber())
        {
            switch (slimeStatus)
            {
                case Slime.SlimeStatus.Dead:
                    StartCoroutine(Reload());
                    break;
                case Slime.SlimeStatus.Deeper:
                    StartCoroutine(GoDeeper());
                    break;
                default:
                    StartCoroutine(AndGoDeeper());
                    break;
            }
        }
    }

    public void SetAbilityType(AbilitySwap.AbilityType abilityType)
    {
        abilitySwap.SetAbilityType(abilityType);
    }

    public void UseAbility(Slime slime)
    {
        abilitySwap.UseAbility(slime);
    }

    public void OnAbilityUse()
    {
        abilitySwap.OnAbilityUse(currentSpawner.GetAbleSlimes());
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].SetActive(false);
            }
        }
        else
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetCurrentSpawner();
    }

    IEnumerator GoDeeper()
    {
        deeperMessage.SetActive(true);

        yield return new WaitForSeconds(deepTextSeconds);

        deeperMessage.SetActive(false);

        NextLevel();
    }

    IEnumerator AndGoDeeper()
    {
        andDeeperMessage.SetActive(true);

        yield return new WaitForSeconds(deepTextSeconds);

        andDeeperMessage.SetActive(false);

        SceneManager.LoadScene(0);
    }

    IEnumerator Reload()
    {
        andDeeperMessage.SetActive(true);

        yield return new WaitForSeconds(deepTextSeconds);

        SceneManager.LoadScene(1);
    }

    private void SetCurrentSpawner()
    {
        slimesItCount = 0;
        slimesDeadCount = 0;
        slimesDeeperCount = 0;
        slimesUsedCount = 0;

        deeperMessage.SetActive(false);
        andDeeperMessage.SetActive(false);

        levels[levelIndex].SetActive(true);

        currentSpawner = levels[levelIndex].GetComponentInChildren<SlimeSpawner>();
    }

    private void NextLevel()
    {
        levels[levelIndex++].SetActive(false);

        if (levelIndex < levels.Length)
        {
            SetCurrentSpawner();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

}
