using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : InterNPC
{
    public void Awake()
    {

    }

    public override void Update()
    {
        CloseMenuToggle();
        LookAt();
    }
    public override void Interact()
    {
        isActive = !isActive;
        Debug.Log("ShopKeeper interacted with.");
    }

    public void GetItem()
    {
        //inventory.
    }
}
