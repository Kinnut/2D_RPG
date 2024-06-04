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

    private GameObject player;
    public GameObject spawnPos;

    void Start()
    {
        idTxt.text = GameManager.Instance.userID;
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
    }
}
