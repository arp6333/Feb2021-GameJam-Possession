using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IOpen
{
    public  bool GetOpen();
}

public class Open_Checker : MonoBehaviour
{
    Lock lck;
    public List<GameObject> objectsToCheck;
    // Start is called before the first frame update
    void Awake()
    {
        lck = GetComponent<Lock>();

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<objectsToCheck.Count;i++)
        {
            IOpen op = objectsToCheck[i].GetComponent<IOpen>();
            if(!op.GetOpen())
            {
                lck.Set(true);
                return;
            }
            

        }
        lck.Set(false);
    }
}
