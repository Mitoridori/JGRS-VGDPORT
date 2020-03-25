using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Collectable")]
//NAME : CollectableQuest
//PURPOSE : Holds the requirments for the collectable quest
public class CollectableQuest : Quests
{
    public List<string> CNPC = new List<string>();
    public override void Load()
    {
        CurrentAmount = 0;
        Completed = false;
        Goals.Add(new CollectingQuest(this, NPCID, "Collect " + RequiredAmount + " " + NPCID, false, CurrentAmount, RequiredAmount, CoinReward));
        Goals.ForEach(g => g.Init());

        for (int i = 0; i < CNPC.Count; i++)
        {
            GameObject NPC;
            NPC = GameObject.Find(CNPC[i]);
            if (NPC)
            {
                //NPC.GetComponent<ConversationNpc>().hasBeenTalkedTo = false;
            }
        }

    }
}

