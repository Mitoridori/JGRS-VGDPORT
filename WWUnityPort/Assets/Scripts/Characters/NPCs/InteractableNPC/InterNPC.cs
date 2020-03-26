using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterNPC : BaseCharacter
{

    private BehaviorExecutor executor;
    private Animator animator;
    protected string currentText;
    private UnityEngine.AI.NavMeshAgent agent;
    protected bool CanWalk;
    public GameObject InteractiveTextBox;


    PlayerController player;
    public bool CanMove { get; set; }
    public bool ActiveTextBox { get; set; }

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
        CloseMenuToggle();
    }
    
    public void Interact()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 4)
        {
            OnInteract();
            MenuToggle();
        }
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
                if (animator)
                    SpeedCheck();
                    animator.SetLayerWeight(0, 1);
            }
        }
        else
        {
            CanWalk = false;
            animator.SetBool("CanWalk", false);
        }
    }

    private void SpeedCheck()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 1.5)
        {
            CanWalk = false;
            animator.SetBool("CanWalk", false);
        }
        else
        {
            CanWalk = true;
            animator.SetBool("CanWalk", true);
        }
    }

    public void MenuToggle()
    {
            InteractiveTextBox.SetActive(true);
    }

    public void CloseMenuToggle()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= 4)
        {
            InteractiveTextBox.SetActive(false);
        }
    }

}