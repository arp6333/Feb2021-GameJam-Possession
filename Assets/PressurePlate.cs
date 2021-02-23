using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Triggerer
{
    public List<GameObject> IgnoreObjects;
    private List<GameObject> objs;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        objs = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {


        //For now we check if object is frog, gonna have todo more
        if(other != null)
        {
            if (!IgnoreObjects.Contains(other.gameObject))
            {
                objs.Add(other.gameObject);
                AddedObject();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (!IgnoreObjects.Contains(collision.gameObject))
            {

                animator.Play("Open");
                objs.Remove(collision.gameObject);
                RemovedObject();
            }
        }
    }
    private void AddedObject()
    {
        if(objs.Count == 1)
        {

            animator.Play("Closed");
            TriggerThings();
        }
    }
    private void RemovedObject()
    {
        if(objs.Count == 0)
        {
            animator.Play("Open");

            TriggerThings();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
