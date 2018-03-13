using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
    //TODO create different highscore files for each lvl
{
    private string HighScorePath;
    private string HighScorePathDaily;
    public GameObject HighScoreText;
    public GameObject HighScoreDailyText;
    private StreamWriter writer;
    private string[] HighScoresLine = new string[10]; // all line from file as string
    private NameScore[] NameScoreLine = new NameScore[10]; // high scores seperated

    private void Start ()
	{
        string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        HighScorePath = dir + "/HighScores.txt";
        HighScorePathDaily = dir + "/HighScoresDaily.txt";

        ReadHighScores(HighScorePath);
        HighScoreText.GetComponent<Text>().text = "HighScores:";
        WriteHighScore(SortNewScores(NameScoreLine, PlayerSettings.LastScore), HighScorePath, HighScoreText);

        CheckDailyScores(HighScorePathDaily);
        ReadHighScores(HighScorePathDaily);
        HighScoreDailyText.GetComponent<Text>().text = "Daily HighScores:";
        WriteHighScore(SortNewScores(NameScoreLine, PlayerSettings.LastScore), HighScorePathDaily, HighScoreDailyText);
    }

    private void ReadHighScores(string path)
    {
        int lineCounter = 0;

        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            while (reader.Peek() >= 0)
            {
                HighScoresLine[lineCounter] = reader.ReadLine();
                string[] lineTemp = HighScoresLine[lineCounter].Split(',');
                int tempRank = Convert.ToInt32(lineTemp[0]);
                string tempname = lineTemp[1];
                int tempScore = Convert.ToInt32(lineTemp[2]);


                NameScoreLine[lineCounter] = (new NameScore(tempRank, tempname, tempScore));
                //Debug.Log(NameScoreLine[lineCounter].Rank + NameScoreLine[lineCounter].Name+ NameScoreLine[lineCounter].Score);
                lineCounter++;
            }
            reader.Close();
            //Debug.Log(SortNewScores(NameScoreLine, 5));
        }
        else
        {
            for (int i = 0; i < NameScoreLine.Length; i++)
            {
                NameScoreLine[i] = new NameScore(i + 1, "", 0);
            }
        }
    }

    void WriteHighScore(NameScore[] NewScoresToAdd, string path, GameObject highScoreText)
    {
        writer = new StreamWriter(path, false);

        foreach (NameScore addNewScore in NewScoresToAdd)
        {
            //Debug.Log(string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score));
            string toWrite = string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score);
            highScoreText.GetComponent<Text>().text += "\n\n" + string.Format("{0},\t{1},\t{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score);

            writer.WriteLine(toWrite);
        }
        writer.Close();
    }

    private void CheckDailyScores(string path)
    {
        var fileInfo = new FileInfo(path);
        if (fileInfo.Exists && fileInfo.LastWriteTime.Date < DateTime.Now.Date)
        {
            DeleteStoredScores(path);
        }
    }

    void DeleteStoredScores(string path)
    {
        writer = new StreamWriter(path,false);
        for (int i = 1; i < 11; i++)
        {
            writer.WriteLine(i + ",,0");
        }
        writer.Close();
        Debug.Log("done");
    }

    public class NameScore
    {
        public string Name;
        public int Score;
        public int Rank;

        public NameScore(int _Rank, string _Name, int _Score)
        {
            Name = _Name;
            Score = _Score;
            Rank = _Rank;
        }
    }

    public NameScore[] SortNewScores(NameScore[] unsortedScores, int newScore, string newName = "")
    {
        NameScore[] tempSortNameScores = new NameScore[10];
        
        bool insertedNew = false;
        foreach (NameScore score in unsortedScores)
        {
            //Debug.Log(score.Rank);
            if (newScore > score.Score && !insertedNew)
            {
                tempSortNameScores[score.Rank-1] = new NameScore(score.Rank,newName,newScore);
                insertedNew = true;
            }
            
            if (insertedNew)
            {
                score.Rank++;
            }
            if (score.Rank!=11)
            {
                tempSortNameScores[score.Rank-1] = new NameScore(score.Rank, score.Name, score.Score);
            }
        }
        
        return tempSortNameScores;
    }
}
