using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStat
{
    public float hp = 100f;
    public float mp = 100f;
    public float def = 1f;
    public float exp = 1f;
    public int lv = 1;
    public int coin = 1000000;
}

public class GameManager : MonoBehaviour
{
    public Define.Player selectPlayer;
    public string userID;
    public CharacterStat playerStat = new CharacterStat();
    [HideInInspector]
    public GameObject player; 
    
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        userID = PlayerPrefs.GetString("ID");

        DontDestroyOnLoad(Instance);
    }

    public Character Character
    {
        get { return player.GetComponent<Character>(); }
    }
    public Attack CharacterAttack
    {
        get { return Character.attackObj.GetComponent<Attack>(); }
    }


    void Start()
    {
        userID = PlayerPrefs.GetString("ID");
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPref = Resources.Load<GameObject>("Characters/" + selectPlayer.ToString());
        player = Instantiate(playerPref, spawnPos.position, spawnPos.rotation);

        return player;
    }
}
