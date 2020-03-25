using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public string moveStatus = "idle";
    public bool walkByDefault = true;
    public float gravity = 20.0f;

    protected BaseCharacter chara;
    //private float jumpSpeed;
    //private float walkSpeed;
    //private float turnSpeed;
    protected float moveBackwardsMultiplyer = 0.75f;

    protected float speedMultiplyer = 0.0f;
    protected bool grounded = false;
    protected Vector3 moveDirection = Vector3.zero;
    protected bool jumping = false;
    protected bool isWalking = false;
    protected bool mouseSlideButton = false;

    protected CharacterController controller;
    protected Animator animController;
    // Start is called before the first frame update
    void Start()
    {
        chara = GetComponent<BaseCharacter>();
        controller = GetComponent<CharacterController>();
        animController = GetComponent<Animator>();
    } 
}
