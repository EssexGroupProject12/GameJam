using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    private static string MusicKey = "IsMusicOn";
    private static string SoundKey = "IsSoundOn";
    private static string DifficultyKey = "IsHardDifficulty";
    private static string Level1TimeKey = "Level1Time";
    private static string Level2TimeKey = "Level2Time";

    public static float Level1Time
    {
        get
        {
            if (!PlayerPrefs.HasKey(Level1TimeKey))
            {
                PlayerPrefs.SetFloat(Level1TimeKey, 1000);
            }
            return PlayerPrefs.GetFloat(Level1TimeKey);
        }
        set
        {
            PlayerPrefs.SetFloat(Level1TimeKey, value);
        }
    }

    public static float Level2Time
    {
        get
        {
            if (!PlayerPrefs.HasKey(Level2TimeKey))
            {
                PlayerPrefs.SetFloat(Level2TimeKey, 1000);
            }
            return PlayerPrefs.GetFloat(Level2TimeKey);
        }
        set
        {
            PlayerPrefs.SetFloat(Level2TimeKey, value);
        }
    }

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
}
