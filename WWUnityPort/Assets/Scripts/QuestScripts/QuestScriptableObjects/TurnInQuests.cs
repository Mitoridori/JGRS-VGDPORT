using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/TurnInQuest")]

public class TurnInQuests : Quests
{
    public string NPCHandInName;
    public List<string> CNPC = new List<string>();

    public override void Load()
    {
        CurrentAmount = 0;
        Completed = false;
        Goals.Add(new TurnInQuest(this, NPCID, "Kill " + RequiredAmount + " " + NPCID, false, CurrentAmount, RequiredAmount, CoinReward, NPCHandInName));
        Goals.ForEach(g => g.Init());

        SecondNPC = true;
        NPCHandIn = GameObject.Find(NPCHandInName);
        if (NPCHandIn)
        {
            NPCHandIn.GetComponent<QuestNPC>().isSecondaryNPC = true;
            NPCHandIn.GetComponent<QuestNPC>().Quest = this;
        }
        for (int i = 0; i < CNPC.Count; i++)
        {
            GameObject NPC;
            NPC = GameObject.Find(CNPC[i]);
            if (NPC)
            {
                NPC.GetComponent<QuestNPC>().HasQuests = true;
            }
        }

    }
}
