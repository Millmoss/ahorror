using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwap : MonoBehaviour
{
	public Camera main;
	public Camera swap;

    void Start()
    {
		swap.enabled = false;
    }

	void OnTriggerEnter(Collider c)
	{
		main.enabled = false;
		swap.enabled = true;
	}

	void OnTriggerExit(Collider c)
	{
		main.enabled = true;
		swap.enabled = false;
		print("ASDFA");
	}
}
