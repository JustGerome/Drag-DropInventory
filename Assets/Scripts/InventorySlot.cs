using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public bool isOccupied;
    public IventoryManager _invnetoryManager;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        _invnetoryManager = GameObject.Find("InventoryManager").GetComponent<IventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
            
            
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        //dropped.GetComponent<InventorySlot>()._item = _item;
        Debug.Log(dropped.name);

        if (transform.childCount <= 1)
        {
            GameObject currentItem = dropped.GetComponent<Item>().gameObject;


            InventoryItems newItem = new InventoryItems();
            newItem._item = null;
            newItem.currentDurability = 0;

            _invnetoryManager.items[currentItem.GetComponent<Item>().index] = newItem;
            _invnetoryManager.items[index] = currentItem.GetComponent<Item>()._item;


            currentItem.GetComponent<Item>().parentAfterDrag = transform;
            currentItem.GetComponent<Item>().index = index;


        }

        else {

            GameObject currentItem = dropped.GetComponent<Item>().gameObject;
            GameObject targetItem = transform.GetChild(1).gameObject;

            _invnetoryManager.items[currentItem.GetComponent<Item>().index] = targetItem.GetComponent<Item>()._item;
            _invnetoryManager.items[targetItem.GetComponent<Item>().index] = currentItem.GetComponent<Item>()._item;

            currentItem.GetComponent<Item>().index = index;
            targetItem.GetComponent<Item>().index = dropped.GetComponent<Item>().parentAfterDrag.GetComponent<InventorySlot>().index;

            targetItem.transform.SetParent(dropped.GetComponent<Item>().parentAfterDrag);
            currentItem.GetComponent<Item>().parentAfterDrag = transform;


        }
    }

    public void SpawnItem() {
        
    }
}

