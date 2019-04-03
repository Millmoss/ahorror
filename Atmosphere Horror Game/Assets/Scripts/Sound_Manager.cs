using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound_Manager : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioSource audiosource;
    public float echo_delay;
    public bool echo;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void play_footstep()
    {
        audiosource.clip = footsteps[Random.Range(0, footsteps.Length - 1)];
        audiosource.Play();
        if (echo)
            audiosource.PlayDelayed(echo_delay);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            play_footstep();
        }
    }
}
