using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class SaveSystem
{
    private string _pathToSave = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private Encryptor encrytor = new Encryptor();

    public void Save(string Name, string Score)
    {
        if (Directory.Exists(_pathToSave + @"\SaveGame") && File.Exists(_pathToSave + @"\SaveGame\Score.csv"))
        {
            if (new FileInfo(_pathToSave + @"\SaveGame\Score.csv").Length == 0)
            {
                string LineToAdd = Name + "," + Score + "\n";
                File.WriteAllBytes(_pathToSave + @"\SaveGame\Score.csv", encrytor.Encrypt(LineToAdd));
            }
            else
            {
                string savedData = encrytor.Decrypt(File.ReadAllBytes(_pathToSave + @"\SaveGame\Score.csv"));
                string LineToAdd = savedData + "\n" + Name + "," + Score;
                File.WriteAllBytes(_pathToSave + @"\SaveGame\Score.csv", encrytor.Encrypt(LineToAdd));
            }
        }
        else
        {
            Directory.CreateDirectory(_pathToSave + @"\SaveGame");
            var file = File.Create(_pathToSave + @"\SaveGame\Score.csv");
            file.Close();
            string LineToAdd = Name + "," + Score + "\n";
            File.WriteAllBytes(_pathToSave + @"\SaveGame\Score.csv", encrytor.Encrypt(LineToAdd));
        }
    }

    public List<string[]> GetScores()
    {
        if (!(Directory.Exists(_pathToSave + @"\SaveGame") && File.Exists(_pathToSave + @"\SaveGame\Score.csv")))
        {
            Directory.CreateDirectory(_pathToSave + @"\SaveGame");
            var file = File.Create(_pathToSave + @"\SaveGame\Score.csv");
            file.Close();
            string LineToAdd = "moose,22" + "\n" + "gg,3";
            File.WriteAllBytes(_pathToSave + @"\SaveGame\Score.csv", encrytor.Encrypt(LineToAdd));
        }
        if (new FileInfo(_pathToSave + @"\SaveGame\Score.csv").Length == 0)
        {
            string LineToAdd = "moose,22" + "\n" + "gg,3";
            File.WriteAllBytes(_pathToSave + @"\SaveGame\Score.csv", encrytor.Encrypt(LineToAdd));
        }

        string[] lines = Regex.Split(encrytor.Decrypt(File.ReadAllBytes(_pathToSave + @"\SaveGame\Score.csv")), "\n");

        List<string[]> ScoreBoard = new List<string[]>();
        foreach (var line in lines)
        {
            string[] Score = line.Split(',');
            ScoreBoard.Add(Score);
        }
        return ScoreBoard;
    }
}