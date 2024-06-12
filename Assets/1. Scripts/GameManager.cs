using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Define.Player selectedPlayer;
    public string userID;

    public float playerHP = 100f;
    public float playerExp = 1f;
    public int coin = 0;

    public float playTime;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        userID = PlayerPrefs.GetString("ID");

        DontDestroyOnLoad(Instance);
    }

    void Start()
    {
        userID = PlayerPrefs.GetString("ID");
    }

    void Update()
    {
        // 게임이 진행 중일 때만 시간을 증가시킴
        playTime += Time.deltaTime;
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPref = Resources.Load<GameObject>("Characters/" + selectedPlayer.ToString());
        GameObject player = Instantiate(playerPref, spawnPos.position, spawnPos.rotation);

        return player;
    }
}
