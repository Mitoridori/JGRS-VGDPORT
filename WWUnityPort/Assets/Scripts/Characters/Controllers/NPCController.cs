using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : BaseController
{

    Animator animator;
    BehaviorExecutor executor;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        executor = GetComponent<BehaviorExecutor>();
    }
}
