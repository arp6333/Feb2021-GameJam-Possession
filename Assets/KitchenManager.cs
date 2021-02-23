using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{

    public Lock doorLock;

    bool OvenOn = false;
    bool MacIn = false;
    bool TimerOn = false;
    bool TimerFinished = false;
    bool CheeseIn = false;
    bool PotOnFloor = false;
    bool FridgeOpen = false;
    bool MilkInPot = false;
    bool MacDone = false;

    public List<PuzzleObject> objectsOrder;
    private List<PossessableObject> objs;
    public Player_Controller player;

    private int index = 0;

    private int cabinetCount;
    private int FridgeCount;
    private int OvenCount = 0;
    private int lastIndexTask = -1;
    private bool CanPass = true;
    bool dinged = false;

    private void OnDing()
    {
        //Only ding if we did it right
        if (MacIn)
        {
            Debug.Log("TIMER DONE");
            TimerFinished = true;
        }
    }
    private void Awake()
    {
        objs = new List<PossessableObject>();
        for(int i = 0; i<objectsOrder.Count;i++)
        {
            objs.Add(objectsOrder[i].GetComponent<PossessableObject>());
            objs[i].AddListenerPossess(OnPosses);
            if (i != 4)
            {
                objs[i].AddListenerPower(OnPowerUse);
            }
        }
        objectsOrder[2].GetComponent<EggTimer>().OnTimerCompletion.AddListener(OnDing);
    }

    private void OnPosses(bool b)
    {
        //Figure out who was possessed;
        for(int i = 0; i<objectsOrder.Count;i++)
        {
            if(objs[i].possessed)
            {
                index = i;
                return;
            }
        }
        index = -1;
    }
    private void OnPowerUse()
    {

        if (index == 5)
        {
            FridgeCount++;
            if (FridgeCount > 1)
            {
                if(!PotOnFloor)
                {
                    Debug.Log("FAILURE, SPILLED MILK");
                }
                else
                {
                    Debug.Log("WIN");

                    doorLock.Set(false);

                    MilkInPot = true;
                    MacDone = true;
                }
            }
            else if(FridgeCount == 1)
            {
                FridgeOpen = true;
            }
        }


        if (index == 0)
        {
            OvenCount++;
            if (OvenCount == 1)
            {
                Debug.Log("OVEN ON");
                OvenOn = true;
            }
            if (OvenCount == 2)
            {
                Debug.Log("POT ON FLOOR");
                PotOnFloor = true;
            }
            if (PotOnFloor && (! (MacIn && CheeseIn)))
            {
                Debug.Log("FAILURE, KNOCKED OVER POT TOO SOON");
            }
        }
        else if (index == 1)
        {
            //Mac n cheese
            if (!OvenOn)
            {
                Debug.Log("Failure, oven not on");
            }
            else
            {
                Debug.Log("MAC IN");
                MacIn = true;
            }
        }
        else if (index == 2)
        {
            Debug.Log("TIMER ON");
            TimerOn = true;
        }
        else if (index == 3)
        {
            if (!TimerFinished)
            {
                Debug.Log("Failure, didn't wait for ding");
            }
            else
            {
                Debug.Log("CHEESE IN");
                CheeseIn = true;
            }
        }
        else if(index == 4)
        {
            //Hanlded in index =0
        }
        else if(index == 5)
        {
            //handled earlier
        }

            //We should 
            /*

            Debug.Log("POWAH");
            if(index == 5)
            {
                FridgeCount++;
                if(FridgeCount > 1)
                {
                    CanPass = false;
                }
                else
                {
                    if(lastIndexTask != 5-1)
                    {
                        Debug.Log("FAILURE, SPILLED THE MILK");
                        CanPass = false;
                    }
                }
            }
            else if(index == 6)
            {

            }

            else
            {
                //We activated teh same thing again, and wasn't fridge
                if(index == lastIndexTask)
                {
                    CanPass = true;                
                }
                else if(index -1 != lastIndexTask)
                {
                    Debug.Log("FAILURE, DID TASK OUT OF ORDER");
                    CanPass = false;
                }
                else
                {
                    //Doing it in the right order.

                    if (index == 3)
                    {
                        if (!dinged)
                        {
                            Debug.Log("FAILURE, DIDNT WAIT FOR DING");
                            CanPass = false;
                        }
                    }
                    if(CanPass)
                    {
                        Debug.Log("NEXT STAGE");
                        lastIndexTask = index;
                    }

                }
            }
            if(!CanPass)
            {
                Debug.Log("FAILURE");
            }
            */
        }

    private void Update()
    {
        
    }
}
