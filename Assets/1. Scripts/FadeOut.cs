using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    FadeInOut fade;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        StartCoroutine(OnScene());
    }

    public IEnumerator OnScene()
    {
        fade.fadeout = true;
        yield return new WaitForSeconds(1);
        fade.fadeout = false;
    }
}
