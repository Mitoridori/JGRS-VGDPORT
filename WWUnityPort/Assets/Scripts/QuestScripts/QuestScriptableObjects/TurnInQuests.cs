using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/TurnInQuest")]

public class TurnInQuests : Quests
{
    public string StartNPC;
    public string NPCHandInName;
    public List<string> TurnOffShop = new List<string>();

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
            NPCHandIn.GetComponent<QuestNPC>().HasQuests = true;
        }
    }

    public override void ChangeHasQuests()
    {
        NPCStart = GameObject.Find(StartNPC);
        if (NPCStart)
        {
            NPCStart.GetComponent<QuestNPC>().HasQuests = false;
        }
    }


}
