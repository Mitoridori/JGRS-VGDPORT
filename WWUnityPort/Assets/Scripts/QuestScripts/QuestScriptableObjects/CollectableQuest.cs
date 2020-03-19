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
        Goals.Add(new CollectingQuest(this, NPCID, "Kill " + RequiredAmount + " " + NPCID, false, CurrentAmount, RequiredAmount, CoinReward));
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


    public override void StartText()
    {
        //QUIM = FindObjectOfType<HDialogueInterface>();
        //if (QUIM)
        //{
        //    QUIM.dialogueText.text = StartQuestText;
        //}
        Debug.Log("StartText " + QuestName);
    }
    public override void TrackingQuest()
    {
        //QUIM = FindObjectOfType<QuestUIManager>();
        //if (QUIM)
        //{
        //    QUIM.TextDetails.text = TrackingQuestText;
        //    if(Completed)
        //    {
        //        QUIM.TextTally.text = "Completed";
        //    }
        //    else
        //    {
        //        QUIM.TextTally.text = this.CurrentAmount + " / " + RequiredAmount;
        //    }
        //}
        //Debug.Log("Tracking Quest" + QuestName);
    }
    public override void InprogressText()
    {
        //QUIM = FindObjectOfType<HDialogueInterface>();
        //if (QUIM)
        //{
        //    QUIM.dialogueText.text = InprogressQuestText;
        //}
        Debug.Log("In Progress " + QuestName);
    }
    public override void CompletedText()
    {
        //QUIM = FindObjectOfType<HDialogueInterface>();
        //if (QUIM)
        //{
        //    QUIM.dialogueText.text = CompletedQuestText;
        //}
        Debug.Log("Completed Text " + QuestName);
    }
}

