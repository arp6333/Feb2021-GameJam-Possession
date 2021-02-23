using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EggTimer : PuzzleObject
{

    public UnityEvent OnTimerCompletion;

    private bool checkDing = false;
    private float checkDingTime = 2.0f;
    private float checkDingStart = 0.0f;
    public override void OnLockChange(bool value)
    {
        if(value)
        {
            PlayAnimation("IdleLocked");

        }
        else
        {
            PlayAnimation("Idle");

        }
    }
    public void StartTimer()
    {
        checkDingStart = Time.time;
        checkDing = true;
        animator.Play("Timing");
    }
    // Start is called before the first frame update
    void Awake()
    {
        Init();

        animator = GetComponent<Animator>();

        PlayAnimation("IdleLocked");
    }

    public override void OnPosses(bool value)
    {
        OnLockChange(!value);
    }
    public override void OnPower()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkDing)
        {
            if(Time.time - checkDingStart >= checkDingTime)
            {
                OnTimerCompletion.Invoke();
                checkDing = false;
            }
        }
    }
}
