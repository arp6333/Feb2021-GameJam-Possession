using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet_1 : PuzzleObject, IOpen
{
    public bool open = false;

    public bool GetOpen()
    {
        return open;
    }

    public override void OnLockChange(bool value)
    {
        if(value)
        {
            if (open)
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
            if (open)
            {
                PlayAnimation("IdleOpen");
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
        if(!open)
        {
            Open();
        }
    }

    public void Open()
    {
        PlayAnimation("Opening");
        open = true;
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
