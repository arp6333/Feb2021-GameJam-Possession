using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PossessableObject : MonoBehaviour
{

    BoolEvent OnPosses = new BoolEvent();
    UnityEvent OnPower = new UnityEvent();

    public bool possessed = false;
    public bool CanPosses = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Posses()
    {
        possessed = true;

        OnPosses.Invoke(true);
    }
    public virtual void Unposses()
    {
        OnPosses.Invoke(false);
        possessed = false;
    }
    public void AddListenerPossess(UnityAction<bool> call)
    {
        OnPosses.AddListener(call);
    }
    public void AddListenerPower(UnityAction call)
    {
        OnPower.AddListener(call);
    }
    public void UsePower()
    {

        OnPower.Invoke();
    }
}
