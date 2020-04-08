using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenController : BaseMenuController
{
   public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
