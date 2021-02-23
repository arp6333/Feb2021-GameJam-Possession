using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painting : PossessableObject
{


    public GameObject frog;

    bool open = false;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        AddListenerPower(OnPower);
        AddListenerPossess(OnPossess);

        frog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPossess(bool value)
    {
        if(!open)
        {
            if (value)
            {
                animator.Play("CloseState-Possessed");
            }
            else
            {
                animator.Play("CloseState");
            }
        }
    }
    public void OnPower()
    {
        if(!open)
        {
            open = !open;
            animator.Play("Open");
            frog.SetActive(true);
        }
        else
        {
            open = !open;

            animator.Play("Close");
        }
    }

}
