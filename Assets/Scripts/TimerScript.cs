using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timer_text;

    public GameObject lose_panel;

    private float easy_time = 10;

    private float timer_time;


    // Start is called before the first frame update
    void Start()
    {
        timer_text.text = easy_time.ToString();

        lose_panel.SetActive(false);
    }

    private void checkLose()
    {
        if (timer_text.text == "0")
            lose_panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Int32.Parse(timer_text.text) > 0)
        {
            timer_time = Time.time;

            timer_text.text = (easy_time - Mathf.Round(timer_time)).ToString();
        }

        else checkLose();
    }
}
