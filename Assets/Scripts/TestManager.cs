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

    private int levelIndex;

    void Awake()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
    }

    void Start()
    {
        levelIndex = 0;

        SetCurrentLevel();
    }

    void Update()
    {
        CheckTest();
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

    private void SetCurrentLevel()
    {
        GameManager.GetInstance().ResetCounters();

        deeperMessage.SetActive(false);
        andDeeperMessage.SetActive(false);

        levels[levelIndex].SetActive(true);

        GameManager.GetInstance().SetCurrentSpawner(levels[levelIndex].GetComponentInChildren<SlimeSpawner>());
    }

    private void NextLevel()
    {
        levels[levelIndex++].SetActive(false);

        if (levelIndex < levels.Length)
        {
            SetCurrentLevel();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void CheckTest()
    {
        if (GameManager.GetInstance().CheckGameOver() == false)
        {
            return;
        }

        switch (GameManager.GetInstance().GetGameOverSlimeStatus())
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
