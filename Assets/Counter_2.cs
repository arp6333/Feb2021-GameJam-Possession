using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter_2 : OpenableObject, IOpen
{


    public override void OnLockChange(bool value)
    {
        if(value)
        {
            if (!GetOpen())
            {
                PlayAnimation("IdleLocked");

            }
            else
            {
                PlayAnimation("IdleOpenLocked");
            }
        }
        else
        {
            if (!GetOpen())
            {
                PlayAnimation("Idle");
            }
            else
            {
                PlayAnimation("IdleOpen");
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
