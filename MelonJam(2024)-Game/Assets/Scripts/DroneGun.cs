using Cinemachine;
using UnityEngine;

public class DroneGun : MonoBehaviour
{
    [SerializeField] private GameObject _dronePrefab;
    [SerializeField] private Transform _dronePos;
    private CinemachineVirtualCamera _virtualCamera;
    private PlayerMoving _playerMoving;
    private PlayerMoving _drone;
    private bool _spawned = false;
    private bool _droneControls = false;

    void Start()
    {
        _virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();  
        _playerMoving = FindAnyObjectByType<PlayerMoving>();  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !_spawned)
        {
            _spawned = true;
            _drone = Instantiate(_dronePrefab, _dronePos.position, Quaternion.identity).GetComponent<PlayerMoving>();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_droneControls)
            {
                _droneControls = false;
                _drone.SetCanMove(false); 
                _playerMoving.SetCanMove(true);
                _virtualCamera.Follow = _playerMoving.transform;
            }
            else
            {
                _droneControls = true;
                _drone.SetCanMove(true); 
                _playerMoving.SetCanMove(false);
                _virtualCamera.Follow = _drone.transform;
            }
        }
    }
}
