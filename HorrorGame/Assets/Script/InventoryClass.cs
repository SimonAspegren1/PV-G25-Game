using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryObjects : ScriptableObject
{
    public List<ItemClass> Container = new List<ItemClass>();

    [System.Serializable]

    public class InventorySlot
    {
        public ItemClass item;
        public int amount;


    }


}
