using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class HighScoreHelper
    {
        public static NameScore[] ReadHighScores(string path)
        {
            NameScore[] NameScoreLines = new NameScore[10]; // high scores seperated
            string[] HighScoresLines = new string[10]; // all line from file as string
            int lineCounter = 0;

            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                while (reader.Peek() >= 0)
                {
                    HighScoresLines[lineCounter] = reader.ReadLine();
                    string[] lineTemp = HighScoresLines[lineCounter].Split(',');
                    int tempRank = Convert.ToInt32(lineTemp[0]);
                    string tempname = lineTemp[1];
                    int tempScore = Convert.ToInt32(lineTemp[2]);


                    NameScoreLines[lineCounter] = (new NameScore(tempRank, tempname, tempScore));
                    //Debug.Log(NameScoreLine[lineCounter].Rank + NameScoreLine[lineCounter].Name+ NameScoreLine[lineCounter].Score);
                    lineCounter++;
                }
                reader.Close();
                //Debug.Log(SortNewScores(NameScoreLine, 5));
            }
            else
            {
                for (int i = 0; i < NameScoreLines.Length; i++)
                {
                    NameScoreLines[i] = new NameScore(i + 1, "", 0);
                }
            }

            return NameScoreLines;
        }

        public static string WriteHighScore(NameScore[] unsortedScores, int newScore, string path)
        {
            var highScoreMarked = false;
            var newScoresToAdd = SortNewScores(unsortedScores, newScore);
            var writer = new StreamWriter(path, false);
            var newHighscores = "";

            foreach (NameScore addNewScore in newScoresToAdd)
            {
                //Debug.Log(string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score));
                string toWrite = string.Format("{0},{1},{2}", addNewScore.Rank, addNewScore.Name, addNewScore.Score);
                if(!highScoreMarked && addNewScore.Score == newScore)
                {
                    newHighscores += "\n\n" + string.Format("<color=#FBFF00FF>{0},\t{1}</color>", addNewScore.Rank, addNewScore.Score);
                    highScoreMarked = true;
                }
                else
                {
                    newHighscores += "\n\n" + string.Format("{0},\t{1}", addNewScore.Rank, addNewScore.Score);
                }
                
                writer.WriteLine(toWrite);
            }
            writer.Close();

            return newHighscores;
        }

        public static void CheckDailyScores(string path)
        {
            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists && fileInfo.LastWriteTime.Date < DateTime.Now.Date)
            {
                DeleteStoredScores(path);
            }
        }

        public static void DeleteStoredScores(string path)
        {
            var writer = new StreamWriter(path, false);
            for (int i = 1; i < 11; i++)
            {
                writer.WriteLine(i + ",,0");
            }
            writer.Close();
            //Debug.Log("done");
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

        public static NameScore[] SortNewScores(NameScore[] unsortedScores, int newScore, string newName = "")
        {
            NameScore[] tempSortNameScores = new NameScore[10];

            bool insertedNew = false;
            foreach (NameScore score in unsortedScores)
            {
                //Debug.Log(score.Rank);
                if (newScore > score.Score && !insertedNew)
                {
                    tempSortNameScores[score.Rank - 1] = new NameScore(score.Rank, newName, newScore);
                    insertedNew = true;
                }

                if (insertedNew)
                {
                    score.Rank++;
                }
                if (score.Rank != 11)
                {
                    tempSortNameScores[score.Rank - 1] = new NameScore(score.Rank, score.Name, score.Score);
                }
            }

            return tempSortNameScores;
        }

        public static string GetHighScorePath(bool daily, int level)
        {
            string dir = Path.GetDirectoryName(Application.persistentDataPath);
            var path = "";
            if (daily)
            {
                path = string.Format("{0}/HighScoresLevel{1}.txt", dir, level);
            }
            else
            {
                path = string.Format("{0}/HighScoresDailyLevel{1}.txt", dir, level);
            }

            return path;
        }
    }
}
