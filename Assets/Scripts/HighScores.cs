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
    public GameObject HighScoreScreenText;
    private StreamWriter writer;
    private string[] HighScoresLine = new string[10]; // all line from file as string
    private NameScore[] NameScoreLine = new NameScore[10]; // high scores seperated
    // Use this for initialization
    void Start ()
	{
        string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        HighScorePath = dir + "/HighScores.txt";
        //DeleteStoredScores();
        ReadHighScores();
        HighScoreScreenText.GetComponent<Text>().text = "HighScores:";
        WriteHighScore(SortNewScores(NameScoreLine, PlayerSettings.LastScore));
        
        //int curscore = PlayerSettings.LastScore;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReadHighScores()
    {
        int lineCounter = 0;

        if (File.Exists(HighScorePath))
        {
            StreamReader reader = new StreamReader(HighScorePath);
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

    void WriteHighScore(NameScore[] NewScoresToAdd)
    {
        writer = new StreamWriter(HighScorePath, false);


        foreach (NameScore addNewScore in NewScoresToAdd)
        {
            //Debug.Log(string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score));
            string toWrite = string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score);
            HighScoreScreenText.GetComponent<Text>().text += "\n\n" + string.Format("{0},\t{1},\t{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score);

            writer.WriteLine(toWrite);
        }
        writer.Close();
    }

    void DeleteStoredScores()
    {
        writer = new StreamWriter(HighScorePath,false);
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
