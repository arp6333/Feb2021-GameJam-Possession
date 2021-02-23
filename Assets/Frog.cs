using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : PossessableObject
{
    Rigidbody2D rb;
    SpriteRenderer rend;


    public float Gravity = 9.8f;


    public float speed = 2.0f;
    public float jumpForce = 100.0f;


    private float downSpeed = 0;
    private bool grounded = false;
    private bool jumping = false;


    Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();

        rb = transform.parent.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        rend = GetComponent<SpriteRenderer>();
    }

    

    private void Update()
    {
        Vector2 position = new Vector2(transform.parent.position.x, transform.parent.position.y);


        if (possessed)
        {





            if (jumping)
            {
                Vector2 direction = Vector2.zero;

                if (Input.GetKey(KeyCode.A))
                {
                    rend.flipX = true;
                    direction -= Vector2.right;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rend.flipX = false;
                    direction += Vector2.right;
                }

                Vector3 adjDirection = new Vector3(direction.x, direction.y, 0);


                transform.parent.position += adjDirection * speed * Time.deltaTime;

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grounded)
                {
                    animator.Play("FrogJump");
                    downSpeed = -jumpForce;
                    jumping = true;
                }
                else
                {
                    Debug.Log("JUMP FAIL NOT GROUNDED");
                }
            }

        }


        //Ground detection seems to be working

        //get world space size (this version handles rotating correctly)
        Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector3 world_size = local_sprite_size;
        world_size.x *= transform.lossyScale.x;
        world_size.y *= transform.lossyScale.y;

        RaycastHit2D hit = Physics2D.Raycast(transform.parent.position,  Vector2.down, world_size.y / 2.0f  + 0.01f, LayerMask.GetMask("Wall"));
        if (hit.transform != null)
        {
            if (downSpeed > 0)
            {
                downSpeed = 0;
                jumping = false;
            }

            if(!grounded)
            {
            }

            grounded = true;
        }
        else
        {
            if(grounded)
            {
            }
            grounded = false;
            downSpeed += Gravity * Time.deltaTime;

        }


        //Gravity and whatnot;

        transform.parent.position += Vector3.down * downSpeed * Time.deltaTime;
    }

    public override void Posses()
    {
        base.Posses();
        animator.Play("FrogPossessedIdle");


    }
    public override void Unposses()
    {
        base.Unposses();
        animator.Play("FrogIdle");
    }
}
