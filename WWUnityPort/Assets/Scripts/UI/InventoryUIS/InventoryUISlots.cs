using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryUISlots : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    GameObject TextField; 

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

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {
        inventory.Remove(item);
    }

    // Use the item
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void ItemDetails()
    {
        if (item != null)
        {
            //Item Name
            transform.root.Find("PlayerHUD/ShopUI/ShopBackgroundImage/InfoBackgroundImage/ItemNameText (TMP)").GetComponent<TextMeshProUGUI>().SetText(item.name);

            //Item Description
            transform.root.Find("PlayerHUD/ShopUI/ShopBackgroundImage/InfoBackgroundImage/ItemDescriptionText (TMP)").GetComponent<TextMeshProUGUI>().SetText(item.details);

            //Item Images
            transform.root.Find("PlayerHUD/ShopUI/ShopBackgroundImage/InfoBackgroundImage/ItemIconImage").GetComponent<Image>().sprite = item.icon;

            //Item Cost
            transform.root.Find("PlayerHUD/ShopUI/ShopBackgroundImage/InfoBackgroundImage/MoneyBar/MoneyBarPrefab/CoinText (TMP)").GetComponent<TextMeshProUGUI>().SetText(" "+ item.ItemCost);

            //Buy button
            transform.root.Find("PlayerHUD/ShopUI/ShopBackgroundImage/InfoBackgroundImage/BuyButton").GetComponent<Button>().onClick.Invoke();

        }           
    }





}

