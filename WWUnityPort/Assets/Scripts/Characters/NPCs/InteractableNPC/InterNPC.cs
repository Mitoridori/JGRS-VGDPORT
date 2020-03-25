using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterNPC : BaseCharacter
{

    private BehaviorExecutor executor;
    private Animator animator;
    protected string currentText;
    private UnityEngine.AI.NavMeshAgent agent;

    PlayerController player;
    public bool CanMove { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        executor = GetComponent<BehaviorExecutor>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        player = FindObjectOfType<PlayerController>();
         
    }

    private void Update()
    {
        Follow();
    }

    public virtual void OnInteract()
    {
        Debug.Log("NPC interacted");
    }

    public virtual string GetCurrentText()
    {
        return currentText;
    }

    public virtual void Follow()
    {
        if (CanMove)
        {
            if ((player.transform.position - transform.position).magnitude <= 5)
            {
                agent.SetDestination(player.transform.position + new Vector3(0, 0, 1));
            }
        }
    }

}