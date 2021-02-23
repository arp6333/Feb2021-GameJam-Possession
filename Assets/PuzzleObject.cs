using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Lock))]
[RequireComponent(typeof(PossessableObject))]

public class PuzzleObject : MonoBehaviour
{
    protected Animator animator;
    protected Lock lck;
    protected PossessableObject pos;

    protected void PlayAnimation(string st)
    {
        lck = GetComponent<Lock>();
        animator.Play(st);
        lck.AddListener(OnLockChange);
    }
    public virtual void Init()
    {
        animator = GetComponent<Animator>();
        pos = GetComponent<PossessableObject>();

        pos.AddListenerPossess(OnPosses);
        pos.AddListenerPower(OnPower);


    }

    // Start is called before the first frame update
    void Start()
    {

    }
    public virtual void OnLockChange(bool value)
    {
        throw new System.NotImplementedException();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnPosses(bool value)
    {

    }
    public virtual void OnPower()
    {
    }
}
