using DG.Tweening;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private TransitionDirection _defaultTransition;
    [SerializeField] private float _transitionTime = 1f;

    [Space]
    [SerializeField] private Transform _transition;
    [SerializeField] private Transform _upEndPos;
    [SerializeField] private Transform _downEndPos;

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
        }
        else
        {
            Destroy(gameObject);
        }

        PlayTransition();
    }

    void Update()
    {
        
    }

    public void PlayTransition(TransitionDirection transitionDirection)
    {
        if (transitionDirection == TransitionDirection.Up)
        {
            _transition.DOMoveY(_upEndPos.position.y, _transitionTime);
        }
        else if (transitionDirection == TransitionDirection.Down)
        {
            _transition.DOMoveY(_downEndPos.position.y, _transitionTime);
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
            _transition.DOMoveY(_downEndPos.position.y, _transitionTime);
        }
    }
}
