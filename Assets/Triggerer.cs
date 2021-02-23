using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerer : MonoBehaviour
{
    public List<Lock> locksToToggle;
    public bool SetValue = false;
    public bool ValueToSet = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerThings()
    {

        foreach (Lock lck in locksToToggle)
        {
            if(SetValue)
            {
                lck.Set(ValueToSet);
            }
            else
            {
                lck.Toggle();
            }
        }
    }
}
