using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // REFERENCES
    public static AudioManager Instance;
    public AudioClip BackgroundMusic;
    public AudioSource audioSource;
    public AudioClip SFXMoneyPress, SFXMouseClick, SFXRefOpen, SFXRefClose, SFXPurchaseComplete;


    void Awake()
    {
        // Background Music Logic
        if (BackgroundMusic != null)
        {
            audioSource.clip = BackgroundMusic;
            audioSource.loop = true; // background music should loop
            audioSource.volume = 1f; // optional, adjust as needed
            audioSource.Play();
        }

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // keep it alive between scenes
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
    }

    /* METHODS: Audio SFX */
    public void PlayClickSound()
    {
        if (audioSource != null && SFXMouseClick != null)
            audioSource.PlayOneShot(SFXMouseClick, 0.3f);
    }

    public void PlayMoneyPressSound()
    {
        if (audioSource != null && SFXMoneyPress != null)
            audioSource.PlayOneShot(SFXMoneyPress, 1f);
    }

    public void PlayRefOpenSound()
    {
        if (audioSource != null && SFXRefOpen != null)
            audioSource.PlayOneShot(SFXRefOpen, 0.7f);
    }

    public void PlayRefCloseSound()
    {
        if (audioSource != null && SFXRefClose != null)
            audioSource.PlayOneShot(SFXRefClose, 0.7f);
    }

    public void PlayPurchaseCompleteSound()
    {
        if (audioSource != null && SFXPurchaseComplete != null)
            audioSource.PlayOneShot(SFXPurchaseComplete, 0.8f);
    }

}
