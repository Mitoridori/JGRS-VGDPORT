using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitUIController : MonoBehaviour
{
    GameObject quitWindow;
    bool isActive;

    private void Awake()
    {
        isActive = true;
        quitWindow = GameObject.FindGameObjectWithTag("QuitWindow");
        quitWindow.SetActive(!isActive);
    }

    public void ToggleQuitWindow()
    {
        isActive = !isActive;
        quitWindow.SetActive(!isActive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}