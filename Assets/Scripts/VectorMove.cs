using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorMove : MonoBehaviour
{
    public GameObject Cube;

    public Button button_up;

    public Button button_down;

    private int pos = 0;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onClickUp()
    {
        count++;

        if (count < 10)
        {
            button_up.interactable = true;
        }

        else
            button_up.interactable = false;

        if(count == 1)
            button_down.interactable=true;

        pos = 1;
        Cube.transform.Translate(0, pos, 0);
        Debug.Log(count);
    }

    public void onClickDown()
    {
        count--;

        if (count > 0)
        {
            button_down.interactable = true;
        }

        else
            button_down.interactable = false;

        if (count == 9)
            button_up.interactable = true;

        pos = -1;
        Cube.transform.Translate(0, pos, 0);
        Debug.Log(count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
