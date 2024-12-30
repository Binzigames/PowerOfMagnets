using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicsManager : MonoBehaviour
{
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip _levelsuMusic;
    [SerializeField] private AudioClip _bossFightMusic;
    private AudioSource _audioSource;
    private int _lastSceneIndex = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _mainMenuMusic;
        _audioSource.Play();
        // SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void Update()
    {
        if (_lastSceneIndex != SceneManager.GetActiveScene().buildIndex)
        {
            OnSceneChanged();
        }

        _lastSceneIndex = SceneManager.GetActiveScene().buildIndex; 
    }

    void OnSceneChanged()
    {
        if (_lastSceneIndex == 0)
        {
            _audioSource.clip = _mainMenuMusic;
            _audioSource.Play();
        }
        else if (_lastSceneIndex == 1)
        {
            _audioSource.clip = _levelsuMusic;
            _audioSource.Play();
        }
        else if (_lastSceneIndex == 6)
        {
            _audioSource.clip = _bossFightMusic;
            _audioSource.Play();
        }
    }
}
