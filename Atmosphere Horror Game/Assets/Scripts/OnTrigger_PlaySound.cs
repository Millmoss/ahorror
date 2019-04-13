using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OnTrigger_PlaySound : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip[] clips;
    bool on_ground = false;
    public int interact_layer;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == interact_layer && on_ground)
        {
            on_ground = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == interact_layer && !on_ground)
        {
            int new_clip = Random.Range(0, clips.Length - 1);
            _audio.clip = clips[new_clip];
           _audio.Play(0);
            on_ground = true;
			print("ASD");
        }
    }

}
