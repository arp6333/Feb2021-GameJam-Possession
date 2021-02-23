using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : PuzzleObject
{

    public GameObject Fireball;

    public override void OnPosses(bool value)
    {
        if(value)
        {
            PlayAnimation("Idle");
        }
        else
        {
            PlayAnimation("IdleLocked");

        }
    }
    public override void OnPower()
    {
        Instantiate(Fireball);
        Fireball.transform.position = transform.position - 0.45f * Vector3.up + Vector3.left * 1.0f;
        Fireball.transform.parent = transform.parent;
    }
    public override void OnLockChange(bool value)
    {
        if(value)
        {
            PlayAnimation("Idle");

        }
        else
        {
            PlayAnimation("Unlock");

        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
