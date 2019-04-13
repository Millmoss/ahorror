using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience_Switch : MonoBehaviour
{
    public AudioSource _as;
    public AudioClip[] clips;
    private int cur_pos = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("swap", 35f);
    }

    private void swap()
    {
        if (cur_pos + 1 == clips.Length)
        {
            cur_pos = 0;
        }
        else
            cur_pos++;

        _as.clip = clips[cur_pos];

    }
}
