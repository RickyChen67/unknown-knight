using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput inputReader;
    private InputAction inputAction;
    private Vector2 movement;
    [SerializeField] private Animator animator;

    [SerializeField] private float speed = 1f;
    private Vector2 input;
    private bool moving;
    [SerializeField] private LayerMask solidObjectsLayer;

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
    }

    private void PlayerIdle(InputAction.CallbackContext ctx)
    {
        movement = Vector2.zero;
    }


    private void Update()
    {
        if (!moving)
        {
            input.x = movement.x;
            input.y = movement.y;

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (Walkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }

            animator.SetBool("moving", moving);
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        moving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        moving = false;
    }

    private bool Walkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
}
