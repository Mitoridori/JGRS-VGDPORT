using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InterNPC : BaseCharacter, IInteractable
{

    protected BehaviorExecutor executor;
    private Animator animator;
    protected string currentText;
    private NavMeshAgent agent;
    protected bool CanWalk;
    public GameObject InteractiveTextBox;
    protected bool isActive = false;
    public bool isSecondaryNPC;


    protected Player player;

    public bool CanMove { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        executor = GetComponent<BehaviorExecutor>();

        agent = GetComponent<NavMeshAgent>();

        player = FindObjectOfType<Player>();

        if (executor)
            executor.enabled = false;
    }

    public virtual void Update()
    {
        //Follow();
        //MenuToggle(isActive);
    }
    
    public virtual void Interact()
    {

    }

    public void OnInteract()
    {
        if(player)
        if (Vector3.Distance(transform.position, player.transform.position) <= 4)
        {
            Interact();
            if(InteractiveTextBox)
                MenuToggle(isActive);
        }
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

    public void MenuToggle(bool isOpen)
    {
        InteractiveTextBox.SetActive(isOpen);

        if (Vector3.Distance(transform.position, player.transform.position) >= 4 && InteractiveTextBox.activeInHierarchy)
        {
            isActive = !isActive;
        }
    }

    public void CloseMenuToggle()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= 4)
        {
            InteractiveTextBox.SetActive(false);
        }
    }

    public bool ToggleIsActive()
    {
        return isActive = !isActive;
    }
}