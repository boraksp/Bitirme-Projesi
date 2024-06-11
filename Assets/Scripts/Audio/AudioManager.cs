using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure the AudioManager persists across scenes
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the name of the scene to determine which music to play
        if (scene.name == "MainMenu")
        {
            PlayMusic(mainMenuMusic);
        }
        else if (scene.name == "Gameplay")
        {
            PlayMusic(gameplayMusic);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip && audioSource.isPlaying)
        {
            return;
        }
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
}
