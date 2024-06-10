using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("����")]
    public Image nameImg;
    public Text desTxt;
    public Image characterImg;

    [Header("ĳ����")]
    public GameObject[] characters;
    public CreateInfo[] characterInfos;
    private int charIndex = 0;

    [Header("���� ����")]
    public GameObject gameStart;
    public Text gameCountTxt;
    private bool isPlayBtnClicked = false;
    private float gameCount = 3f;

    public static string characterName;

    private void Update()
    {
        if (isPlayBtnClicked)
        {
            gameCount -= Time.deltaTime;
            if (gameCount <= 0)
            {
                SceneManager.LoadScene("3. MainScene");
            }
            gameCountTxt.text = $"�� ������ ���۵˴ϴ�. \n {gameCount:F1}";
        }
    }

    public void PlayBtn()
    {
        gameStart.SetActive(true);
        isPlayBtnClicked = true;
        GameManager.Instance.characterName = characters[charIndex].name;
    }

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
        SetPanelInfo();
    }

    private void SetPanelInfo()
    {
        nameImg.sprite = characterInfos[charIndex].name;
        desTxt.text = characterInfos[charIndex].describtion;
        characterImg.sprite = characterInfos[charIndex].characterImg;
    }

    private void Start()
    {
        SetPanelInfo();
    }
}
