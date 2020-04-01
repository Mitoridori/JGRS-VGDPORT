using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectible : MonoBehaviour, IQuestID, IInteractable
{
    public string ItemID;
    public int ResetTime;

    public List<Item> item;
    protected PlayerInventory PI;
    Player player;
    ErrorMessage EM;

    public string ID { get; set; }

    PlayerController PC;

    private void Awake()
    {
        ID = ItemID;
        PI = FindObjectOfType<PlayerInventory>();
        player = FindObjectOfType<Player>();
        EM = FindObjectOfType<ErrorMessage>();

    }
    public virtual void OnInteract()
    {
        if (!PI.IsFull())
        {
            PI.Add(item[0]);

            gameObject.SetActive(false);

            Cleared();

            Invoke("reset", ResetTime);
        }
        else if (PI.IsFull())
        {
            EM.InventoryFull();
            Debug.Log("Your inventory is full");
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

