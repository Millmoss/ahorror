using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWall : MonoBehaviour
{
    public GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        obj.SetActive(false);
    }

    public void Deactivate()
    {
        obj.SetActive(false);
    }
}
