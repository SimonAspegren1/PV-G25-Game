﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemoveItem : MonoBehaviour
{
    public static int myItems;
    public static int AccessButtonInt { get => myItems; set => myItems = value; }
    public DisplayInventory myDisplayInv;
    public InventoryObjects inventory;
    

    public void ReturnId(int ButtonId)
    {
        if (inventory.Container[ButtonId] != null)
        {
            Debug.Log("Hej");
            AccessButtonInt = ButtonId;
            GetComponent<Button>().onClick.AddListener(myDisplayInv.UseTheItem);
        }


    }
}
