using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicsManager : MonoBehaviour
{
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip _levelsuMusic;
    [SerializeField] private AudioClip _bossFightMusic;
    public AudioSource _audioSource { get; private set; }
    private int _lastSceneIndex = 0;

    public static MusicsManager _instance { get; private set; }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _mainMenuMusic;
        _audioSource.Play();
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
            _audioSource.Stop();
            _audioSource.clip = _mainMenuMusic;
            _audioSource.Play();
        }
        else if (_lastSceneIndex == 1)
        {
            _audioSource.Stop();
            _audioSource.clip = _levelsuMusic;
            _audioSource.Play();
        }
        else if (_lastSceneIndex == 6)
        {
            _audioSource.Stop();
            _audioSource.clip = _bossFightMusic;
            _audioSource.Play();
        }
    }
}
