using UnityEngine;
using UnityEngine.Events;

public class MovingButton : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnterInAcceptZone;
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
            }
        }
    }
}
