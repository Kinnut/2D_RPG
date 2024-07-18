using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public GameObject skillExplainUI;
    public Image skillImage;
    public Text skillText;

    public void ExplainSkillBtn(int number)
    {
        skillExplainUI.SetActive(true);
        skillImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;

        switch (GameManager.Instance.selectPlayer)
        {
            case Define.Player.Warrior:
                if (number == 0) skillText.text = "전사의 첫 번째 스킬";
                else if (number == 1) skillText.text = "전사의 두 번째 스킬";
                else if (number == 2) skillText.text = "전사의 세 번째 스킬";
                break;

            case Define.Player.Archer:
                if (number == 0) skillText.text = "궁수의 첫 번째 스킬";
                else if (number == 1) skillText.text = "궁수의 두 번째 스킬";
                else if (number == 2) skillText.text = "궁수의 세 번째 스킬";
                break;

            case Define.Player.Mage:
                if (number == 0) skillText.text = "마법사의 첫 번째 스킬";
                else if (number == 1) skillText.text = "마법사의 두 번째 스킬";
                else if (number == 2) skillText.text = "마법사의 세 번째 스킬";
                break;
        }

        Invoke("ExitExplain", 5f);
    }

    private void ExitExplain()
    {
        skillExplainUI.SetActive(false);
    }
}
