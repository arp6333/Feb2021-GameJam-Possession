using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool open = false;
    Animator animator;
    public List<Lock> locksRequired;

    private void lockChanged(bool val)
    {
        for(int i = 0; i<locksRequired.Count;i++)
        {
            if(locksRequired[i].Get())
            {
                if(open)
                {
                    CloseDoor();
                }
                return;
            }
        }
        Debug.Log("OPENING");
        OpenDoor();
    }
    private void Awake()
    {
        for(int i = 0; i<locksRequired.Count;i++)
        {
            locksRequired[i].AddListener(lockChanged);
        }
         animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        open = true;
        animator.Play("DoorOpening");
    }
    public void CloseDoor()
    {
        open = false;
        animator.Play("DoorClosing");
    }
    public bool IsOpen()
    {
        return open;
    }
    public void FixedUpdate()
    {

    }

    private void Update()
    {
    }
}
