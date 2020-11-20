using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using System.Text;

public class SaveSystem
{
     private string _pathToSave = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public void Save(string Name, string Score)
    {
       
        if (Directory.Exists(_pathToSave + @"\SaveGame") && File.Exists(_pathToSave + @"\SaveGame\Score.csv"))
        {
            
            if (new FileInfo(_pathToSave + @"\SaveGame\Score.csv").Length == 0)
            {
                string LineToAdd =  Name + "," + Score + "\n";
                File.AppendAllText(_pathToSave + @"\SaveGame\Score.csv", LineToAdd);

            }
            else
            {
                 string LineToAdd =  Name + "," + Score + "\n";
                File.AppendAllText(_pathToSave + @"\SaveGame\Score.csv", LineToAdd);
            }
        }
        else
        {
            Directory.CreateDirectory(_pathToSave + @"\SaveGame");
            var file = File.Create(_pathToSave + @"\SaveGame\Score.csv");
            file.Close();
            string LineToAdd = Name + "," + Score + "\n";
            File.AppendAllText(_pathToSave + @"\SaveGame\Score.csv", LineToAdd);
        }
      
    }

    public List<string[]> GetScores()
    {
        if (!(Directory.Exists(_pathToSave + @"\SaveGame") && File.Exists(_pathToSave + @"\SaveGame\Score.csv")))
        {
            Directory.CreateDirectory(_pathToSave + @"\SaveGame");
            var file = File.Create(_pathToSave + @"\SaveGame\Score.csv");
            file.Close();
        }
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