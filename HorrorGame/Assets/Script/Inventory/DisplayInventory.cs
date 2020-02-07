using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventory : MonoBehaviour
{
    public InventoryObjects inventory;

    public int myXSpaceBetweenItem;
    public int myYSpaceBetweenItem;
    public int myNumberOfColumns;
    public int myXstart;
    public int myYStart;


    Dictionary<InventoryObjects.InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventoryObjects.InventorySlot, GameObject>();
    void Start()
    {
        CreateDisplay();
    }
    private void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].myAmount.ToString("n0");
            }           
            else
            {
                var obj = Instantiate(inventory.Container[i].myItem.prefab, Vector3.zero, Quaternion.identity, transform);
                
                obj.GetComponent<RectTransform>().localPosition = GetPostion(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].myAmount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);

               
            }
            
        }
    }
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].myItem.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPostion(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].myAmount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
            
        }
    }
    public Vector3 GetPostion(int i)
    {
        return new Vector3(myXstart + (myXSpaceBetweenItem * (i % myNumberOfColumns)), myYStart + (-myYSpaceBetweenItem* (i/myNumberOfColumns)), 0f);
    }

}
