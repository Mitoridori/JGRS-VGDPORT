using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public ErrorMessage EM;
    public int space = 10;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<Item> items = new List<Item>();

    private void Start()
    {
        EM = FindObjectOfType<ErrorMessage>();
    }

    // Add a new item if enough room
    public void Add(Item item)
    {
        if (item.showInInventory)
        {
            if (items.Count >= space)
            {
                EM.InventoryFull();
                Debug.Log("Not enough room.");
                return;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public bool IsFull()
    {
        if (items.Count >= space)
        {
            return true;
        }

        return false;
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}

