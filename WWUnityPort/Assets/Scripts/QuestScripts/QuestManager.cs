using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NAME : QuestManager
//PURPOSE :Checks to see what Quests have been done and what quests can be unlocked because of the completed quests. 
public class QuestManager : MonoBehaviour
{
    public Quests TrackingQuest { get; set; }
    public List<string> completedQuestNames;
    private bool isMatch = false;
    private bool checklist;

    public List<Quests> ActiveQuest = new List<Quests>();
    public List<GameObject> QuestNPC = new List<GameObject>();

    private List<GameObject> NPC = new List<GameObject>();



    //FUNCTION : searchCGNList()
    //DESCRIPTION : Searchs the completed Quest Names list.
    //PARAMETERS : 
    //RETURNS : None()
    public void Awake()
    {
        addToCQNList("NULL");
    }

    //Function : SearchCQNList() 
    //DESCRIPTION : Function to check if a string matches the quest name searched for
    //PARAMETERS : String name
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
            Debug.Log(ActiveQuest[i]);
        }

    }
}

