using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    private Text _scoreText;
    public static int wrongCharacterCounter = 0;
    private static int _maxCharactersToFail = 20;//add +1 on your desired number

    private void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        _scoreText.text = "Score : " + score;
    }

    public static void CheckNegative()
    {
        wrongCharacterCounter += 1;
        if (wrongCharacterCounter < _maxCharactersToFail)
        {
            score += -1;
        }
        else if (wrongCharacterCounter > _maxCharactersToFail)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}