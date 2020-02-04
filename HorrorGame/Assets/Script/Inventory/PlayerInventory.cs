﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObjects inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<InventoryItems>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }
}
