using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalNPC : InterNPC, IEndPoint
{

    public string ItemID;

    public override void Interact()
    {
        ID = ItemID;

        if (executor)
            for (int i = 0; i < QM.ActiveQuest.Count; i++)
            {
                if (QM.ActiveQuest[i].QuestName == "FindAnimals")
                    executor.enabled = true;
                else
                    break;
            }
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
