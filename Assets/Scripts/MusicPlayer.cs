using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null;
    private AudioSource AudioSource;

    private void Awake()
    {
        if (instance != null)
        {
            // If the player returns to the start screen, we do not want a new instance of music player
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            AudioSource = GetComponent<AudioSource>();
            ToggleMuteMusic(!PlayerSettings.IsMusicOn);
            ToggleMuteSound(!PlayerSettings.IsSoundOn);
        }
    }

    public void ToggleMuteMusic(bool mute)
    {
        if (!mute)
        {
            AudioSource.mute = false;
        }
        else
        {
            AudioSource.mute = true;
        }
    }

    public void ToggleMuteSound(bool mute)
    {
        if (!mute)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
