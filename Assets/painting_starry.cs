using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painting_starry : PossessableObject
{


    bool fall = false;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        AddListenerPower(OnPower);
        AddListenerPossess(OnPossess);

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPossess(bool value)
    {
        if (!fall)
        {
            if (value)
            {
                animator.Play("IdlePossessed");
            }
            else
            {
                animator.Play("Idle");
            }
        }
    }
    public void OnPower()
    {
        if (!fall)
        {
            fall = true;
            animator.Play("Fall");
        }
        else
        {

        }
    }

}