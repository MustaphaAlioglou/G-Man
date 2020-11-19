using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class WordGenerator : MonoBehaviour
{
    private static TextAsset textFile = Resources.Load("Wordlist", typeof(TextAsset)) as TextAsset;
    private static string[] _words = Regex.Split(textFile.text, System.Environment.NewLine);

    public static string GetRandomWord()
    {
        return _words[Random.Range(0, _words.Length)];
    }
}