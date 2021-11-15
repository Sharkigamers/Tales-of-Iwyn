using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundPref = "SoundPref";
    private int firstPlayInt;
    private float musicFloat, soundFloat;
    public AudioSource musicAudio;
    public AudioSource[] soundAudio;

    void Awake() {
        ContinueSettings();
    }

    private void Start() {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0) {
            musicFloat = soundFloat = 7f;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundPref, soundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
            ContinueSettings();
        }
    }

    private void ContinueSettings() {
        musicFloat = PlayerPrefs.GetFloat(MusicPref);
        soundFloat = PlayerPrefs.GetFloat(SoundPref);

        musicAudio.volume = musicFloat / 10;

        for (int i = 0; i < soundAudio.Length; ++i)
            soundAudio[i].volume = soundFloat / 10;
    }
}
