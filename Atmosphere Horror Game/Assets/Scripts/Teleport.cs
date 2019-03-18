using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	//this script simply teleports the player between to assumedly uniform locations
	//more functionality will need to be added dependant upon what is needed of this script

	public GameObject port = null;

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			Vector3 toPos = transform.position - c.transform.position;
			c.transform.position = port.transform.position - toPos;
		}
	}
}
