using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private PlayerInput inputReader;
    private InputAction inputAction;

    private Vector2 inputValue;
    private Vector2 movement;
    private float timeCheck = 0f;
    private bool moved = false;

    private void Awake()
    {
        inputAction = inputReader.actions["Movement"];
    }

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.performed += PlayerMove;
        inputAction.canceled += PlayerIdle;
    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.performed -= PlayerMove;
        inputAction.canceled -= PlayerIdle;
    }
    
    private void PlayerMove(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
        transform.position += new Vector3(movement.x, movement.y, 0);
        //movement = ctx.ReadValue<Vector2>();
        Debug.Log(movement);
    }

    private void PlayerIdle(InputAction.CallbackContext ctx)
    {
        movement = Vector2.zero;
    }


    //private void Update()
    //{
        //if (moved)
        //{
        //    timeCheck += Time.deltaTime;
        //}

        //if (timeCheck > 0.2)
        //{
        //    moved = false;
        //}

        //if (movement != Vector2.zero && !moved)
        //{
        //    transform.position += new Vector3(movement.x, movement.y, 0);
        //    moved = true;
        //    timeCheck = 0;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += new Vector3(0, speed, 0);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= new Vector3(0, speed, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position -= new Vector3(speed, 0, 0);
        //}

        //inputValue.x = Input.GetAxis("Horizontal");
        //inputValue.y = Input.GetAxis("Vertical");

        //if (inputValue.x != 0 || inputValue.y != 0)
        //{
        //    transform.Translate(inputValue.x * speed * Time.deltaTime, inputValue.y * speed * Time.deltaTime, 0);
        //}
    //}

    //private void FixedUpdate()
    //{
    //    //transform.Translate(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime, 0);
    //}
}
