using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalStageController : MonoBehaviour
{
    public GameObject[] portals;

    // Start is called before the first frame update
    void Start()
    {
        portals = new GameObject[gameObject.transform.childCount];

        for (int i = 0; i < portals.Length; i++)
        {
            portals[i] = transform.GetChild(i).gameObject;
        }
    }

    public void SwitchPortalStage()
    {
        for (int i = 0; i < portals.Length; i++)
        {
            if(portals[i].activeInHierarchy)
            {
                portals[i].SetActive(false);
                if (i + 1 >= portals.Length)
                    break;
                portals[i + 1].SetActive(true);
                return;
            }
        }
    }

    private void Update()
    {
        if (portals[portals.Length - 1].activeInHierarchy)
            EnableTrigger();
    }

    void EnableTrigger()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
