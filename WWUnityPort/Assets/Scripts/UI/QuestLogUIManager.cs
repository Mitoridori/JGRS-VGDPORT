using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLogUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI TextDetails;
    public TextMeshProUGUI TextTally;
    public TextMeshProUGUI CoinText;
    public GameObject ToggleButtonA;
    public GameObject ToggleButtonB;

    public TextMeshProUGUI NPCBoxTwo;
    public GameObject InteractiveQuitButton;
    public GameObject InteractiveBox;

    bool toggle = false;

    public List<GameObject> QuestList = new List<GameObject>();
    public List<QuestNPC> QuestNPC = new List<QuestNPC>();

    QuestNPC QG;

    void Start()
    {
        //QG = FindObjectOfType<QuestNPC>();

        NoQuestFound();

        //find all quest givers
        QuestList.AddRange(GameObject.FindGameObjectsWithTag("QuestNPC"));
        for (int i = 0; i < QuestList.Count; i++)
        {
            if (QuestList[i].GetComponent<QuestNPC>())
            {
                QuestNPC.Add(QuestList[i].GetComponent<QuestNPC>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < QuestNPC.Count; i++)
        {
            QG = QuestNPC[i];

            if(QG && QG.HasQuests)
            {
                if(QG.AssignedQuest)
                QG.Quest.TrackingQuest();

                break;
            }
            else 
                NoQuestFound();
        }      
    }

    void NoQuestFound()
    {
        TextDetails.text = "Quest log is currently empty.";
        TextTally.text = " ";
        //NPCBoxOne.text = "Welcome Alison";
        //NPCBoxTwo.text = " ";
    }

    public void PlayerLogOpen()
    {
        if (!toggle)
        {
            ToggleButtonA.SetActive(true);
            ToggleButtonB.SetActive(true);
            toggle = true;
        }
        else if (toggle)
        {
            ToggleButtonA.SetActive(false);
            ToggleButtonB.SetActive(false);
            toggle = false;
        }
    }

    public void QuitInteractiveBox()
    {
        //InteractiveBox.SetActive(false);
        //InteractiveBox.SetActive(QG.ToggleIsActive());
        //QG.MenuToggle(QG.ToggleIsActive());
    }

}
