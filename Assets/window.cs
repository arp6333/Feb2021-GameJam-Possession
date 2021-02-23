using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : PossessableObject, IOpen
{
    public bool GetOpen()
    {
        return open;
    }
    bool open = false;
    Animator animator;
    public void OnPosses(bool value)
    {
        if(value)
        {
            if(open)
            {
                animator.Play("OpenState");
            }
            else
            {
                animator.Play("ClosedState");

            }
        }
        else
        {
            if (open)
            {
                animator.Play("OpenState-NotPossessed");
            }
            else
            {
                animator.Play("ClosedState-NotPossessed");

            }
        }
    }
    public void OnPower()
    {
        if(open)
        {
            animator.Play("Close");
        }
        else
        {
            animator.Play("Open");
        }

        open = !open;
    }

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        AddListenerPossess(OnPosses);
        AddListenerPower(OnPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
