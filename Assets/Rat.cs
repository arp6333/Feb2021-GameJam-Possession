using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : PossessableObject
{
    SpriteRenderer sp;
    Animator animator;
    public float speed = 4;
    bool moving = false;
    private float baseY;
    public void OnPosses(bool b)
    {
        if (b)
        {
            animator.Play("idle");
        }
        else
        {
            animator.Play("idle-possessed");
        }
    }
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        baseY = transform.position.y;
        animator = GetComponent<Animator>();
        AddListenerPossess(OnPosses);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    private void FixedUpdate()
    {
        if (possessed)
        {
            moving = false;
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(KeyCode.D))
            {
                sp.flipX = false;
                moving = true;
                dir = Vector3.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                sp.flipX = true;
                moving = true;
                dir = Vector3.left;
            }
            if(moving)
            {
                animator.Play("Run");
            }
            else
            {
                animator.Play("Idle-Possessed");
            }
            
            Debug.Log(dir * speed * Time.deltaTime);
            transform.position += dir * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
        }

    }
}
