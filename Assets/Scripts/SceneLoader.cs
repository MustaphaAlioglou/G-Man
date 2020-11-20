using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void loadGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public void loadMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}