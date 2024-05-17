using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("Ό³Έν")]
    public Text nameTxt;
    public Text desTxt;
    public Image characterImg;

    [Header("Character")]
    public GameObject[] characters;
    private int charIndex = 0;

    public void SelectCharacterBtn(string btnName)
    {
        characters[charIndex].SetActive(false);

        if (btnName == "Next")
        {
            charIndex++;
            charIndex = charIndex % characters.Length;
        }
        if (btnName == "Prev")
        {
            charIndex--;
            if (charIndex < 0)
                charIndex += characters.Length;
        }
        characters[charIndex].SetActive(true);
    }
}
