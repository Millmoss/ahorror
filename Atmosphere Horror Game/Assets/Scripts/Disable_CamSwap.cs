using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_CamSwap : MonoBehaviour
{
    public GameObject cs;
    void OnTriggerEnter(Collider c)
    {
        print("D");
        if (cs.activeSelf)
            cs.SetActive(false);
    }
}
