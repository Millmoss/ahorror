using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Main_Menu : MonoBehaviour
{
    public Text title;
    public Text[] options;
    public float fade_in_time;
    public float fade_start_option_time;
    public float fade_bt_option_time;
    public float fade_option_time;

    private int cur_op_pos = -1;
    private Text cur_text;
    private Color cur_color;
    Color orig_color_title;
    Color[] orig_color_options;

    // Start is called before the first frame update
    void Start()
    {
        orig_color_title = title.color;
        title.color = Color.clear;
        orig_color_options = new Color[options.Length];
        for(int i=0;i < options.Length;i++)
        {
            orig_color_options[i] = options[i].color;
            options[i].color = Color.clear;
        }
        cur_text = title;
        cur_color = orig_color_title;
        StartFade();
        Invoke("fade_options", fade_start_option_time);
    }   

    void fade_options()
    {
        cur_op_pos = 0;
        cur_text = options[cur_op_pos];
        cur_color = orig_color_options[cur_op_pos];
        StartFade();
    }

    void StartFade()
    {
        StartCoroutine("fade", cur_text);
    }

    IEnumerator fade(Text i)
    {
        for (float t = 0.01f; t < fade_in_time; t += Time.deltaTime)
        {
            i.color = Color.Lerp(Color.clear, cur_color, Mathf.Min(1, t / fade_in_time));
            yield return null;
        }
        if(cur_op_pos != -1)
        {
            cur_op_pos++;
            if(cur_op_pos < options.Length)
            {
                cur_text = options[cur_op_pos];
                cur_color = orig_color_options[cur_op_pos];
                Invoke("StartFade", fade_bt_option_time);
            }
        }
    }
}
