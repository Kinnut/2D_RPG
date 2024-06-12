using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text idTxt;
    public Text CoinTxt;
    public Text SpeedTxt;
    public Text StrengthTxt;
    public Text TimeTxt;  // �ð��� ǥ���� Text ������Ʈ �߰�

    public Slider hpSlider;

    private GameObject player;
    public GameObject spawnPos;

    void Start()
    {
        idTxt.text = GameManager.Instance.userID;

        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    void Update()
    {
        CoinTxt.text = $"{GameManager.Instance.coin}�޼�";
        SpeedTxt.text = $"{Character.Instance.speed}";
        StrengthTxt.text = $"{Character.Instance.strength}";

        Display();
        UpdateTime();  // �� �����Ӹ��� �ð��� ������Ʈ
    }

    private void Display()
    {
        hpSlider.value = GameManager.Instance.playerHP;
    }

    private void UpdateTime()
    {
        float playTime = GameManager.Instance.playTime;  // ���� ���� �ð� (�� ����)

        int minutes = Mathf.FloorToInt(playTime / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);

        if (minutes > 0)
        {
            TimeTxt.text = $"{minutes}�� {seconds}��";
        }
        else
        {
            TimeTxt.text = $"{seconds}��";
        }
    }
}
