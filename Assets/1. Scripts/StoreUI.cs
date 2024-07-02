using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public Image[] itemImg;
    public Text[] itemTxt;
    public Text[] priceTxt;
    public InventoryItemData[] itemData;



    void Start()
    {
        for (int i = 0; i < itemData.Length; i++)
        {
            itemImg[i].sprite = itemData[i].itemImage;
            itemTxt[i].text = $"{itemData[i].itemName}";
            priceTxt[i].text = $"({itemData[i].itemPrice:N0}$)";
        }
    }
}
