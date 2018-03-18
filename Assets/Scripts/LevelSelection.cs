using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Assets.Scripts.Helpers;

public class LevelSelection : MonoBehaviour
{
    public Text Level1Score;
    public Text Level2Score;

    private void Start()
    {
        var highScoreLevel1Path = HighScoreHelper.GetHighScorePath(false, 1);
        var highScoreLevel2Path = HighScoreHelper.GetHighScorePath(false, 2);

        var highScoreLevel1 = HighScoreHelper.ReadHighScores(highScoreLevel1Path)[0].Score;
        var highScoreLevel2 = HighScoreHelper.ReadHighScores(highScoreLevel2Path)[0].Score;

        Level1Score.text = "BEST SCORE: " + highScoreLevel1;
        Level2Score.text = "BEST SCORE: " + highScoreLevel2;
    }
}
