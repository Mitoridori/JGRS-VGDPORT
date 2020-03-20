using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    private BaseCharacter chara;
    private float jumpSpeed;
    private float walkSpeed;
    private float turnSpeed;
    private float moveBackwardsMultiplier;

    private float speedMultiplier = 0.0f;
    private bool grounded = false;
    private Vector3 moveDirection = Vector3.zero;
    private bool jumping = false;

    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        chara = GetComponent<BaseCharacter>();
        turnSpeed = chara.GetTurnRate();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
