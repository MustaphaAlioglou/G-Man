using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int _index;

    private WordDisplay _wordDisplay;

    public Word(string _word, WordDisplay _display)
    {
        word = _word;
        _wordDisplay = _display;
        _wordDisplay.SetWord(word);
        _index = 0;
    }

    public char CurrentCharacter()
    {
        return word[_index];
    }

    public void TypeLetter()
    {
        _index++;
        _wordDisplay.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (_index >= word.Length);
        if (wordTyped)
        {
            _wordDisplay.RemoveWord();
        }
        return wordTyped;
    }
}