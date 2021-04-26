using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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

    private WaitForSeconds deepWaitForSeconds;

    private SlimeSpawner currentSpawner;

    private int levelIndex = 0;

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

        if (slimesItCount >= currentSpawner.SlimesCount())
        {
            switch (slimeStatus)
            {
                case Slime.SlimeStatus.Dead:
                    StartCoroutine(AndGoDeeper());
                    break;
                case Slime.SlimeStatus.Deeper:
                    StartCoroutine(GoDeeper());
                    break;
                default:
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
        abilitySwap.UseAbility(slime, currentSpawner.GetAbleSlimes());
    }

    public void OnAbilityUse()
    {
        abilitySwap.OnAbilityUse();
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

            deepWaitForSeconds = new WaitForSeconds(deepTextSeconds);
        }
        else if (instance != this)
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

        yield return deepWaitForSeconds;

        deeperMessage.SetActive(false);

        NextLevel();

        yield break;
    }

    IEnumerator AndGoDeeper()
    {
        andDeeperMessage.SetActive(true);

        yield return deepWaitForSeconds;

        andDeeperMessage.SetActive(false);

        SceneManager.LoadScene("StartScene");

        yield break;
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
    }
    
}
