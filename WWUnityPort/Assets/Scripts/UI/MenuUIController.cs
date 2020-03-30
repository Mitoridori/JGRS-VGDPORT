using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public Button[] buttons;

    bool clicked = false;

    public void OnClick()
    {
        clicked = !clicked;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Animator>().SetBool("isActive", clicked);
        }
    }
}
