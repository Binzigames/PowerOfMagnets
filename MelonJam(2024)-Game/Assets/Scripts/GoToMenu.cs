using UnityEngine;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour
{
    [SerializeField] private Image _escBar;
    private float _escHoldProgress = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _escBar.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            _escHoldProgress += Time.deltaTime;
            _escBar.fillAmount = _escHoldProgress;

            if (_escHoldProgress >= 1f)
            {
                SceneChanger._instance.ChangeSceneWithDelay(0);
                Transition._instance.PlayTransition(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _escHoldProgress = 0f;
            _escBar.fillAmount = 0f;
            _escBar.gameObject.SetActive(false);
        }
    }
}
