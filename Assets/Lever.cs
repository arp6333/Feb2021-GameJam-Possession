using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Lock))]
public class Lever : PossessableObject
{

    Animator animator;
    public bool on = false;
    Lock lck;
    public void OnLockChange(bool value)
    {
        if(value)
        {
            if (!on)
            {
                animator.Play("IdlePossessed");
            }
            else
            {
                animator.Play("IdlePossessedOn");

            }
        }
        else
        {
            if (!on)
            {

                animator.Play("Idle");
            }
            else
            {
                animator.Play("IdleOn");

            }
        }
    }
    public void OnPosses(bool b)
    {
        OnLockChange(b);
    }
    public void OnPower()
    {
        TurnOn();
    }
    public void TurnOn()
    {
        if (!on)
        {
            animator.Play("TurnOn");
            on = true;
            lck.Set(false);
        }
    }
    public void TurnOff()
    {
        on = false;
        animator.Play("Idle");

    }
    // Start is called before the first frame update
    void Awake()
    {
        lck = GetComponent<Lock>();
        animator = GetComponent<Animator>();
        AddListenerPossess(OnPosses);
        AddListenerPower(OnPower);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
