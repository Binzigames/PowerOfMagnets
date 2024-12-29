using DG.Tweening;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _leverSwitcher;
    [SerializeField] private float _minInteractableDistance = 8f;

    [Space]
    [SerializeField] Transform _gameObjectToMove;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private bool _moveHorizontal = false;
    [SerializeField] private bool _moveVertical = false;

    [Space]
    [SerializeField] private Transform _firstPos;
    [SerializeField] private Transform _secondPos;
    private LeverState _leverState = LeverState.Off;

    enum LeverState
    {
        On,
        Off,
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, _target.position) < _minInteractableDistance)
            {
                if (_leverState == LeverState.On)
                {
                    _leverState = LeverState.Off;
                    _leverSwitcher.DOLocalRotate(new Vector3(0, 0, 30f), 0.5f);
                }
                else if (_leverState == LeverState.Off)
                {
                    _leverState = LeverState.On;
                    _leverSwitcher.DOLocalRotate(new Vector3(0, 0, -30f), 0.5f);
                }
            }    
        }

        if (_leverState == LeverState.On)
        {
            if (_firstPos.position.x > _gameObjectToMove.position.x && _moveHorizontal || _firstPos.position.y > _gameObjectToMove.position.y && _moveVertical)
            {
                _gameObjectToMove.position += new Vector3(_moveHorizontal ? _moveSpeed * Time.deltaTime : 0f, _moveVertical ? _moveSpeed * Time.deltaTime : 0f);
            }
        }
        else if (_leverState == LeverState.Off)
        {
            if (_secondPos.position.x < _gameObjectToMove.position.x && _moveHorizontal || _secondPos.position.y < _gameObjectToMove.position.y && _moveVertical)
            {
                _gameObjectToMove.position -= new Vector3(_moveHorizontal ? _moveSpeed * Time.deltaTime : 0f, _moveVertical ? _moveSpeed * Time.deltaTime : 0f);
            }
        }
    }
}
