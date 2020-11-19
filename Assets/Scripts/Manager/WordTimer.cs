using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public Manager manager;

    private float wordDelay = 4f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            manager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }
}