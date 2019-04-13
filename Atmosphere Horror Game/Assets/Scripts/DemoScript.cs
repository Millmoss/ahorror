using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    int cur_cam = 0;
    public GameObject[] cams;
    public SimpleRotate sm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (cur_cam == 1)
                sm.go = true;
            cams[cur_cam + 1].SetActive(true);
            cams[cur_cam].SetActive(false) ;
            cur_cam++;
        }
    }
}
