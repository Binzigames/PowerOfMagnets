using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] private TransitionDirection _defaultTransition;
    [SerializeField] private float _transitionTime = 1f;
    [SerializeField] private float _delayTime = 1f;

    [Space]
    [SerializeField] private Transform _transition;
    [SerializeField] private Transform _upEndPos;
    [SerializeField] private Transform _downEndPos;

    private int _lastSceneIndex = 0;
    public static Transition _instance;


    public enum TransitionDirection
    {
        Up,
        Down,
    }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        PlayTransition();
    }

    void Update()
    {
        if (_lastSceneIndex != SceneManager.GetActiveScene().buildIndex)
        {
            OnSceneChanged();
        }
    }

    public void PlayTransition(bool up)
    {
        if (up)
        {
            _transition.DOMoveY(_upEndPos.position.y, _transitionTime);
        }
        else
        {
            if (_transition == null)
            {
                _transition = transform.GetChild(0).GetChild(0);
            }
            
            _transition.DOMoveY(_downEndPos.position.y, _transitionTime).SetDelay(_delayTime);
        }
    }

    public void PlayTransition()
    {
        if (_defaultTransition == TransitionDirection.Up)
        {
            _transition.DOMoveY(_upEndPos.position.y, _transitionTime);
        }
        else if (_defaultTransition == TransitionDirection.Down)
        {
            _transition.DOMoveY(_downEndPos.position.y, _transitionTime).SetDelay(_delayTime);
        }
    }

    void OnSceneChanged()
    {
        PlayTransition(false);
    }
}
