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
                if (number == 0) skillText.text = "������ ù ��° ��ų";
                else if (number == 1) skillText.text = "������ �� ��° ��ų";
                else if (number == 2) skillText.text = "������ �� ��° ��ų";
                break;

            case Define.Player.Archer:
                if (number == 0) skillText.text = "�ü��� ù ��° ��ų";
                else if (number == 1) skillText.text = "�ü��� �� ��° ��ų";
                else if (number == 2) skillText.text = "�ü��� �� ��° ��ų";
                break;

            case Define.Player.Mage:
                if (number == 0) skillText.text = "�������� ù ��° ��ų";
                else if (number == 1) skillText.text = "�������� �� ��° ��ų";
                else if (number == 2) skillText.text = "�������� �� ��° ��ų";
                break;
        }

        Invoke("ExitExplain", 5f);
    }

    private void ExitExplain()
    {
        skillExplainUI.SetActive(false);
    }
}
