using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	//this script simply teleports the player between to assumedly uniform locations
	//more functionality will need to be added dependant upon what is needed of this script

	public GameObject port = null;
	public GameObject cam;

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			Vector3 toPos = transform.position - c.transform.position;
			c.transform.position = port.transform.position - toPos;
			Vector3 r = new Vector3(0, port.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y, 0);
			c.transform.Rotate(r);
			c.GetComponent<FirstPersonCamera>().addRotation(r.y);
		}
	}
}
