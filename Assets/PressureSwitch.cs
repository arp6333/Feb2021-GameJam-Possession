using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : Triggerer
{
    private bool down = false;


    private void OnTriggerEnter2D(Collider2D other)
    {



        //For now we check if object is frog, gonna have todo more
        if (other.gameObject.GetComponent<Frog>() != null)
        {
            if(!down)
            {
                TriggerThings();
            }
        }
    }

}
