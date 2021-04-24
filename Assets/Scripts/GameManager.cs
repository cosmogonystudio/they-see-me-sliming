using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] levels;

    [HideInInspector]
    public int slimesCount;

    private SlimeSpawner currentSpawner;

    private int levelIndex = 0;

    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void NextLevel()
    {
        levels[levelIndex++].SetActive(false);

        if (levelIndex < levels.Length)
        {
            slimesCount = 0;

            levels[levelIndex].SetActive(true);
        }
    }

    public bool SlimeUp()
    {
        return (++slimesCount >= currentSpawner.SlimesCount());
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

        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == levelIndex);
        }

        slimesCount = 0;

        currentSpawner = levels[levelIndex].GetComponentInChildren<SlimeSpawner>();
    }

}
