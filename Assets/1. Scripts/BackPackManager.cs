using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public GameObject backPack_UI;
    public Text coinText;

    public Image[] itemImgs;
    private InventoryItemData[] InventoryItemDatas;

    private int defItemUsingCount = 0;
    private int speedItemUsingCount = 0;
    private int powerItemUsingCount = 0;

    public static BackPackManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InventoryItemDatas = new InventoryItemData[itemImgs.Length];
    }

    private void Update()
    {
        BackPackUIOn();
        coinText.text = $"{GameManager.Instance.Coin:N0}$";
    }

    private void BackPackUIOn()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            backPack_UI.SetActive(!backPack_UI.activeSelf);
        }
    }
    public bool AddItem(InventoryItemData item)
    {
        for (int i = 0; i < itemImgs.Length; i++)
        {
            if (itemImgs[i].sprite == null)
            {
                itemImgs[i].sprite = item.itemImage;
                InventoryItemDatas[i] = item;
                return true;
            }
        }
        return false;
    }

    public void ItemUse()
    {
        int siblingIndex = EventSystem.current.currentSelectedGameObject.transform.parent.GetSiblingIndex();
        InventoryItemData inventoryItem = InventoryItemDatas[siblingIndex];
        if (inventoryItem == null) return;

        if (inventoryItem.itemID == "HP")
        {
            GameManager.Instance.playerHP += 10f;
            GameManager.Instance.playerHP = Mathf.Min(GameManager.Instance.playerHP, 100f);
            PopupMsgManager.Instance.ShowPopupMessage("ü���� 10 ȸ�� �Ǿ����ϴ�.");
        }
        else if (inventoryItem.itemID == "MP")
        {
            GameManager.Instance.playerMP += 10f;
            GameManager.Instance.playerMP = Mathf.Min(GameManager.Instance.playerMP, 100f);
            PopupMsgManager.Instance.ShowPopupMessage("������ 10 ȸ�� �Ǿ����ϴ�.");
        }
        else if (inventoryItem.itemID == "HP_Power")
        {
            GameManager.Instance.playerHP = 100f;
            PopupMsgManager.Instance.ShowPopupMessage("ü�� ��ü�� ȸ�� �Ǿ����ϴ�.");
        }
        else if (inventoryItem.itemID == "MP_Power")
        {
            GameManager.Instance.playerMP = 100f;
            PopupMsgManager.Instance.ShowPopupMessage("���� ��ü�� ȸ�� �Ǿ����ϴ�.");
        }
        else if (inventoryItem.itemID == "Def")
        {
            StartCoroutine(DefItem());
        }
        else if (inventoryItem.itemID == "Speed")
        {
            StartCoroutine(SpeedItem());
        }
        else if (inventoryItem.itemID == "Power")
        {
            StartCoroutine(PowerItem());
        }
        else if (inventoryItem.itemID == "Super")
        {
            // ������ ���ö� ����
        }
        else
        {
            Debug.LogError($"�������� �ʴ� itemID[{inventoryItem.itemID}]");
            return;
        }

        InventoryItemDatas[siblingIndex] = null;
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
    }
    IEnumerator DefItem()
    {
        defItemUsingCount++;
        GameManager.Instance.playerDef *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("1. PlayerDef : " + GameManager.Instance.playerDef);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.playerDef /= 2;
        if (defItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("2. PlayerDef : " + GameManager.Instance.playerDef);
    }
    IEnumerator SpeedItem()
    {
        speedItemUsingCount++;
        GameManager.Instance.Character.speed *= 2f;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("1. Speed : " + GameManager.Instance.Character.speed);
        yield return new WaitForSeconds(10f);

        speedItemUsingCount--;
        GameManager.Instance.Character.speed /= 2f;
        if (speedItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("2. Speed : " + GameManager.Instance.Character.speed);
    }
    IEnumerator PowerItem()
    {
        powerItemUsingCount++;
        GameManager.Instance.CharacterAttack.attackDamage *= 2f;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("1. Character Power.AttackDamage : " + GameManager.Instance.CharacterAttack.attackDamage);
        yield return new WaitForSeconds(10f);

        powerItemUsingCount--;
        GameManager.Instance.CharacterAttack.attackDamage /= 2f;
        if (powerItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("2. Character Power.AttackDamage : " + GameManager.Instance.CharacterAttack.attackDamage);
    }


}
