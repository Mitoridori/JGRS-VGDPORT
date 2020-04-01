using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectible : MonoBehaviour, IQuestID
{
    public string ItemID;
    public int ResetTime;

    public Item item;
    PlayerInventory PI;
    Player player;


    public string ID { get; set; }

    PlayerController PC;

    private void Awake()
    {
        ID = ItemID;
        PI = FindObjectOfType<PlayerInventory>();
        player = FindObjectOfType<Player>();

    }
    public void OnInteract()
    {
        if (!PI.IsFull())
        {
            PI.Add(item);

            gameObject.SetActive(false);

            Cleared();

            Invoke("reset", ResetTime);
        }
        else if (PI.IsFull())
        {
            Debug.Log("Your inventory is full");
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        PC = other.GetComponent<PlayerController>();

        if (other.gameObject.tag == "Player")
        {
            if (!PI.IsFull())
            {
                PI.Add(item);

                gameObject.SetActive(false);

                Cleared();

                Invoke("reset", ResetTime);
            }
            else if (PI.IsFull())
            {
                Debug.Log("Your inventory is full");
            }
        }
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

