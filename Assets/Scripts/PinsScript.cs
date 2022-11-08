using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PinsScript : MonoBehaviour
{
    public Text first_pin;

    public Text second_pin;

    public Text third_pin;

    public Button drill_button;

    public Button hammer_button;

    public Button lockpick_button;

    public GameObject win_panel;

    public Text timer_text;

    public GameObject lose_panel;

    private float easy_time = 60;

    private float timer_time;

    private int first_pin_code;

    private int second_pin_code;

    private int third_pin_code;

    private int first_pin_solution;

    private int second_pin_solution;

    private int third_pin_solution;

    private bool keep_timing = true;

    // Start is called before the first frame update
    void Start()
    {
        win_panel.SetActive(false);

        initStartPins();

        randomPins();

        checkCombination();

        timer_text.text = easy_time.ToString();

        lose_panel.SetActive(false);
    }

    private void checkResult()
    {
        if(first_pin.color == Color.green && second_pin.color == Color.green && third_pin.color == Color.green)
        {
            win_panel.SetActive(true);

            keep_timing = false;
        }
    }

    private void checkLose()
    {
        if (Int32.Parse(timer_text.text) <= 0)
        {
            lose_panel.SetActive(true);

            keep_timing = false;
        }
            
    }

    private void checkCombination()
    {
        if(first_pin.text == first_pin_solution.ToString())
            first_pin.color = Color.green;
        else first_pin.color = Color.grey;

        if (second_pin.text == second_pin_solution.ToString())
            second_pin.color = Color.green;
        else second_pin.color = Color.grey;

        if (third_pin.text == third_pin_solution.ToString())
            third_pin.color = Color.green;
        else third_pin.color = Color.grey;
    }

    public void onClickDrill()
    {
        if(first_pin.text != "10")
        first_pin.text = (Int32.Parse(first_pin.text) + 1).ToString();

        if(second_pin.text != "0")
            second_pin.text = (Int32.Parse(second_pin.text) - 1).ToString();

        checkCombination();

        checkResult();
    }

    public void onClickHammer()
    {
        if(first_pin.text != "0")
            first_pin.text = (Int32.Parse(first_pin.text) - 1).ToString();

        if (Int32.Parse(second_pin.text) < 9)
            second_pin.text = (Int32.Parse(second_pin.text) + 2).ToString();

        else if (Int32.Parse(second_pin.text) >= 9 && Int32.Parse(second_pin.text) < 10)
            second_pin.text = (Int32.Parse(second_pin.text) + 1).ToString();

        if (third_pin.text != "0")
            third_pin.text = (Int32.Parse(third_pin.text) - 1).ToString();

        checkCombination();

        checkResult();
    }

    public void onClickLockpick()
    {
        if (first_pin.text != "0")
            first_pin.text = (Int32.Parse(first_pin.text) - 1).ToString();

        if (second_pin.text != "10")
            second_pin.text = (Int32.Parse(second_pin.text) + 1).ToString();

        if (third_pin.text != "10")
            third_pin.text = (Int32.Parse(third_pin.text) + 1).ToString();

        checkCombination();

        checkResult();
    }

    private void initStartPins()
    {
        first_pin.text = "0";

        second_pin.text = "0";

        third_pin.text = "0";
    }

    private void randomPins()
    {
        first_pin_code = UnityEngine.Random.Range(0, 10);

        second_pin_code = UnityEngine.Random.Range(0, 10);

        third_pin_code = UnityEngine.Random.Range(0, 10);
 
        first_pin_solution = first_pin_code;

        second_pin_solution = second_pin_code;

        third_pin_solution = third_pin_code;
    }

    // Update is called once per frame
    void Update()
    {
        if (keep_timing)
        {
            checkLose();

            timer_time = Time.time;

            timer_text.text = (easy_time - Mathf.Round(timer_time)).ToString(); 
        }

        else checkLose();
    }
}
