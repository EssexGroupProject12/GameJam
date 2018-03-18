using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    private string HighScorePath;
    private string HighScorePathDaily;
    public GameObject HighScoreText;
    public GameObject HighScoreDailyText;

    private void Start ()
	{
        var highScoreText = HighScoreText.GetComponent<Text>();
        var highScoreDailyText = HighScoreDailyText.GetComponent<Text>();

        HighScorePath = HighScoreHelper.GetHighScorePath(false, PlayerSettings.LastLevel);
        var nameScoreLines = HighScoreHelper.ReadHighScores(HighScorePath);
        var newHighScores = HighScoreHelper.WriteHighScore(nameScoreLines, PlayerSettings.LastScore, HighScorePath);
        highScoreText.text = newHighScores;

        HighScorePathDaily = HighScoreHelper.GetHighScorePath(true  , PlayerSettings.LastLevel);
        HighScoreHelper.CheckDailyScores(HighScorePathDaily);
        var nameScoreLinesDaily = HighScoreHelper.ReadHighScores(HighScorePathDaily);
        var newHighScoresDaily = HighScoreHelper.WriteHighScore(nameScoreLinesDaily, PlayerSettings.LastScore, HighScorePathDaily);
        highScoreDailyText.text = newHighScoresDaily;
    }
}
