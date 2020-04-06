using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Message;
    public GameObject ErrorBox;
    public GameObject CloseButton;

    public void Close()
    {
        ErrorBox.SetActive(false);
    }

    public void InventoryFull()
    {
        ErrorBox.SetActive(true);
        Title.text = "Inventory Error";
        Message.text = "Your inventory is full, please sell items.";
    }

    public void NoCoin()
    {
        ErrorBox.SetActive(true);
        Title.text = "Coin Error";
        Message.text = "You do not have the coin to buy this item.";
    }

    public void NotforSale()
    {
        ErrorBox.SetActive(true);
        Title.text = "Inventory Error";
        Message.text = "This item is not for sale.";
    }

}
