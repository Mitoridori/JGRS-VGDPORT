
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



//NAME : Quest
//PURPOSE : the Parent to the different types of quests. 

//[CreateAssetMenu(fileName = "New Quest")]
public class Quests : ScriptableObject
{
    //Items not to be touched. 
    public QuestLogUIManager QUIM;
    public Player player;
    public PlayerInventory PI;

    public List<QuestGoal> Goals = new List<QuestGoal>();
    public bool currentQuest { get; set; }
    public bool Completed { get; set; }
    public bool isActive { get; set; }
    public int CurrentAmount { get; set; }
    public bool NPCKill { get; set; }
    protected GameObject NPCtoKill;
    protected GameObject NPCHandIn;
    protected GameObject NPCStart;

    public bool SecondNPC { get; set; }

    //Changeable in script able list
    public string QuestName;
    public string Prereq1;
    public string Prereq2;
    public string Description;
    public string NPCID;
    public List<Item> QuestItems = new List<Item>();
    public int RequiredAmount;
    public List<Item> RewardItems = new List<Item>();
    public int ExperenceReward = 0;
    public int CoinReward = 0;
    //public variable for item reward needed;

    //Descriptions of text
    [TextArea(3, 10)]
    public string QuestObjectives;
    [TextArea(3, 10)]
    public string StartQuestText;
    [TextArea(3, 10)]
    public string TrackingQuestText;
    [TextArea(3, 10)]
    public string InprogressQuestText;
    [TextArea(3, 10)]
    public string CompletedQuestText;

    [TextArea(3, 10)]
    public string SecondInprogressText;
    public string SecondInprogressButtonText;
    [TextArea(3, 10)]
    public string SecondCompletedText;

    public string RewardsList;

    public bool isPortalSwitch;



    public virtual string Reward()
    {
        string coin;
        if (CoinReward > 0)
        {
            coin = " " + CoinReward;
        }
        else
            coin = "";
        return RewardsList = coin;
    }

    public virtual void Load() { }

    //FUNCTION : Anything Text
    //DESCRIPTION : Allowing the quests to pass text into the UI
    public virtual void StartText()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.NPCBoxTwo.text = StartQuestText;
            QUIM.NPCButtonText.text = "Close";
        }
        Debug.Log("StartText " + QuestName);
    }
    public virtual void TrackingQuest()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.TextDetails.text = TrackingQuestText;
            QUIM.CoinText.text = Reward();
            if (Completed)
            {
                QUIM.TextTally.text = "Completed";
            }
            else
            {
                QUIM.TextTally.text = this.CurrentAmount + " / " + RequiredAmount;
            }
        }
        //Debug.Log("Tracking Quest" + QuestName);
    }
    public virtual void InprogressText()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.NPCBoxTwo.text = InprogressQuestText;
            QUIM.NPCButtonText.text = "Close";
        }
        Debug.Log("In Progress " + QuestName);
    }
    public virtual void CompletedText()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.NPCBoxTwo.text = CompletedQuestText;
            QUIM.NPCButtonText.text = "Close";
        }
        Debug.Log("Completed Text" + QuestName);
    }

    public virtual void SNPCInprogressText()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.NPCBoxTwo.text = SecondInprogressText;
            QUIM.NPCButtonText.text = SecondInprogressButtonText;
        }

    }

    public virtual void SecondNPCCompletedText()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.NPCBoxTwo.text = SecondCompletedText;
            QUIM.NPCButtonText.text = "Close";
        }
    }


    //FUNCTION : GiveReward
    //DESCRIPTION : gives the player the reward for the quest
    public virtual void GiveReward()
    {
        PI = FindObjectOfType<PlayerInventory>();
        for (int i = 0; i < QuestItems.Count; i++)
        {
            for (int j = 0; j < RequiredAmount; j++)
            {
                PI.Remove(QuestItems[i]);
            }
        }
        for (int i = 0; i < RewardItems.Count; i++)
        {
            PI.Add(RewardItems[i]);
        }

        player = FindObjectOfType<Player>();
        if (player)
        {
            //player.AddXP(ExperenceReward);
            player.AddCoins(CoinReward);
        }
        Debug.Log("Quest Reward Given.");
    }

    public virtual void ChangeHasQuests() { }

}
