using UnityEngine;

public class TextMover : MonoBehaviour
{
    [SerializeField] private float TextSpeed = 1;
    void Update()
    {
        transform.position -= new Vector3(0, TextSpeed * Time.deltaTime, 0);
        
    }
}
