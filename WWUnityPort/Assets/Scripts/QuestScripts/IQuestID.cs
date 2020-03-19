
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NAME : IQuestID
//PURPOSE : Information that the object needed for the quest gives into the quest system when either kill/collected or such

public interface IQuestID
{
    string ID { get; set; }

    //FUNCTION : Cleared()
    //DESCRIPTION : This function is called in the objects that are apart of quests, so we know if this is a part of the quest or not. 
    //PARAMETERS : None
    //RETURNS : None
    void Cleared();
}


/*  How to apply to items in quest:  
 *  after the class info add: IQuestID  ie: public class Wood : BaseCollectible, IQuestID, 
 *  in the list of variables add the string ID {get; set;}
 *  in the start/awake, declare the ID as the name, ie: ID = "wood"
 *  add the function:
 *  void Cleared()
 *  {
 *   QuestEvents.ItemCleared(this);
 *  }
 *  in the rare case this is an named NPC, that will be a varent in another quest, you need to add a cast to the Game manager and add:
 *  QM.addToCQNList("NameofNPC");
 *  
 *  */
