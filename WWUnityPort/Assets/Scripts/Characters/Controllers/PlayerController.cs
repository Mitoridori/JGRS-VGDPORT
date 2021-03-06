﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{

    private void Update()
    {
        moveStatus = "idle";
        isWalking = walkByDefault;

        if(animController.GetBool("Gathering") == false)
        {
            if (Input.GetAxis("Run") != 0)
            {
                isWalking = !walkByDefault;
                animController.SetBool("Running", true);
            }


            if (grounded)
            {
                if (Input.GetMouseButton(1))
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                }
                else
                {
                    moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                }

                if (Input.GetButtonDown("Toggle Move"))
                {
                    mouseSlideButton = !mouseSlideButton;
                }

                if (mouseSlideButton && (Input.GetAxis("Vertical") != 0 || Input.GetButton("Jump")) || (Input.GetMouseButton(0) && Input.GetMouseButton(1)))
                {
                    mouseSlideButton = false;
                }
                if ((Input.GetMouseButton(0) && Input.GetMouseButton(1)) || mouseSlideButton)
                {
                    moveDirection.z = 1;
                }
                if (!(Input.GetMouseButton(1) && Input.GetAxis("Horizontal") != 0))
                {
                    moveDirection.x -= Input.GetAxis("Strafing");
                }
                if (((Input.GetMouseButton(1) && Input.GetAxis("Horizontal") != 0) || Input.GetAxis("Strafing") != 0) && Input.GetAxis("Vertical") != 0)
                {
                    moveDirection *= 0.707f;
                }

                if ((Input.GetMouseButton(1) && Input.GetAxis("Horizontal") != 0) || Input.GetAxis("Strafing") != 0 || Input.GetAxis("Vertical") < 0)
                {
                    speedMultiplyer = moveBackwardsMultiplyer;
                }
                else
                {
                    speedMultiplyer = 1;
                }

                moveDirection *= isWalking ? chara.walkSpeed * speedMultiplyer : chara.runSpeed * speedMultiplyer;

                if (Input.GetButton("Jump"))
                {
                    jumping = true;
                    moveDirection.y = chara.jumpSpeed;
                }

                if (moveDirection.z > 0)
                {
                    moveStatus = isWalking ? "walking" : "running";
                    animController.SetFloat("Speed", moveDirection.z);
                }

                if (moveDirection.x < 0)
                {
                    moveStatus = isWalking ? "walkingRight" : "runningRight";
                    animController.SetFloat("Speed", -moveDirection.x);
                }
                if (moveDirection.x > 0)
                {
                    moveStatus = isWalking ? "walkingLeft" : "runningLeft";
                    animController.SetFloat("Speed", moveDirection.x);
                }

                animController.SetFloat("Direction", moveDirection.x);

                moveDirection = transform.TransformDirection(moveDirection);
            }
            if (Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            }
            else
            {
                transform.Rotate(0, Input.GetAxis("Horizontal") * chara.GetTurnRate() * Time.deltaTime, 0);
            }

            moveDirection.y -= gravity * Time.deltaTime;

            grounded = ((controller.Move(moveDirection * Time.deltaTime)) & CollisionFlags.Below) != 0;

            jumping = grounded ? false : jumping;

            if (jumping)
                moveStatus = "jump";

            MouseInteract();
            ResetAnims();
            if (moveDirection.z == 0)
            {
                animController.SetFloat("Speed", moveDirection.z);
            }
        }
        else if (animController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            animController.SetBool("Gathering", false);
        }
        
    }

    private void ResetAnims()
    {
        if (grounded && (animController.GetCurrentAnimatorStateInfo(0).IsName("Jumping") && animController.GetCurrentAnimatorStateInfo(0).normalizedTime > 1))
        {
            animController.SetBool("Jumping", false);
        }
        if (isWalking)
        {
            animController.SetBool("Running", false);
        }
    }

    public bool GetGathering()
    {
        return animController.GetBool("Gathering");
    }

    void MouseInteract()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Collectible")
                    StartCoroutine(GatheringNode(hit, animController.GetCurrentAnimatorStateInfo(0).length / 2));
                else
                {
                    if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
                        hit.collider.gameObject.GetComponent<IInteractable>().OnInteract();
                }
            }

        }
    }

    IEnumerator GatheringNode(RaycastHit hit, float time)
    {
        if ((transform.position - hit.transform.position).magnitude <= 3)
        {
            animController.SetBool("Gathering", true);

            yield return new WaitForSeconds(time);

            if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
                hit.collider.gameObject.GetComponent<IInteractable>().OnInteract();
        }
    }
}
