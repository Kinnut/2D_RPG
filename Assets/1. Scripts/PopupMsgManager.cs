using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupMsgManager : MonoBehaviour
{
    public static PopupMsgManager Instance;
    public Text popupText;
    public float displayTime = 3f;

    public GameObject panel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowPopupMessage(string message)
    {
        panel.SetActive(true);
        popupText.text = message;
        StartCoroutine(HideMessageAfterDelay());
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        popupText.text = "";
        panel.SetActive(false);
    }
}
