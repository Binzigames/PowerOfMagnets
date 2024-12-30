using UnityEngine;

public class SoundOffOn : MonoBehaviour
{
    private bool _soundEnabled = true;

    public void EnableDisableSounds()
    {
        if (_soundEnabled)
        {
            _soundEnabled = false;
            MusicsManager._instance._audioSource.volume = 0f;
        }
        else
        {
            _soundEnabled = true;
            MusicsManager._instance._audioSource.volume = 0.75f;
        }
    }
}
