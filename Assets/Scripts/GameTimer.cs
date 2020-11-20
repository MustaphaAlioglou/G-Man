using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float _totaltimepassed = 0f;
    private float _endGameInMinutes = 1f;
    private float _EndGameIn = 0f;

    private void Start()
    {
        _EndGameIn = _endGameInMinutes * 60;
    }

    private void Update()
    {
        _totaltimepassed += Time.deltaTime;
        if (_totaltimepassed > _EndGameIn)
        {
            SceneLoader ee = new SceneLoader();
            ee.loadGameOver();
        }
    }
}