using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterNPC : BaseCharacter
{

    private BehaviorExecutor executor;
    private Animator animator;
    protected string currentText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        executor = GetComponent<BehaviorExecutor>();
    }

    public virtual void OnInteract()
    {
        Debug.Log("NPC interacted");
    }

    public virtual string GetCurrentText()
    {
        return currentText;
    }


}