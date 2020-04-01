using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMouse : MonoBehaviour
{
    public Texture2D iconArrow;
    public Vector2 arrowRegPoint;
    public Texture2D iconGather;
    public Vector2 gatheringRegPoint;
    public Texture2D iconTalk;
    public Vector2 talkRegPoint;
    public Texture2D iconInteract;
    public Vector2 interactRegPoint;

    //QuestGiver
    public Texture2D iconQuestionMark;
    public Vector2 QuestionRegPoint;
    public Texture2D iconExclamation;
    public Vector2 ExclamationRegPoint;

    //other stuff

    private Vector2 mouseReg;
    private Vector2 mouseCoord;
    private Texture mouseTex;

    //Cursor Look
    private void OnDisable()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        Cursor.visible = false;
    }
    private void OnGUI()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            switch (hit.collider.tag)
            {
                case "Collectible":
                    mouseTex = iconGather;
                    mouseReg = gatheringRegPoint;
                    break;

                case "NPCTalk":
                    mouseTex = iconTalk;
                    mouseReg = talkRegPoint;
                    break;

                case "QuestNPC":
                    mouseTex = iconQuestionMark;
                    mouseReg = QuestionRegPoint;
                    break;

                default:
                    mouseTex = iconArrow;
                    mouseReg = arrowRegPoint;
                    break;

            }
        }
        else
        {
            mouseTex = iconArrow;
            mouseReg = arrowRegPoint;
        }

        mouseCoord = Input.mousePosition;
        GUI.DrawTexture(new Rect(mouseCoord.x - mouseReg.x, Screen.height - mouseCoord.y - mouseReg.y, mouseTex.width, mouseTex.height), mouseTex, ScaleMode.StretchToFill, true, 10.0f);

    }


}

