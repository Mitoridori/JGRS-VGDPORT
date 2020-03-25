
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
    //public Player player;

    public List<QuestGoal> Goals = new List<QuestGoal>();
    public bool currentQuest { get; set; }
    public bool Completed { get; set; }
    public bool isActive { get; set; }
    public int CurrentAmount { get; set; }
    public bool NPCKill { get; set; }
    protected GameObject NPCtoKill;
    protected GameObject NPCHandIn;

    public bool SecondNPC { get; set; }

    //Changeable in script able list
    public string QuestName;
    public string Prereq1;
    public string Prereq2;
    public string Description;
    public string NPCID;
    public string TurnInNPCName;

    public int RequiredAmount;
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

    public string SecondInprogressText;
    public string SecondCompletedText;

    public string RewardsList;

    public virtual string Reward()
    {
        string coin;
        //string exp;
        if (CoinReward > 0)
        {
            coin = " " + CoinReward;
        }
        else
            coin = "";
        //if (ExperenceReward > 0)
        //{
        //    exp = "Experence: " + ExperenceReward;
        //}
        //else
        //    exp = "";
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
            QUIM.NPCBoxOne.text = TurnInNPCName;
            QUIM.NPCBoxTwo.text = StartQuestText;
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
        Debug.Log("Tracking Quest" + QuestName);
    }
    public virtual void InprogressText()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.NPCBoxTwo.text = InprogressQuestText;
        }
        Debug.Log("In Progress " + QuestName);
    }
    public virtual void CompletedText()
    {
        QUIM = FindObjectOfType<QuestLogUIManager>();
        if (QUIM)
        {
            QUIM.NPCBoxTwo.text = CompletedQuestText;
        }
        Debug.Log("Completed Text" + QuestName);
    }

    void OnEnable()
    {
        //QUIM = FindObjectOfType<QuestUIManager>();
        //player = FindObjectOfType<Player>();
    }


    //FUNCTION : GiveReward
    //DESCRIPTION : gives the player the reward for the quest
    public virtual void GiveReward()
    {
        //player = FindObjectOfType<Player>();
        //if (player)
        //{
        //    player.AddXP(ExperenceReward);
        //    player.AddCoins(CoinReward);
        //    player.AddStatPoint(AbilityReward);
        //}


        Debug.Log("Quest Reward Given.");
    }



}
