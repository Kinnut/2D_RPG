using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image characterImg;
    public Text idTxt;

    public Slider hpSlider;
    public Slider mpSlider;
    public Slider expSlider;

    private GameObject player;

    void Start()
    {
        idTxt.text = GameManager.Instance.userID;
        GameObject spawnPos = GameObject.FindGameObjectWithTag("initPos");
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    void Update()
    {
        Display();
    }

    private void Display()
    {
        characterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        hpSlider.value = GameManager.Instance.playerHP;
        hpSlider.value = GameManager.Instance.playerMP;
        hpSlider.value = GameManager.Instance.playerExp;
    }
}
