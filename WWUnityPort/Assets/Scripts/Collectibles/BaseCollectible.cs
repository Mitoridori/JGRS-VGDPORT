using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectible : MonoBehaviour, IQuestID
{
    public string ItemID;
    public int ResetTime;

    public string ID { get; set; }

    PlayerController PC;

    private void Awake()
    {
        ID = ItemID;

    }
    public void OnInteract()
    {
        gameObject.SetActive(false);
        Cleared();

        Invoke("reset", ResetTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PC = other.GetComponent<PlayerController>();

        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Cleared();
        }
        this.Invoke("reset", ResetTime);

    }

    void reset()
    {
        gameObject.SetActive(true);
    }
    public void Cleared()
    {
        QuestEvents.ItemCleared(this);
    }

}

