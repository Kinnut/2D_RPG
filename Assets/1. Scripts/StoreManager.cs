using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public InventoryItemData[] item;
    public GameObject purchaseUI;
    public Image itemImg;
    public Text itemNameTxt;
    public Text itemPriceTxt;
    public Text itemDesTxt;

    private Dictionary<string, InventoryItemData> itemDictionary;

    void Start()
    {
        itemDictionary = new Dictionary<string, InventoryItemData>();
        foreach(InventoryItemData item in item)
        {
            itemDictionary[item.itemID] = item;
        }
    }

    public void SelectItem(string itemID)
    {
        if(itemDictionary.TryGetValue(itemID, out InventoryItemData selectedItem))
        {
            purchaseUI.SetActive(true);
            itemImg.sprite = selectedItem.itemImage;
            itemNameTxt.text = selectedItem.itemName;
            itemPriceTxt.text = $"({selectedItem.itemPrice:N0} Point)";
            itemDesTxt.text = selectedItem.itemDes;
        }
        else
        {
            Debug.Log("Item ID not found" + itemID);
        }
    }
}
