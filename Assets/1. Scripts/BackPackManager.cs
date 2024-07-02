using UnityEngine;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public GameObject backPack_UI;
    public Text coinText;

    public Image[] itemImgs;
    private InventoryItemData[] InventoryItemDatas;

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
}
