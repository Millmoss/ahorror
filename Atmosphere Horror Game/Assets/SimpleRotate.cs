using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
	public GameObject g;
	public float delay = 1f;
    public bool go = false;
	public float r = 80f;
	private float t = 0;
	private float c = 0;
    bool played = false;
    public AudioSource snd;

    void Start()
    {
        
    }
	
    void Update()
    {
		if (go && c < 180)
		{
			transform.RotateAround(g.transform.position, transform.right, Time.deltaTime * r);
			c += Time.deltaTime * r;
            if(!played)
            { 
            snd.Play();
                played = true;
            }
        }
		t += Time.deltaTime;
    }
}
