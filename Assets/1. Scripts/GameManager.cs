using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string characterName;
    public string userID;

    public float playerHP = 100f;
    public float playerExp = 1f;

    public static GameManager Instance;
    #region singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }
    #endregion

    void Start()
    {
        userID = PlayerPrefs.GetString("ID");
    }

    void Update()
    {
        
    }
}
