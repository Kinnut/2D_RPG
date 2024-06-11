using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool fadein = false;
    public bool fadeout = false;

    public float TimeToFade;

    void Start()
    {
        
    }

    void Update()
    {
        if (fadein == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }
        if (fadeout == true)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadein = true;
    }

    public void FadeOut()
    {
        fadeout = true;
    }
}
