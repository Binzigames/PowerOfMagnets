using UnityEngine;

public class Lever : MonoBehaviour
{
    private Transform _player;
    private GameObject _drone;
    [SerializeField] private float _minInteractableDistance;

    [Space]
    [SerializeField] Transform _gameObjectToMove;
    [SerializeField] private float _moveSpeed;

    private Animator _animator;

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
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _drone = GameObject.FindGameObjectWithTag("Drone");
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool droneInteraction = false;
            if (_drone == null)
            {
                _drone = GameObject.FindGameObjectWithTag("Drone");
                if (_drone != null)
                {
                    droneInteraction = Vector3.Distance(transform.position, _drone.transform.position) < _minInteractableDistance;
                }
            }
            else
            {
                if (_drone != null)
                {
                    droneInteraction = Vector3.Distance(transform.position, _drone.transform.position) < _minInteractableDistance;
                }
            }

            if (Vector3.Distance(transform.position, _player.position) < _minInteractableDistance || droneInteraction)
            {
                if (_leverState == LeverState.On)
                {
                    _leverState = LeverState.Off;
                    _animator.SetBool("on", false);
                }
                else if (_leverState == LeverState.Off)
                {
                    _leverState = LeverState.On;
                    _animator.SetBool("on", true);
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
