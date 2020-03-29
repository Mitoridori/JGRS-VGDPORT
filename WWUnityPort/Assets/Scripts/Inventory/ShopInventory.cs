using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : Inventory
{

    PlayerInventory PI;

    void Start()
    {
        PI = FindObjectOfType<PlayerInventory>();


    }
    



}
