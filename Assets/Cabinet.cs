using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : OpenableObject, IOpen
{
    public override void OnLockChange(bool value)
    {
        if (value)
        {
            if(GetOpen())
            {
                PlayAnimation("Opened");

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
                PlayAnimation("Opened");
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

    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }
    public override void Open()
    {
        base.Open();
        PlayAnimation("Open");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
