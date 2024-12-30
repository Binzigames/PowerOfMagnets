using UnityEngine;

public class Lever : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float _minInteractableDistance;

    [Space]
    [SerializeField] Transform _gameObjectToMove;
    [SerializeField] private float _moveSpeed;

    private Animator animator;

    [Space]
    [SerializeField] private Transform _firstPos;
    [SerializeField] private Transform _secondPos;
    private LeverState _leverState = LeverState.Off;

    private enum LeverState
    {
        On,
        Off,
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, player.position) < _minInteractableDistance)
            {
                if (_leverState == LeverState.On)
                {
                    _leverState = LeverState.Off;
                    animator.SetBool("on", false);
                }
                else if (_leverState == LeverState.Off)
                {
                    _leverState = LeverState.On;
                    animator.SetBool("on", true);
                }
            }

        }
        if (_leverState == LeverState.On)
        {
            if (Vector2.Distance(_gameObjectToMove.position, _secondPos.position) > 0.001f)
            {
                _gameObjectToMove.position = Vector2.MoveTowards(_gameObjectToMove.position, _secondPos.position, _moveSpeed * Time.deltaTime);
            }
        }
        else if (_leverState == LeverState.Off)
        {
            if (Vector2.Distance(_gameObjectToMove.position, _firstPos.position) > 0.001f)
            {
                _gameObjectToMove.position = Vector2.MoveTowards(_gameObjectToMove.position, _firstPos.position, _moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _minInteractableDistance);
    }
}
