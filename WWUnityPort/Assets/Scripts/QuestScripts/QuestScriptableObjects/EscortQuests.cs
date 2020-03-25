using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Escort")]
//NAME : EscortQuests
//PURPOSE : Set up for the escort quests. 
public class EscortQuests : Quests
{
    public List<string> CNPC = new List<string>();

    public override void Load()
    {

        CurrentAmount = 0;
        Completed = false;
        Goals.Add(new EscortQuest(this, NPCID, "Kill " + RequiredAmount + " " + NPCID, false, CurrentAmount, RequiredAmount, CoinReward));
        Goals.ForEach(g => g.Init());

        for (int i = 0; i < CNPC.Count; i++)
        {
            GameObject NPC;
            NPC = GameObject.Find(CNPC[i]);
            if (NPC)
            {
                NPC.GetComponent<InterNPC>().CanMove = true;
            }
        }
    }

}
