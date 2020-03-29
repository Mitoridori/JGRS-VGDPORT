using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : InterNPC
{
    //UI and Quests.cs to link to
    QuestManager QM;
    public Quests Quest { get; set; }
    public bool AssignedQuest { get; set; } //Has quest been assigned
    public bool Helped { get; set; } //quest to hand in
    public List<Quests> QuestList = new List<Quests>(); //List of quests for NPC
    private int i = 0; //quest counter

    
    void Awake()
    {
        QM = FindObjectOfType<QuestManager>();
        
    }

    public override void Update()
    {
        Follow();
    }

    public override void Interact()
    {
        isActive = !isActive;
        if (!AssignedQuest && !Helped)
        {
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            NextQuest();
        }
    }

    //FUNCTION : AssignedQuest
    //DESCRIPTION : Assigns the quest to the player if needed
    void AssignQuest()
    {


        //checking to see if valid 

        for (int i = 0; i < QuestList.Count; i++)
        {
            if (!QM.searchCQNList(QuestList[i].QuestName))
            {
                if (QM.searchCQNList(QuestList[i].Prereq1) && QM.searchCQNList(QuestList[i].Prereq2))
                {
                    Quest = QuestList[i];

                    AssignedQuest = true;
                    Quest.Load();
                    Quest.StartText();
                    Quest.isActive = true;
                    QM.AddActiveQuests(Quest);
                    return;
                }
            }
        }
        NoMoreQuest();
    }

    //FUNCTION : CheckQuest
    //DESCRIPTION : Checking to see if quest is done or not and assigning the correct dialoge/action
    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            QM.addToCQNList(Quest.QuestName);
            Quest.CompletedText();
            Quest.isActive = false;
            QM.RemoveActiveQuest(Quest);

        }
        else
        {
            Quest.InprogressText();
        }
    }

    //FUNCTION : NextQuest
    //DESCRIPTION : Calls the next quest in the line when the player revisits the questGiver
    void NextQuest()
    {
        i++;
        if (i >= QuestList.Count)
        {
            NoMoreQuest();
        }
        else
        {
            Helped = false;
            AssignedQuest = false;
            AssignQuest();

        }
    }

    //FUNCTION : NoMoreQuest
    //DESCRIPTION : Calls the dialog if no more quests are to be found
    void NoMoreQuest()
    {
        currentText = "Thanks for you Help";
        Debug.Log("No Quest Got");
    }

}
