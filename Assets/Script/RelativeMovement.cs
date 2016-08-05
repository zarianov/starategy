﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public float rotSpeed = 12.0f;
    public float moveSpeed = 6.0f;
    private CharacterController _charController;
    public Animation anim;
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    private float _vertSpeed;
    private ControllerColliderHit _contact;

    void Start()
    {
        _vertSpeed = minFall;
        _charController = GetComponent<CharacterController>();
       
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0)
        {

            anim.CrossFade("soldierRun");

            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);
            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
            movement *= Time.deltaTime;
            _charController.Move(movement);
        }
        if (horInput == 0 && vertInput == 0)
        {
            anim.CrossFade("soldierIdleRelaxed");
           
        }
        if (_charController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.CrossFade("soldierCrouchRun");
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }
        }




        bool hitGround = false;
        RaycastHit hit;
        if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check =   (_charController.height + _charController.radius) / 5f;
            hitGround = hit.distance <= check;
        }
        if (hitGround)
        {       if (Input.GetButtonDown("Jump"))
            {
               
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }
            if (_charController.isGrounded)
            {

              if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * moveSpeed;
                }
                else
                {
                    movement += _contact.normal * moveSpeed;
                }
            }
        }

        if (hitGround == false)
        {
            anim.CrossFade("soldierCrouchRun");
        }

        movement.y = _vertSpeed;
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
    }


    } 


