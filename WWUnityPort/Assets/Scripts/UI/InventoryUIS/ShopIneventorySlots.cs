using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopIneventorySlots : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;  // Current item in the slot
    Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ItemDetails()
    {
        if (item != null)
        {
            item.GetDetails();
        }

    }

}

