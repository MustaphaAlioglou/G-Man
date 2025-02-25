using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public Manager manager;

    private void Update()
    {
        foreach (char character in Input.inputString)
        {
            manager.TypeLetter(character);
            if (character == '0')
            {
                SceneLoader ee = new SceneLoader();
                ee.loadGameOver();
            }
        }
    }
}