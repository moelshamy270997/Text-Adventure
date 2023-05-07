using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioClip[] music;
    [SerializeField] AudioClip sfx;
    AudioSource audioSource;

    static AudioScript _instance;

    void Awake()
    {
        // Singleton Pattern to have only one instance of AudioScript
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Play SFX 'Click Sound' without affecting the Played Music
    public void PlaySFX()
    {
        audioSource.PlayOneShot(sfx, 0.5f);
    }

    // Play the Music in the Main Scene
    public void PlayMainMusic()
    {
        audioSource.clip = music[0];
        audioSource.Play();
    }

    // Play the Music in the Game Scene
    public void PlayGameMusic()
    {
        audioSource.clip = music[1];
        audioSource.Play();
    }

    public float GetVolume()
    {
        return audioSource.volume;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
