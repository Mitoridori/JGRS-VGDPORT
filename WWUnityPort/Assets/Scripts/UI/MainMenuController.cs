﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : BaseMenuController
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

}
