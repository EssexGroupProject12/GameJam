using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle MusicToggle;
    public Toggle SoundToggle;

    private void Start()
    {
        MusicToggle.isOn = PlayerSettings.IsMusicOn;
        SoundToggle.isOn = PlayerSettings.IsSoundOn;
    }

    private bool UserClicked()
    {
        var userClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        return userClicked == null ? true : false;
    } 

    public void ToggleMusic()
    {
        if (UserClicked())
        {
            return;
        }
        PlayerSettings.IsMusicOn = !PlayerSettings.IsMusicOn;      
    }

    public void ToggleSound()
    {
        if (UserClicked())
        {
            return;
        }
        PlayerSettings.IsSoundOn = !PlayerSettings.IsSoundOn;
    }

    public void ToggleDifficulty()
    {
        if (UserClicked())
        {
            return;
        }
        PlayerSettings.IsHardDifficulty = !PlayerSettings.IsHardDifficulty;
    }
}
