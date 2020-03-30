using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject inv;
    public GameObject shopUI;

    bool invClicked = false;

    public void ToggleInventory()
    {
        invClicked = !invClicked;
        if (inv)
            inv.SetActive(invClicked);
    }

    public void CloseShop()
    {
        if (shopUI)
            shopUI.SetActive(false);
    }

}
