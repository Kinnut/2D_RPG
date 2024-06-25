using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject dialogueUI;

    private GameObject playerObj;
    private float distance;

    public GameObject[] dialogueTextObj;
    private int index = 0;


    void Update()
    {
        if (playerObj == null) playerObj = GameManager.Instance.player;
        if (playerObj == null) return;

        distance = Vector2.Distance(transform.position, playerObj.transform.position);
        Debug.Log($"distance : {distance}");

        if (distance <= 3 ) dialogueUI.SetActive(true);
        else dialogueUI.SetActive(false);
    }

    public void NextBtn(string name)
    {
        dialogueTextObj[index].SetActive(false);
        if (name == "Next")
        {
            if (index < dialogueTextObj.Length - 1) index++;
        }
        else if (name == "Prev")
        {
            if(index > 0) index--;
        }
        dialogueTextObj[index].SetActive(true);
    }

    public void TownBtn()
    {
        SceneManager.LoadScene("4. TownScene");
    }
}
