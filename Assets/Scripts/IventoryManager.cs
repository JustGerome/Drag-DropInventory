using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class IventoryManager : MonoBehaviour
{

    public List<InventoryItems> items;
    public List<InventorySlot> inventorySlots;
   
    public GameObject itemRefence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(InventoryItems newItem) {

        if (items.Count <= 5) {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i]._item == null)
                {
                    items[i] = newItem;
                    Debug.Log("Item Added: " + newItem._item.name);

                    GameObject spawnedItem = Instantiate(itemRefence, inventorySlots[i].transform);
                    spawnedItem.GetComponent<Item>()._item = newItem;
                    spawnedItem.GetComponent<Item>().index = i;
                    break;

                }
            }
        }
    }

    public void DeleteItem(int index) {
        items[index]._item = null;
    }
}

[System.Serializable]
public class InventoryItems {
    public ItemInfo _item;
    public int currentDurability;
}
