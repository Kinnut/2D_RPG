using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Coin")
            {
                GameManager.Instance.Coin += 1000;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Potion")
            {
                GameManager.Instance.playerHP += 10;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Strength")
            {
                Character.Instance.strength += 5;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Speed")
            {
                Character.Instance.speed += 1;
                Destroy(gameObject);
            }
        }
    }
}
