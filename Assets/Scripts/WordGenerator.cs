using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static TextAsset textFile = Resources.Load("Wordlist", typeof(TextAsset)) as TextAsset;
    private static string[] _words = textFile.text.Split(new[] { '\n', '\r' });

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, _words.Length);
        return _words[randomIndex];
    }
}