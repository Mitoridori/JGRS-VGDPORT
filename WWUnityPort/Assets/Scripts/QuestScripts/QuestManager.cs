using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NAME : QuestManager
//PURPOSE :Checks to see what Quests have been done and what quests can be unlocked because of the completed quests. 
public class QuestManager : MonoBehaviour, IQuestID
{
    public Quests TrackingQuest { get; set; }
    public List<string> completedQuestNames;
    private bool isMatch = false;
    private bool checklist;
    public List<Quests> ActiveQuest = new List<Quests>();
    
    
    public string ID { get; set; }
    PlayerInventory PI;
    Item item;
    public Quests quest { get; set; }



    //FUNCTION : searchCGNList()
    //DESCRIPTION : Searchs the completed Quest Names list.
    public void Awake()
    {
        addToCQNList("NULL");
        PI = FindObjectOfType<PlayerInventory>();
    }

    //Function : SearchCQNList() 
    //DESCRIPTION : Function to check if a string matches the quest name searched for
    //RETURNS : isMatch
    public bool searchCQNList(string name)
    {
        for (int i = 0; i < completedQuestNames.Count; i++)
        {
            if (name == completedQuestNames[i])
            {
                isMatch = true;
                break;
            }
            else
            {
                isMatch = false;
            }
        }
        return isMatch;
    }
    //FUNCTION : addCGNList()
    //DESCRIPTION : Adds to the completed Quest Names list.
    //PARAMETERS : 
    //RETURNS : None()
    public void addToCQNList(string addName)
    {
        completedQuestNames.Add(addName);
        Debug.Log("Quest name: " + addName);
    }

    public void AddActiveQuests(Quests quest)
    {
        ActiveQuest.Add(quest);
    }

    public void RemoveActiveQuest(Quests quest)
    {
        for (int j = 0; j < ActiveQuest.Count; j++)
        {
            if (ActiveQuest[j] == quest)
            {
                checklist = true;
                break;
            }
            else
                checklist = false;
        }

        if (checklist == true)
            ActiveQuest.Remove(quest);
    }

    public void listActiveQuest()
    {
        for (int i = 0; i < ActiveQuest.Count; i++)
        {
            quest = ActiveQuest[i];
            Debug.Log(ActiveQuest[i]);
        }

    }




    public void CheckItems()
    {
        listActiveQuest();
        for (int i = 0; i < PI.items.Count; i++)
        {
            item = PI.items[i];
            if (item.ItemID == quest.NPCID)
            {
                ID = item.ItemID;
                Cleared();
            }
        }
    }










    public void Cleared()
    {
        QuestEvents.ItemCleared(this);
    }

}

