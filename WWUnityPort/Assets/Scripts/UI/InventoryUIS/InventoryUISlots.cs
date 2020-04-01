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
    PlayerInventory PI;
    Player player;
    ErrorMessage EM;


    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        PI = FindObjectOfType<PlayerInventory>();
        player = FindObjectOfType<Player>();
        EM = FindObjectOfType<ErrorMessage>();

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
            transform.root.Find("PlayerHUD/ShopUI/ShopBackgroundImage/InfoBackgroundImage/BuyButton").GetComponent<Button>().onClick.AddListener(SellItem);

        }           
    }

    public void SellItem()
    {
        if (item != null)
        {
            if (!PI.IsFull() && player.GetPlayerCoins() >= item.ItemCost)
            {
                PI.Add(item);
                player.SubtractCoins(item.ItemCost);
            }
            else if (PI.IsFull())
            {
                EM.InventoryFull();
                Debug.Log("Your inventory is full");
            }
            else
            {
                EM.NoCoin();
                Debug.Log("You don't have enough coin");
            }
        }
    }

    public void SelltoStore()
    {
        if (item !=null && transform.root.Find("PlayerHUD/ShopUI").gameObject.activeInHierarchy)
        {
            player.AddCoins(item.ItemCost);
            PI.Remove(item);
        }
    }


}

