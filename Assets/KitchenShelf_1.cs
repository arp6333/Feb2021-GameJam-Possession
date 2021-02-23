using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenShelf_1 : PuzzleObject
{
    public bool IsFilled = false;

    public override void OnLockChange(bool value)
    {
        if (IsFilled)
        {
            PlayAnimation("Filled");
        }
        else
        {
            if (!value)
            {
                PlayAnimation("Idle");

            }
            else
            {
                PlayAnimation("IdleLocked");

            }
        }
    }
    public void Fill()
    {
        PlayAnimation("Filling");
        IsFilled = true;
    }


    public override void OnPosses(bool value)
    {
        OnLockChange(!value);

    }
    public override void OnPower()
    {
        if(!IsFilled)
        {
            Fill();
        }
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
