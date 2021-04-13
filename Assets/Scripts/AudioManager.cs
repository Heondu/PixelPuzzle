using UnityEngine;
using UnityEngine.UI;

public enum Audio { BGM, SFX }

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioSource[] audioSources;
    [SerializeField]
    private Slider sliderBGM;
    [SerializeField]
    private Slider sliderSFX;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        audioSources[(int)Audio.BGM].volume = sliderBGM.value;
        audioSources[(int)Audio.SFX].volume = sliderSFX.value;
    }

    public void PlayAudio(Audio audio)
    {
        audioSources[(int)audio].Play();
    }
}
