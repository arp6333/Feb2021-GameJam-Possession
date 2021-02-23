using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Triggerer
{

    // Start is called before the first frame update


    public void Press()
    {
        TriggerThings();
    }

    private void Update()
    {/*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Press();
        }
        */
    }
}
