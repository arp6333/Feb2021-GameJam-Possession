using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : PossessableObject
{

    Animator animator;
    public float speed = 3;
    public void OnPosses(bool b)
    {
        if (b)
        {
            animator.Play("idle");
        }
        else;
        {
            animator.Play("idle-possessed");
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        AddListenerPossess(OnPosses);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    private void FixedUpdate()
    {
        if (possessed)
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(KeyCode.D))
            {
                dir = Vector3.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                dir = Vector3.left;
            }
            Debug.Log(dir * speed * Time.deltaTime);
            transform.position += dir * speed * Time.deltaTime;
        }
        
    }
    
}
