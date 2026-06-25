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
        }
    }
}