using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Invoke("LoadScene", 0.5f);
        }
    }


    void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
