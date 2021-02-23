using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableObject : MonoBehaviour
{

    public virtual void OnObjectTrigger()
    {
        throw new System.NotImplementedException();
    }
    public virtual void Untrigger()
    {
        throw new System.NotImplementedException();
    }
}
