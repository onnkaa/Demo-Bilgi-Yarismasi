using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //private Animator animator;

    //public float walkspeed = 5;
    //private float horizontal;
    //private float vertical;
    //private bool isAttacking = false;

    //void Start()
    //{
    //    animator = GetComponent<Animator>();    
    //}


    //void FixedUpdate()
    //{
    //    if (animator)
    //    {
    //        horizontal = Input.GetAxis("Horizontal");
    //        vertical = Input.GetAxis("Vertical");

    //        Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
    //        float speedOut;

    //        if (stickDirection.sqrMagnitude > 1) stickDirection.Normalize();

    //        if (!isAttacking)
    //            speedOut = stickDirection.sqrMagnitude;
    //        else
    //            speedOut = 0;

    //        if (stickDirection != Vector3.zero)


    //            stickDirection = transform.TransformDirection(stickDirection);
    //        GetComponent<Rigidbody>().position += stickDirection * Time.fixedDeltaTime * 5;

    //        animator.SetFloat("Move", speedOut);
    //    }
    //}

    private Animator animator;
    private CharacterController characterController;
    public float Speed = 5.0f;
    public float RotatinSpeed = 240.0f;
    private float Gravity = 20.0f;
    private Vector3 moveDir = Vector3.zero;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();        
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (vertical < 0)
            vertical = 0;

        transform.Rotate(0, horizontal * RotatinSpeed * Time.deltaTime, 0);
        if (characterController.isGrounded)
        {
            bool move = (vertical > 0) || (vertical != 0);

            animator.SetBool("run", move);
            moveDir = Vector3.forward * vertical;
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= Speed;
        }
        moveDir.y -= Gravity * Time.deltaTime;
        characterController.Move(moveDir * Time.deltaTime);
    }
}
