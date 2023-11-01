using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerController
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private float speed = 10f;

    private InputAction moveAction;
    private Vector2 inputValue;

    private void Awake()
    {
        moveAction = inputReader.actions["Movement"];
    }

    private void OnEnable()
    {
        moveAction.Enable();
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        inputValue = ctx.ReadValue<Vector2>();
        if (inputValue.sqrMagnitude > 1)
        {
            inputValue.Normalize();
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        inputValue = Vector2.zero;
    }

    private void FixedUpdate()
    {
        // Approximately zero vector means no input
        if (inputValue.sqrMagnitude < 0.0001) { return; }
        var rb = playerRigidBody;

        // Move the rigidbody
        Vector2 moveDirection = new Vector3(inputValue.x, inputValue.y);
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * moveDirection);
    }
}
