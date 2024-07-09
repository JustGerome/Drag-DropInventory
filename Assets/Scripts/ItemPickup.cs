using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public IventoryManager _inventoryManager;
    public ItemInfo _itemInfo;
    SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _itemInfo.art;
        _inventoryManager = GameObject.Find("InventoryManager").GetComponent<IventoryManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
       // Destroy(gameObject);

        InventoryItems newItem = new InventoryItems();
        newItem._item = _itemInfo;
        newItem.currentDurability = _itemInfo.durability;
        _inventoryManager.AddItem(newItem);

    }
}
