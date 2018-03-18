using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings
{
    public static int LastScore = 0;
    public static int LastLevel = 0;
    private static string MusicKey = "IsMusicOn";
    private static string SoundKey = "IsSoundOn";
    private static string DifficultyKey = "IsHardDifficulty";
    private static string SoundLevelKey = "SoundLevel";

    public static bool IsHardDifficulty
    {
        get
        {
            if (!PlayerPrefs.HasKey(DifficultyKey))
            {
                PlayerPrefs.SetInt(DifficultyKey, 0);
            }
            var currentValue = PlayerPrefs.GetInt(DifficultyKey);
            return currentValue == 0 ? false : true;
        }
        set
        {
            PlayerPrefs.SetInt(DifficultyKey, value ? 1 : 0);
        }
    }

    public static bool IsMusicOn
    {
        get
        {
            if (!PlayerPrefs.HasKey(MusicKey))
            {
                PlayerPrefs.SetInt(MusicKey, 1);
            }
            var currentValue = PlayerPrefs.GetInt(MusicKey);
            return currentValue == 0 ? false : true;
        }
        set
        {
            PlayerPrefs.SetInt(MusicKey, value ? 1 : 0);
            MusicPlayer.instance.ToggleMuteMusic(!value);
        }
    }

    public static bool IsSoundOn
    {
        get
        {
            if (!PlayerPrefs.HasKey(SoundKey))
            {
                PlayerPrefs.SetInt(SoundKey, 1);
            }
            var currentValue = PlayerPrefs.GetInt(SoundKey);
            return currentValue == 0 ? false : true;
        }
        set
        {
            PlayerPrefs.SetInt(SoundKey, value ? 1 : 0);
            MusicPlayer.instance.ToggleMuteSound(!value);
        }
    }

    public static float SoundLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey(SoundLevelKey))
            {
                PlayerPrefs.SetFloat(SoundLevelKey, 0.5f);
            }
            var currentValue = PlayerPrefs.GetFloat(SoundLevelKey);
            return currentValue;
        }
        set
        {
            PlayerPrefs.SetFloat(SoundLevelKey, value);
            MusicPlayer.instance.SetVolume(value);
        }
    }
}
