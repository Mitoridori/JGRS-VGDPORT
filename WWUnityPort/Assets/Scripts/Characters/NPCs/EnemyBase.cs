using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : BaseCharacter
{

    private BehaviorExecutor executor;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        executor = GetComponent<BehaviorExecutor>();

        executor.SetBehaviorParam("animationClip", animator);

    }
}
