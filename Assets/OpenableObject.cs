using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenableObject : PuzzleObject
{
    private bool open;
    BoolEvent OnOpen;


    public override void Init()
    {
        base.Init();
        OnOpen = new BoolEvent();
    }


    public virtual void AddListener(UnityAction<bool> call)
    {
        OnOpen.AddListener(call);
    }
    public virtual void Open()
    {
        open = true;
        OnOpen.Invoke(open);
    }
    public virtual void SetOpen(bool value)
    {
        open = value;
        OnOpen.Invoke(open);
    }

    public virtual bool GetOpen()
    {
        return open;
    }
}
