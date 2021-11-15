using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundPref = "SoundPref";
    private int firstPlayInt;
    public Slider musicSlider, soundSlider;
    private float musicFloat, soundFloat;
    public AudioSource musicAudio;
    public AudioSource[] soundAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0) {
            musicFloat = soundFloat = 7f;
            musicSlider.value = musicFloat;
            soundSlider.value = soundFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundPref, soundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        } else {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            soundFloat = PlayerPrefs.GetFloat(SoundPref);
            soundSlider.value = soundFloat;
        }
    }

    public void SaveSoundSettings() {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundPref, soundSlider.value);
    }

    private void OnApplicationFocus(bool focusStatus) {
        if (!focusStatus)
            SaveSoundSettings();
    }

    public void UpdateSound() {
        musicAudio.volume = musicSlider.value / 10;

        for (int i = 0; i < soundAudio.Length; ++i)
            soundAudio[i].volume = soundSlider.value / 10;
    }
}
