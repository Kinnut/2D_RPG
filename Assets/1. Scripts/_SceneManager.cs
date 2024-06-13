using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class _SceneManager : MonoBehaviour
{
    FadeInOut fade;

    private void Start()
    {
        fade = GetComponent<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        fade.fadein = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("2. SelectScene");
    }

    public void FadeInSelectScene()
    {
        StartCoroutine(ChangeScene());
    }

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
