using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockEvent : UnityEvent<bool>
{

}

public class Lock : MonoBehaviour
{
    [SerializeField]
    protected bool locked = false;
    LockEvent evnt;

    private void Awake()
    {
        if (evnt == null)
        {
            evnt = new LockEvent();
        }
    }

    public void Toggle()
    {
        locked = !locked;
        evnt.Invoke(locked);
    }
    public void Set(bool b)
    {
        locked = b;
        evnt.Invoke(b);
    }
    public bool Get()
    {
        return locked;
    }
    public void AddListener(UnityAction<bool> call)
    {
        if(evnt == null)
        {
            evnt = new LockEvent();
        }
        evnt.AddListener(call);
    }
    
}
