using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeSceneWithDelay(int sceneIndex, float _changeSceneDelay = 0)
    {
        StartCoroutine(ChangeSceneWithDelayIEnumerator(sceneIndex, _changeSceneDelay));
    }

    private IEnumerator ChangeSceneWithDelayIEnumerator(int sceneIndex, float _changeSceneDelay = 0)
    {
        yield return new WaitForSeconds(_changeSceneDelay);
        SceneManager.LoadScene(sceneIndex);
    }
}
