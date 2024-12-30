using UnityEngine;
using UnityEngine.Events;

public class MovingButton : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnterInAcceptZone;
    [SerializeField] private bool _isPlayButton = false;
    [SerializeField] private bool _isMusicButton = false;
    [SerializeField] private bool _haveAction = true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "AcceptButton")
        {
            if (_haveAction)
            {
                _onEnterInAcceptZone?.Invoke();

                if (_isPlayButton)
                {
                    SceneChanger._instance.ChangeSceneWithDelay(1);
                    Transition._instance.PlayTransition(true);
                }
            }
        }
    }
}
