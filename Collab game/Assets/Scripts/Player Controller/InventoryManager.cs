using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Transform plrObj;
    public Transform dropParent;

    [Header("Pick Up Settings")]
    public GameObject crosshair1; //1-Normal 2-Pick up 3-Drag
    public GameObject crosshair2;
    public GameObject crosshair3;
    public Transform _objectParent;
    public Transform _cameraTrans;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        ListItems(); //Update list
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems(); //Update poop
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent) //Clean up all buttons currently in inventory thingy
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items) //Adds the buttons
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("Name").GetComponent<TMP_Text>();
            itemName.text = item.itemName;
            
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            itemIcon.sprite = item.icon;

            obj.GetComponent<InvButton>().item = item;
            obj.GetComponent<InvButton>().plrObject = plrObj;
            obj.GetComponent<InvButton>().dropsParent = dropParent;

            //pickup
            obj.GetComponent<InvButton>().crosshair1 = crosshair1;
            obj.GetComponent<InvButton>().crosshair2 = crosshair2;
            obj.GetComponent<InvButton>().crosshair3 = crosshair3;
            obj.GetComponent<InvButton>()._objectParent = _objectParent;
            obj.GetComponent<InvButton>()._cameraTrans = _cameraTrans;
        }
    }
}