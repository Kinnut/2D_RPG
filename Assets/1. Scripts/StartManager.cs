using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header("회원가입")]
    public GameObject membershipUI;
    public InputField membershipID;
    public InputField membershipPW;
    public InputField membershipFind;

    [Header("로그인")]
    public GameObject loginUI;
    public InputField loginID;
    public InputField loginPW;

    [Header("찾기")]
    public GameObject findUI;
    public InputField find;

    [Header("에러 메세지")]
    public GameObject errorUI;
    public Text errorTxt;

    public void MembershipBtn()
    {
        PlayerPrefs.SetString("ID", membershipID.text);
        PlayerPrefs.SetString("PW", membershipPW.text);
        PlayerPrefs.SetString("Find", membershipFind.text);

        membershipUI.SetActive(false);
    }

    public void LoginBtn()
    {
        if (PlayerPrefs.GetString("ID") != loginID.text)
        {
            loginUI.SetActive(false);
            errorUI.SetActive(true);
            errorTxt.text = "아이디가 일치하지 않습니다.";
            Invoke("ErrorMessageExit", 3f);
            return;
        }
        if (PlayerPrefs.GetString("PW") != loginPW.text)
        {
            loginUI.SetActive(false);
            errorUI.SetActive(true);
            errorTxt.text = "비밀번호가 일치하지 않습니다.";
            Invoke("ErrorMessageExit", 1.5f);
            return;
        }

        SceneManager.LoadScene("1. SelectScene");
    }

    public void FindBtn()
    {
        findUI.SetActive(false);
        errorUI.SetActive(true);
        if (PlayerPrefs.GetString("Find") == find.text)
        {
            errorTxt.text = $"ID : {PlayerPrefs.GetString("ID")}\nPW : {PlayerPrefs.GetString("PW")}";
        }
        else
        {
            errorTxt.text = "잘못된 힌트입니다.";
        }
        Invoke("ErrorMessageExit", 1.5f);
    }

    void ErrorMessageExit()
    {
        errorUI.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetString("ID"));
        Debug.Log(PlayerPrefs.GetString("PW"));
        Debug.Log(PlayerPrefs.GetString("Find"));
    }   
}
