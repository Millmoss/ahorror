using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwap : MonoBehaviour
{
	public Camera main;
	public Camera secondary = null;
	public Camera swap;

    void Start()
    {
		swap.enabled = false;
    }

	void OnTriggerEnter(Collider c)
	{
        if (c.gameObject.layer == 9)
            return;
		main.enabled = false;
		if (secondary != null)
			secondary.enabled = false;
		swap.enabled = true;
	}

	void OnTriggerExit(Collider c)
    {
        if (c.gameObject.layer == 9)
            return;
        main.enabled = true;
		swap.enabled = false;
		print("ASDFA");
	}
}
