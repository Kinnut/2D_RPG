using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fadeImg;
    public Text fadeTxt;
    private float fadeAlpha = 1f;

    private AudioSource backgroundAudio;

    void Start()
    {
        fadeImg.enabled = true;

        backgroundAudio = GetComponent<AudioSource>();
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while(fadeAlpha >= 0)
        {
            fadeAlpha -= 0.003f;

            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, fadeAlpha);
            fadeTxt.color = new Color(fadeTxt.color.r, fadeTxt.color.g, fadeTxt.color.b, fadeAlpha);

            yield return new WaitForSeconds(0.02f);
        }
        backgroundAudio.Play();
    }

    void Update()
    {
        
    }
}
