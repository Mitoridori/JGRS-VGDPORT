using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";    // Name of the item
    public Sprite icon = null;              // Item icon
    public bool showInInventory = true;
    Inventory inventory;
    public int ItemCost;

    [TextArea(3, 10)]
    public string details;


    public virtual string GetDetails()
    {
        return details;
    }

    // Called when the item is pressed in the inventory
    public void Start()
    {
        //inventory = FindObjectOfType<Inventory>();
    }

    public virtual void Use()
    {
        // Use the item

    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        inventory.Remove(this);
    }

}

