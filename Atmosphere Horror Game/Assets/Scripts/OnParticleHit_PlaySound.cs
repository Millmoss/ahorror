using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticleHit_PlaySound : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource _audio;

    private void OnParticleCollision(GameObject other)
    {
        int new_clip = Random.Range(0, clips.Length - 1);
        _audio.clip = clips[new_clip];
        _audio.Play(0);
    }

    private void OnParticleTrigger()
    {
        print("F");
    }
}
