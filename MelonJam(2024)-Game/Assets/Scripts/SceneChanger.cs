using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float _changeSceneDelay = 2f;

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeSceneWithDelay(int sceneIndex)
    {
        StartCoroutine(ChangeSceneWithDelayIEnumerator(sceneIndex));
    }

    IEnumerator ChangeSceneWithDelayIEnumerator(int sceneIndex)
    {
        yield return new WaitForSeconds(_changeSceneDelay);
        SceneManager.LoadScene(sceneIndex);
    }
}
