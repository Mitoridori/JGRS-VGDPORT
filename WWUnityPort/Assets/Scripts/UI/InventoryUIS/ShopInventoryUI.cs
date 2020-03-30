using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : InventoryUI

{
    // Start is called before the first frame update

    ShopInventory inventory;    // Our current inventory
    PlayerInventory PI;

    void Start()
    {
        inventory = FindObjectOfType<ShopInventory>();
        inventory.onItemChangedCallback += UpdateUI;
        PI = FindObjectOfType<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void SellItem(Item item)
    {
        if (!PI.IsFull())
        {
            PI.Add(item);
            //player.SubtractCoins(item.ItemCost);
        }
        else
        {
            Debug.Log("Your inventory is full");
        }
    }


}
