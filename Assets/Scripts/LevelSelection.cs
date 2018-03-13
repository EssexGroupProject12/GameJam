using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LevelSelection : MonoBehaviour
    // TODO show the highscores for each lvl in the text fields
{
    public Text Level1Time;
    public Text Level2Time;

    private void Start()
    {
        Level1Time.text = "BEST TIME: " + (PlayerSettings.Level1Time == 1000 ? "N/A" : PlayerSettings.Level1Time.ToString("0.000"));
        Level2Time.text = "BEST TIME: " + (PlayerSettings.Level2Time == 1000 ? "N/A" : PlayerSettings.Level2Time.ToString("0.000"));
    }

    private int ReadHighScores(string path)
    {
        string highScoresLine;

        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            while (reader.Peek() >= 0)
            {
                highScoresLine = reader.ReadLine();
                string[] lineTemp = highScoresLine.Split(',');
                
                int tempScore = Convert.ToInt32(lineTemp[2]);
                return tempScore;
            }
            reader.Close();
        }
        else {return 0;}
        return 0;
    }
}
