using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : MonoBehaviour

{
    // Start is called before the first frame update
    public Transform itemsParent;   // The parent object of all the items
    ShopInventory inventory;    // Our current inventory
    PlayerInventory PI;
    public InventoryUISlots[] slots;

    void Start()
    {
        inventory = FindObjectOfType<ShopInventory>();
        inventory.onItemChangedCallback += UpdateUI;
        PI = FindObjectOfType<PlayerInventory>();

        slots = itemsParent.GetComponentsInChildren<InventoryUISlots>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
