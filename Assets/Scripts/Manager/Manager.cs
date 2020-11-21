using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<Word> words;

    public GameObject wordPrefab;
    public Transform Canvas;

    private Word _currentWord;
    private bool _bActiveWord;

    public WordDisplay SpawnWord()
    {
        return Instantiate(wordPrefab, new Vector3(Random.Range(-5f, 5f), 6f), Quaternion.identity, Canvas).GetComponent<WordDisplay>();
    }

    public void TypeLetter(char letter)
    {
        if (_bActiveWord)
        {
            if (_currentWord.CurrentCharacter() == letter)
                _currentWord.TypeLetter();
        }
        else
        {
            foreach (Word word in words)
            {
                Score.CheckNegative();

                if (word.CurrentCharacter() == letter)
                {
                    _currentWord = word;
                    _bActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (_bActiveWord && _currentWord.WordTyped())
        {
            words.Remove(_currentWord);
            _bActiveWord = false;
        }
    }

    public void AddWord()
    {
        words.Add(new Word(WordGenerator.GetRandomWord(), SpawnWord()));
    }
}