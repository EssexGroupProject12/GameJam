using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    private string HighScorePath;
    private StreamWriter writer;
    private string[] HighScoresLine = new string[10]; // all line from file as string
    private NameScore[] NameScoreLine = new NameScore[10]; // high scores seperated
    // Use this for initialization
    void Start ()
	{
	    HighScorePath = "Assets/HighScores.txt";
        //DeleteStoredScores();

        ReadHighScores();
        WriteHighScore(SortNewScores(NameScoreLine,0,"Max"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReadHighScores()
    {
        int lineCounter = 0;

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

    void WriteHighScore(NameScore[] NewScoresToAdd)
    {
        writer = new StreamWriter(HighScorePath, false);


        foreach (NameScore addNewScore in NewScoresToAdd)
        {
            //Debug.Log(string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score));
            writer.WriteLine(string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score));
        }
        writer.Close();

        AssetDatabase.ImportAsset(HighScorePath);
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
        AssetDatabase.ImportAsset(HighScorePath);
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
