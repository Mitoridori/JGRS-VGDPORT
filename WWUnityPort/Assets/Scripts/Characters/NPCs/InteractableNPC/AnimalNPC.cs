using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalNPC : InterNPC, IEndPoint, IQuestID
{

    public string ID { get; set; }

    public string ItemID;

    public override void Interact()
    {
        if (executor)
            executor.enabled = true;
    }

    public void Cleared()
    {
        QuestEvents.ItemCleared(this);
    }

    public bool DidReach(bool condition)
    {
        switch(condition)
        {
            case true:
                Cleared();
                executor.enabled = false;
                gameObject.SetActive(false);
                break;

            case false:
                break;
        }

        return condition;
    }
}
