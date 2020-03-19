using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NAME : QuestEvents
//PURPOSE : Handling the check between the item calling the Cleared function and what's needed in the quest. 
public class QuestEvents : MonoBehaviour
{
    public delegate void QuestItemEventHandler(IQuestID itemID);
    public static event QuestItemEventHandler EndEvent;

    public static void ItemCleared(IQuestID itemID)
    {
        if (EndEvent != null)
            EndEvent(itemID);
    }
}
