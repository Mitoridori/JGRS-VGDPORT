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


    public TextMeshProUGUI NPCBoxOne;
    public TextMeshProUGUI NPCBoxTwo;
    public GameObject ToggleButtonA;
    public GameObject ToggleButtonB;
    bool toggle = false;

    QuestNPC QG;

    void Start()
    {
        QG = FindObjectOfType<QuestNPC>();

        NoQuestFound();
    }

    // Update is called once per frame
    void Update()
    {
        if (QG && QG.AssignedQuest)
            QG.Quest.TrackingQuest();
        else
            NoQuestFound();
    }

    void NoQuestFound()
    {
        TextDetails.text = "Quest log is currently empty.";
        TextTally.text = " ";
        NPCBoxOne.text = "Welcome Alison";
        NPCBoxTwo.text = "Thank you for your help.";
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
}
