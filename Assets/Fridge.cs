using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : OpenableObject
{

    public override void Open()
    {
        base.Open();
        PlayAnimation("Opening");
    }
    public void Spill()
    {
        PlayAnimation("Spilling");
    }
    private bool spilled = false;
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
        else
        {
            if(!spilled)
            {
                Spill();
                spilled = true;
            }
        }
    }

    public override void OnLockChange(bool value)
    {
        if(spilled)
        {
            PlayAnimation("Spilled");
        }
        else if (GetOpen())
        {
            PlayAnimation("Opened");
        }
        
        else if (value)
        {
            PlayAnimation("IdleLocked");

           

        }
        else
        {
            PlayAnimation("Idle");

        }
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
