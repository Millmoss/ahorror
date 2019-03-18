using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
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
