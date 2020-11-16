using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveSystem
{
    private string _pathToSave = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public void Save(string Name, string Score)
    {
        if (Directory.Exists(_pathToSave + @"\SaveGame") && File.Exists(_pathToSave + @"\SaveGame\Score.csv"))
        {
        }
        else
        {
            Directory.CreateDirectory(_pathToSave + @"\SaveGame");
            File.Create(_pathToSave + @"\SaveGame\Score.csv");
        }
        string Save = Name + "," + Score + "\n";
        File.AppendAllText(_pathToSave + @"\SaveGame\Score.csv", Save);
    }

    public List<string[]> GetScores()
    {
        string[] lines = File.ReadAllLines(_pathToSave + @"\SaveGame\Score.csv");
        List<string[]> ScoreBoard = new List<string[]>();
        foreach (var line in lines)
        {
            string[] Score = line.Split(',');
            ScoreBoard.Add(Score);
        }
        return ScoreBoard;
    }
}