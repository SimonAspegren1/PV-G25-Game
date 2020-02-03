using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory System/Inventory" )]
public class IventoryObjects : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemClass _myitem, int _myAmount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].myItem == _myitem)
            {
                Container[i].AddAmount(_myAmount);
                hasItem = true;
                break;
            }
           
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_myitem, _myAmount));
        }
    }


    [System.Serializable]
    public class InventorySlot
    {
        public ItemClass myItem;
        public int myAmount;
        public InventorySlot(ItemClass _myitem, int _myAmount)
        {
            myItem = _myitem;
            myAmount = _myAmount;
        }
        public void AddAmount(int Value)
        {
            myAmount += Value;
        }

    }


}
