using UnityEngine;
using UnityEngine.Events;

public class MovingButton : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnterInAcceptZone;

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
            _onEnterInAcceptZone?.Invoke();
        }
    }
}
