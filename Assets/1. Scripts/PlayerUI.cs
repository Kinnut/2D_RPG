using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text idTxt;
    public Text CoinTxt;
    public Text SpeedTxt;
    public Text StrengthTxt;
    public Text TimeTxt;  // 시간을 표시할 Text 컴포넌트 추가

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
        CoinTxt.text = $"{GameManager.Instance.coin}메소";
        SpeedTxt.text = $"{Character.Instance.speed}";
        StrengthTxt.text = $"{Character.Instance.strength}";

        Display();
        UpdateTime();  // 매 프레임마다 시간을 업데이트
    }

    private void Display()
    {
        hpSlider.value = GameManager.Instance.playerHP;
    }

    private void UpdateTime()
    {
        float playTime = GameManager.Instance.playTime;  // 게임 진행 시간 (초 단위)

        int minutes = Mathf.FloorToInt(playTime / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);

        if (minutes > 0)
        {
            TimeTxt.text = $"{minutes}분 {seconds}초";
        }
        else
        {
            TimeTxt.text = $"{seconds}초";
        }
    }
}
