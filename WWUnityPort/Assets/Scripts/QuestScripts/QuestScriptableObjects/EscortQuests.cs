using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Escort")]
//NAME : EscortQuests
//PURPOSE : Set up for the escort quests. 
public class EscortQuests : Quests
{
    public override void Load()
    {
        CurrentAmount = 0;
        Completed = false;
        Goals.Add(new EscortQuest(this, NPCID, "Kill " + RequiredAmount + " " + NPCID, false, CurrentAmount, RequiredAmount, CoinReward));
        Goals.ForEach(g => g.Init());
    }


    public override void StartText()
    {
        //QUIM = FindObjectOfType<QuestUIManager>();
        //if (QUIM)
        //{
        //    QUIM.NPCBoxTwo.text = StartQuestText;
        //}
        Debug.Log("StartText " + QuestName);
    }
    public override void TrackingQuest()
    {
        //QUIM = FindObjectOfType<QuestUIManager>();
        //if (QUIM)
        //{
        //    QUIM.TextDetails.text = TrackingQuestText;
        //    if (Completed)
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
        //QUIM = FindObjectOfType<QuestUIManager>();
        //if (QUIM)
        //{
        //    QUIM.NPCBoxTwo.text = InprogressQuestText;
        //}
        Debug.Log("In Progress " + QuestName);
    }
    public override void CompletedText()
    {
        //QUIM = FindObjectOfType<QuestUIManager>();
        //if (QUIM)
        //{
        //    QUIM.NPCBoxTwo.text = CompletedQuestText;
        //}
        Debug.Log("Completed Text" + QuestName);
    }
}
