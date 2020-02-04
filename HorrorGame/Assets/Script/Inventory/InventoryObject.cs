using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _myItem, int _myAmount)
    {
        bool tempHasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].myItem == _myItem)
            {
                Container[i].AddAmount(_myAmount);
                tempHasItem = true;
                break;
            }
        }
        if (!tempHasItem)
        {
            Container.Add(new InventorySlot(_myItem, _myAmount));
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        public ItemObject myItem;
        public int myAmount;
        public InventorySlot(ItemObject _myItem, int _myAmount)
        {
            myItem = _myItem;
            myAmount = _myAmount;
        }
        public void AddAmount(int Value)
        {
            myAmount += Value;
        }

    }
    


}
