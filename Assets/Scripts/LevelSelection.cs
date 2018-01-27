using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Text Level1Time;
    public Text Level2Time;

    private void Start()
    {
        Level1Time.text = "BEST TIME: " + (PlayerSettings.Level1Time == 1000 ? "N/A" : PlayerSettings.Level1Time.ToString("0.000"));
        Level2Time.text = "BEST TIME: " + (PlayerSettings.Level2Time == 1000 ? "N/A" : PlayerSettings.Level2Time.ToString("0.000"));
    }
}
