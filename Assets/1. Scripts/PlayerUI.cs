using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text idTxt;
    public Text coinTxt;
    public Text speedTxt;
    public Text strengthTxt;
    public Text timeTxt;
    public Text monsterTxt;

    public int monsterConut;

    public Slider hpSlider;

    private GameObject player;
    public GameObject spawnPos;

    #region Singleton
    public static PlayerUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    void Start()
    {
        idTxt.text = GameManager.Instance.userID;
        monsterTxt.text = $"{monsterConut}마리";

        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    void Update()
    {
        coinTxt.text = $"{GameManager.Instance.coin}메소";
        speedTxt.text = $"{Character.Instance.speed}";
        strengthTxt.text = $"{Character.Instance.strength}";
        monsterTxt.text = $"{monsterConut}마리";

        Display();
        UpdateTime();
    }

    private void Display()
    {
        hpSlider.value = GameManager.Instance.playerHP;
    }

    private void UpdateTime()
    {
        float playTime = GameManager.Instance.playTime;

        int minutes = Mathf.FloorToInt(playTime / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);

        if (minutes > 0)
        {
            timeTxt.text = $"{minutes}분 {seconds}초";
        }
        else
        {
            timeTxt.text = $"{seconds}초";
        }
    }
}
