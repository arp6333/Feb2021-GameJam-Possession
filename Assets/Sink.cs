using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : PuzzleObject, IOpen
{
    public bool GetOpen()
    {
        return on;
    }

    bool on = false;

    public override void OnLockChange(bool value)
    {
        if (!on)
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
    }
    // Start is called before the first frame update
    void Awake()
    {
        Init();

    }
    public override void OnPower()
    {
        if (!on)
        {
            Overflow();
        }
        on = true;
    }
    public override void OnPosses(bool value)
    {
        OnLockChange(!value);
    }
    public void Overflow()
    {
        PlayAnimation("OverflowStart");
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
