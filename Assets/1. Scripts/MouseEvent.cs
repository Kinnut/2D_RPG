using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject potionUI;
    public GameObject PowerUI;

    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "PowerNPC")
                {
                    PowerUI.SetActive(true);
                }
                if (hit.collider.gameObject.name == "PotionNPC")
                {
                    potionUI.SetActive(true);
                }
                if (hit.collider.gameObject.name == "BattleNPC")
                {
                    Debug.Log("Battle");
                }
            }

        }

    }
}
