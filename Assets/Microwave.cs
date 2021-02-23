using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : PuzzleObject
{

    public override void OnLockChange(bool value)
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

    public override void OnPosses(bool value)
    {
        OnLockChange(!value);

    }
    public override void OnPower()
    {

    }

    // Start is called before the first frame update
    void Awake()
    {
        Init();
        animator = GetComponent<Animator>();

        PlayAnimation("IdleLocked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
