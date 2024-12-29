using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseButtonsMoving : MonoBehaviour
{
    [SerializeField] private float _moveButtonsRadius = 3f;
    [SerializeField] private float _moveForce = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        List<RaycastHit2D> collidingObjects = Physics2D.CircleCastAll(mouseWorldPos, _moveButtonsRadius, Vector2.zero).ToList();
        foreach (RaycastHit2D hit in collidingObjects)
        {
            if (hit.collider.gameObject.TryGetComponent<MovingButton>(out MovingButton movingButton))
            {
                Vector2 pushDirection = -(mouseWorldPos - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y)).normalized;
                Rigidbody2D rb = hit.collider.transform.GetComponent<Rigidbody2D>();
                rb.velocity = pushDirection * _moveForce;
            }
        }
    }
}
