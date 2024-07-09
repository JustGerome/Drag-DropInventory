using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public InventoryItems _item;
    public IventoryManager _invnetoryManager;
    public int index;
    public Image _image;
    public Image durability;


    public Transform parentAfterDrag;

    // Start is called before the first frame update
    void Start()
    {
        _invnetoryManager = GameObject.Find("InventoryManager").GetComponent<IventoryManager>();

        if (_item._item != null)
        {
            _image.sprite = _item._item.art;
            if (_item._item.durability > 0)
            {
                durability.gameObject.SetActive(true);
                durability.fillAmount = _item.currentDurability;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       transform.SetParent(parentAfterDrag);
        _image.raycastTarget = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) {

            Debug.Log("Right click");
            Destroy(gameObject);
            _invnetoryManager.DeleteItem(index);
        }
    }

}
