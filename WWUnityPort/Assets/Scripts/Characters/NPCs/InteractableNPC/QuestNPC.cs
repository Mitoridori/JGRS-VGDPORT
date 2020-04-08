using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : InterNPC
{
    //UI and Quests.cs to link to
    PortalStageController Portal;

    public Quests Quest { get; set; }
    public bool AssignedQuest { get; set; } //Has quest been assigned
    public bool Helped { get; set; } //quest to hand in
    public List<Quests> QuestList = new List<Quests>(); //List of quests for NPC
    private int i = 0; //quest counter
    public bool HasQuests;

    GameObject questIndicator;
    
    void Awake()
    {
        questIndicator = GetComponentInChildren<ToggleColor>().gameObject;
        Portal = FindObjectOfType<PortalStageController>();
        QM = FindObjectOfType<QuestManager>();

        if (!HasQuests)
            questIndicator.SetActive(false);
        else
            questIndicator.SetActive(true);
    }

    public override void Update()
    {
        Follow();
        CloseMenuToggle();
        LookAt();
        if (HasQuests)
            questIndicator.SetActive(true);
        if (!AssignedQuest && !Helped && questIndicator.activeInHierarchy)
            questIndicator.GetComponent<ToggleColor>().SetIconMaterialAvailable();
    }

    public override void Interact()
    {
        nameText.SetText(CharacterName);
        isActive = !isActive;
        if (!isSecondaryNPC)
        {
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
        else if (isSecondaryNPC)
        {
            if (!Quest.Completed)
            {
                Quest.SNPCInprogressText();
                Cleared();
            }
            else if (Quest.Completed)
            {
                if (Quest.isPortalSwitch)
                    Portal.SwitchPortalStage();

                Quest.ChangeHasQuests();
                Quest.SecondNPCCompletedText();
                Quest.GiveReward();
                QM.addToCQNList(Quest.QuestName);
                Quest.isActive = false;
                QM.RemoveActiveQuest(Quest);
                isSecondaryNPC = false;
                Helped = true;
                AssignedQuest = false;

            }
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
                    if (questIndicator)
                        questIndicator.GetComponent<ToggleColor>().SetIconMaterialTaken();
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
        if (Quest.Completed&& !Quest.SecondNPC)
        {
            if (Quest.isPortalSwitch)
                Portal.SwitchPortalStage();

            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            QM.addToCQNList(Quest.QuestName);
            Quest.CompletedText();
            Quest.isActive = false;
            QM.RemoveActiveQuest(Quest);

        }
        else if (Quest.Completed && Quest.SecondNPC)
        {
            Quest.CompletedText();
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
        if (i >= QuestList.Count)
        {
            NoMoreQuest();
        }
        else
        {
            Helped = false;
            AssignedQuest = false;
            AssignQuest();
            i++;
        }
    }

    //FUNCTION : NoMoreQuest
    //DESCRIPTION : Calls the dialog if no more quests are to be found
    void NoMoreQuest()
    {
        currentText = "Thanks for you Help";
        questIndicator.SetActive(false);
        Debug.Log("No Quest Got");
    }

}
