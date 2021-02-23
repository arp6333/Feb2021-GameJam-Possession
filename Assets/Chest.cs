using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoolEvent :UnityEvent<bool>
{

}


public class Chest : PuzzleObject, IOpen
{

    public bool GetOpen()
    {
        return open;
    }

    public bool open = false;
    BoolEvent evnt = new BoolEvent();
    // Start is called before the first frame update
    void Awake()
    {
        Init();
        
    }
    public override void OnPower()
    {
        if(!open)
        {
            Open();
        }
        else
        {
            animator.Play("Close");
        }
        open = !open;
    }
    public override void OnPosses(bool value)
    {
        OnLockChange(!value);
    }
    public void AddListener(UnityAction<bool> call)
    {
        evnt.AddListener(call);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnLockChange(bool value)
    {
        if (!open)
        {
            if (value)
            {
                PlayAnimation("ChestRest");

            }
            else
            {
                PlayAnimation("ChestBlueRest");

            }
        }
        else
        {
            PlayAnimation("ChestOpen");
        }
    }

    public void Open()
    {
        PlayAnimation("ChestOpening");
    }
}
