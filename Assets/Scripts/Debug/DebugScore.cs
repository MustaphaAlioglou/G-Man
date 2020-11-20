using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScore : MonoBehaviour
{
    public int score;

    public void Start()
    {
        Score.score = score;
    }
}