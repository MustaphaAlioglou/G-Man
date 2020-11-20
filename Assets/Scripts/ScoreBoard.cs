using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using System.Linq;
using System;

public class ScoreBoard : MonoBehaviour
{
    public Text Names;
    public Text Scores;
    public GameObject inputText;
    public GameObject inputButton;

    private List<string[]> _scoreBoard;
    private bool _BestScore = false;
    private InputField _inputTextField;

    public bool starting = true;

    private void Start()
    {
        _inputTextField = inputText.GetComponent<InputField>();
        SaveSystem save = new SaveSystem();
        _scoreBoard = save.GetScores();
        StringBuilder names = new StringBuilder();
        StringBuilder scores = new StringBuilder();

        _scoreBoard = _scoreBoard.OrderByDescending(x => x[1]).ToList();
        if (_scoreBoard.Count > 10)
        {
            for (int i = 0; i < 10; i++)
            {
                names.Append(_scoreBoard[i][0] + "\n");
                scores.Append(_scoreBoard[i][1] + "\n");
            }
        }
        else if (_scoreBoard.Count < 10 && _scoreBoard.Count > 0)
        {
            for (int i = 0; i < _scoreBoard.Count; i++)
            {
                names.Append(_scoreBoard[i][0] + "\n");
                scores.Append(_scoreBoard[i][1] + "\n");
            }
        }
        Names.text = names.ToString();
        Scores.text = scores.ToString();
        //---------------------------------------------------

        if (_scoreBoard.Count > 10)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Score.score > Convert.ToInt32(_scoreBoard[i][1]))
                {
                    _BestScore = true;
                    inputButton.SetActive(true);
                    inputText.SetActive(true);
                }
            }
        }
        else if (_scoreBoard.Count < 10 && _scoreBoard.Count > 0)
        {
            for (int i = 0; i < _scoreBoard.Count; i++)
            {
                if (Score.score > Convert.ToInt32(_scoreBoard[i][1]))
                {
                    _BestScore = true;
                    inputButton.SetActive(true);
                    inputText.SetActive(true);
                }
            }
        }
        else if (_scoreBoard.Count == 0)
        {
            _BestScore = true;
            inputButton.SetActive(true);
            inputText.SetActive(true);
        }
    }

    public void ScoreSave()
    {
        if (_BestScore)
        {
            string name = _inputTextField.text;

            SaveSystem save = new SaveSystem();
            save.Save(name, Score.score.ToString());
            inputButton.SetActive(false);
            inputText.SetActive(false);
            SceneManager.LoadScene("Startup");
        }
    }
}