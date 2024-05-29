using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image characterImg;
    public Text idTxt;

    public Slider hpSlider;

    private GameObject player;


    void Start()
    {
        idTxt.text = GameManager.Instance.userID;
        GameObject playerPref = Resources.Load<GameObject>("Characters/" + GameManager.Instance.characterName);
        player = Instantiate(playerPref);
    }

    void Update()
    {
        Display();
    }

    private void Display()
    {
        characterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
    }
}
