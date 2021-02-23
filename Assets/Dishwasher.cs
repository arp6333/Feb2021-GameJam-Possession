using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishwasher : OpenableObject, IOpen
{


    public override void OnLockChange(bool value)
    {
        if (value)
        {
            if(GetOpen())
            {
                PlayAnimation("IdleOpenLocked");
            }
            else
            {
                PlayAnimation("IdleLocked");
            }
        }
        else
        {
            if(GetOpen())
            {
                PlayAnimation("Idle");
            }
            else
            {
                PlayAnimation("Idle");
            }
        }
    }
    public override void OnPosses(bool value)
    {
        OnLockChange(!value);
    }
    public override void OnPower()
    {
        if(!GetOpen())
        {
            Open();
        }
    }
    public override void Open()
    {
        base.Open();
        PlayAnimation("Opening");
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
