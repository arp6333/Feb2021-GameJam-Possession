using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : PuzzleObject
{

    private bool on = false;
    private bool drp = false;
    public override void OnLockChange(bool value)
    {

        if(drp)
        {
            PlayAnimation("Dropped");
            return;
        }

        if (drp || !on)
        {
            if (value)
            {
                PlayAnimation("IdleLocked");
            }
            else
            {
                PlayAnimation("Idle");

            }
        }
        //
        else if(on)
        {
            PlayAnimation("TurnOn");
        }
    }

    public override void OnPosses(bool value)
    {
        OnLockChange(!value);

    }
    public override void OnPower()
    {
        if (!on)
        {
            TurnOn();
        }
        else
        {
            if(!drp)
            {
                Drop();
            }
        }
    }

    public void TurnOn()
    {
        on = true;
        PlayAnimation("TurnOn");

    }
    public void Drop()
    {
        drp = true;
        PlayAnimation("Drop");
    }
    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
