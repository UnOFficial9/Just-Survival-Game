using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Slot[] slot;
    public int activeSlot;

    void Update()
    {
        CheckForSlots();
        Debug.Log(activeSlot);
    }


    void CheckForSlots()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeSlot = 1;
            slot[0].Objects();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeSlot = 2;
            slot[1].Objects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeSlot = 3;
            slot[2].Objects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activeSlot = 4;
            slot[3].Objects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            activeSlot = 5;
            slot[4].Objects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            activeSlot = 6;
            slot[5].Objects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            activeSlot = 7;
            slot[6].Objects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            activeSlot = 8;
            slot[7].Objects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            activeSlot = 9;
            slot[8].Objects();
        }

    }
}
