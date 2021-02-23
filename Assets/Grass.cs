using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    Animator animator;
    BoxCollider2D cldr;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        cldr = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Lawnmower>() != null)
        {
            animator.Play("Mowed");

            cldr.size = new Vector2(0, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
