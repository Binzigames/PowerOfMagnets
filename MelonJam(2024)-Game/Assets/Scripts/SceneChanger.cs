using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float _changeSceneDelay = 2f;
    public static SceneChanger _instance;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeSceneWithDelay(int sceneIndex)
    {
        StartCoroutine(ChangeSceneWithDelayIEnumerator(sceneIndex));
    }

    private IEnumerator ChangeSceneWithDelayIEnumerator(int sceneIndex)
    {
        yield return new WaitForSeconds(_changeSceneDelay);
        SceneManager.LoadScene(sceneIndex);
    }
}
