﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.text = "Score: " + Score.score;
    }
}