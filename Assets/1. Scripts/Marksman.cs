using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marksman : MonoBehaviour
{
    public GameObject bow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            bow.SetActive(true);
            Invoke("SetAttackObjnactive", 1.45f);
        }
    }

    void SetAttackObjnactive()
    {
        bow.SetActive(false);
    }
}
