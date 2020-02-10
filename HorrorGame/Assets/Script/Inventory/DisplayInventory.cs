using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DisplayInventory : MonoBehaviour
{
    public InventoryObjects inventory;

    public int myXSpaceBetweenItem;
    public int myYSpaceBetweenItem;
    public int myNumberOfColumns;
    public int myXstart;
    public int myYStart;
    GameObject obj;
    public int myButtonId;
    public GameObject myInventoryMenu;

    Dictionary<InventoryObjects.InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventoryObjects.InventorySlot, GameObject>();
    List<GameObject> myObjects = new List<GameObject>();
    void Start()
    {

        CreateDisplay();
        myInventoryMenu.SetActive(false);
       

    }
    private void Update()
    {
        if(inventory.Container.Count != 0)
        {
            UpdateDisplay();
        }
       
    }
    public void UpdateDisplay()
    {
        HideDisplay();
        

        if (inventory.Container.Count > 0)
        {
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (itemsDisplayed.ContainsKey(inventory.Container[i]))
                {
                    itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].myAmount.ToString("n0");

                }
                else
                {
                    
                    obj = Instantiate(inventory.Container[i].myItem.prefab, Vector3.zero, Quaternion.identity, transform);
                    myObjects.Add(obj);
                    
                    if (obj.GetComponent<Button>())
                    {
                        obj.GetComponent<Button>().onClick.AddListener(UseTheItem);
                    }
                   


                    obj.GetComponent<RectTransform>().localPosition = GetPostion(i);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].myAmount.ToString("n0");
                    itemsDisplayed.Add(inventory.Container[i], obj);
                    itemsDisplayed[inventory.Container[i]].gameObject.SetActive(false);



                }
               
            }
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                if (inventory.Container[i].myItem == null)
                {
                    inventory.Container.RemoveAt(i);
                }
                if (inventory.Container[i].myAmount <= 0)
                {
                    Debug.Log("True 1");
                    Destroy(itemsDisplayed[inventory.Container[i]].gameObject);
                    itemsDisplayed.Remove(inventory.Container[i]);
                    inventory.Container.RemoveAt(i);

                    for (int a = 0; a < inventory.Container.Count; a++)
                    {
                        Destroy(itemsDisplayed[inventory.Container[a]].gameObject);
                        itemsDisplayed.Remove(inventory.Container[a]);
                    }
                    UpdateDisplay();

                }
            }
        }
    }
        public void CreateDisplay()
        {
         if(inventory.Container.Count > 0)
         {
            for (int i = 0; i < inventory.Container.Count; i++)
            {
                var obj = Instantiate(inventory.Container[i].myItem.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPostion(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].myAmount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);

            }
         }
            
        }
    
       
    public void HideDisplay()
    {
        
        if (inventory.Container.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                myInventoryMenu.SetActive(!myInventoryMenu.activeSelf);
                for (int i = 0; i < inventory.Container.Count; i++)
                {                    
                    itemsDisplayed[inventory.Container[i]].gameObject.SetActive(!itemsDisplayed[inventory.Container[i]].gameObject.activeSelf);
                }
             
            }
        }
        else
        {
            myInventoryMenu.SetActive(false);
        }
        
        
    }
    public Vector3 GetPostion(int i)
    {
        
            return new Vector3(myXstart + (myXSpaceBetweenItem * (i % myNumberOfColumns)), myYStart + (-myYSpaceBetweenItem * (i / myNumberOfColumns)), 0f);
        
       
    }

    //public static InventoryObjects inventory2;
    public void UseTheItem()
    {
        if(inventory.Container.Count != 0)
        {
            inventory.Container[RemoveItem.AccessButtonInt].myItem.UseItem();
            inventory.Container[RemoveItem.AccessButtonInt].myAmount -= 1;
            Debug.Log("True");
            myInventoryMenu.SetActive(false);
        }
    }

    //void DestroyTheItemDisplay()
    //{

    //        for (int a = 0; a < myObjects.Count; a++)
    //        {
    //            if(itemsDisplayed.ContainsValue(myObjects[a]))
    //            {
    //            Destroy(myObjects[a]);
    //            }
    //        }

    //}
    //public static int AccessButtonInt { get => myItems; set => myItems = value; }

}
