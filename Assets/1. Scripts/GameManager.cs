using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string characterName;
    public string userID;

    public float playerHP = 100f;
    public float playerMP = 100f;
    public float playerDef = 1f;
    public float playerExp = 1f;
    public int Coin = 0;

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
        GameObject playerPref = Resources.Load<GameObject>("Characters/" + characterName);
        player = Instantiate(playerPref, spawnPos.position, spawnPos.rotation);

        return player;
    }
}
