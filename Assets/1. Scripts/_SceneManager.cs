using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene("1. StartScene");
    }

    public void PrevScene()
    {
        SceneManager.LoadScene("2. SelectScene");
    }

    public void ExitScene()
    {
        Application.Quit();
    }
}
