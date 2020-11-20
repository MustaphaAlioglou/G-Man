using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    private Text _scoreText;
    public static int negativeCounter = 0;
    private static int _minimumCharactersToFail = 3;//add +1 on your desired number

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
        if (negativeCounter > _minimumCharactersToFail)
        {
            score += -1;
            negativeCounter = 0;
        }

        if (score < 0)
        {
            var ee = new SceneLoader();
            ee.loadGameOver();
        }
    }
}