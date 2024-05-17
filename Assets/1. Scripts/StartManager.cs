using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header("ȸ������")]
    public GameObject membershipUI;
    public InputField membershipID;
    public InputField membershipPW;
    public InputField membershipFind;

    [Header("�α���")]
    public GameObject loginUI;
    public InputField loginID;
    public InputField loginPW;

    [Header("ã��")]
    public GameObject findUI;
    public InputField find;

    [Header("���� �޼���")]
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
            errorTxt.text = "���̵� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorMessageExit", 3f);
            return;
        }
        if (PlayerPrefs.GetString("PW") != loginPW.text)
        {
            loginUI.SetActive(false);
            errorUI.SetActive(true);
            errorTxt.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorMessageExit", 3f);
            return;
        }

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
            errorTxt.text = "�߸��� ��Ʈ�Դϴ�.";
        }
        Invoke("ErrorMessageExit", 3f);
    }

    void ErrorMessageExit()
    {
        errorUI.SetActive(false);
    }
}