using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    FadeInOut fade;

    [Header("회원가입")]
    public GameObject membershipUI;
    public InputField membershipID;
    public InputField membershipPW;
    public InputField membershipFind;

    [Header("로그인")]
    public InputField loginID;
    public InputField loginPW;

    [Header("찾기")]
    public GameObject findUI;
    public InputField find;

    [Header("에러 메세지")]
    public GameObject errorUI;
    public Text errorTxt;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

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
            errorUI.SetActive(true);
            errorTxt.text = "존재하지 않는 ID입니다.";
            Invoke("ErrorMessageExit", 3f);
            return;
        }
        if (PlayerPrefs.GetString("PW") != loginPW.text)
        {
            errorUI.SetActive(true);
            errorTxt.text = "비밀번호가 일치하지 않습니다.";
            Invoke("ErrorMessageExit", 3f);
            return;
        }

        StartCoroutine(ChangeScene());
    }

    public IEnumerator ChangeScene()
    {
        fade.fadein = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("2. SelectScene");
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
        Invoke("ErrorMessageExit", 3f);
    }

    void ErrorMessageExit()
    {
        errorUI.SetActive(false);
    }
}
