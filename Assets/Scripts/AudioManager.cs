using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource musicAudioSource;

    [SerializeField]
    private AudioSource effectAudioSource;

    [SerializeField]
    private AudioClip hornAudioClip;
    [SerializeField]
    private AudioClip cannonAudioClip;
    [SerializeField]
    private AudioClip dieAudioClip;
    [SerializeField]
    private AudioClip slideAudioClip;
    [SerializeField]
    private AudioClip scaredAudioClip;
    [SerializeField]
    private AudioClip craftAudioClip;
    [SerializeField]
    private AudioClip loseAudioClip;
    [SerializeField]
    private AudioClip winAudioClip;

    private static AudioManager instance = null;

    public static AudioManager GetInstance()
    {
        return instance;
    }

    public void PlayAbility(AbilitySwap.AbilityType abilityType)
    {
        AudioClip audioClip;

        switch (abilityType)
        {
            case AbilitySwap.AbilityType.Cannon:
                audioClip = cannonAudioClip;
                break;
            case AbilitySwap.AbilityType.Horn:
                audioClip = hornAudioClip;
                break;
            case AbilitySwap.AbilityType.Wall:
                audioClip = slideAudioClip;
                break;
            default:
                audioClip = craftAudioClip;
                break;
        }

        PlayEffect(audioClip);
    }

    public void PlayStatus(Slime.SlimeStatus slimeStatus)
    {
        AudioClip audioClip;

        switch (slimeStatus)
        {
            case Slime.SlimeStatus.Paused:
                audioClip = scaredAudioClip;
                break;
            case Slime.SlimeStatus.Dead:
                audioClip = dieAudioClip;
                break;
            case Slime.SlimeStatus.Deeper:
                audioClip = winAudioClip;
                break;
            default:
                audioClip = loseAudioClip;
                break;
        }

        PlayEffect(audioClip);
    }

    public void PlayEffect(AudioClip audioClip)
    {
        effectAudioSource.pitch = Random.Range(0.95f, 1.05f);
        effectAudioSource.clip = audioClip;
        effectAudioSource.Play();
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
        musicAudioSource.Play();
    }

}
