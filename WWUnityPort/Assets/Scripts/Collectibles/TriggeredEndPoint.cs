using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredEndPoint : MonoBehaviour, IQuestID
{
    public string ItemID;
    public string ID { get; set; }

    PlayerController PC;

    private void Awake()
    {
        ID = ItemID;

    }
    private void OnTriggerEnter(Collider other)
    {
        PC = other.GetComponent<PlayerController>();

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<InterNPC>().CanMove = false;
            Cleared();
        }
    }
    public void Cleared()
    {
        QuestEvents.ItemCleared(this);
    }

}