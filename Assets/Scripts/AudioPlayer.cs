using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.PlayAudio(Audio.SFX);
        }
    }
}
