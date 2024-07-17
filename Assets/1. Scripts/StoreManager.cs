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
    private string selectItemID;

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
            itemPriceTxt.text = $"({selectedItem.itemPrice:N0}$)";
            itemDesTxt.text = selectedItem.itemDes;

            selectItemID = itemID;
        }
        else
        {
            Debug.Log("Item ID not found" + itemID);
        }
    }

    public void Purchase()
    {
        InventoryItemData selectedItem = itemDictionary[selectItemID];
        if (GameManager.Instance.playerStat.coin >= selectedItem.itemPrice)
        {
            if (BackPackManager.Instance.AddItem(selectedItem))
            {
                GameManager.Instance.playerStat.coin -= selectedItem.itemPrice;
                PopupMsgManager.Instance.ShowPopupMessage("���� ����");
            }
            else
            {
                PopupMsgManager.Instance.ShowPopupMessage("BackPack�� �� ������ �����ϴ�.");
            }
        }
        else
        {
            PopupMsgManager.Instance.ShowPopupMessage($"�ܾ��� �����մϴ�.\n�ܾ� : {GameManager.Instance.playerStat.coin}");
        }
    }
}
