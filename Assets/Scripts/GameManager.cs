using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] levels;

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
                    // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
                    break;
                case Slime.SlimeStatus.Deeper:
                    NextLevel();
                    break;
                default:
                    break;
            }
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == levelIndex);
        }

        SetCurrentSpawner();
    }

    private void SetCurrentSpawner()
    {
        slimesItCount = 0;
        slimesDeadCount = 0;
        slimesDeeperCount = 0;
        slimesUsedCount = 0;

        currentSpawner = levels[levelIndex].GetComponentInChildren<SlimeSpawner>();
    }

    private void NextLevel()
    {
        levels[levelIndex++].SetActive(false);

        if (levelIndex < levels.Length)
        {
            levels[levelIndex].SetActive(true);

            SetCurrentSpawner();
        }
    }
    
}
