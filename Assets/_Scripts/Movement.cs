using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    private Rigidbody rb;
    private Animator animator;
    private Vector2 moveInput;

    public float moveSpeed;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y)* moveSpeed * Time.deltaTime;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (moveInput != Vector2.zero )
        {
            animator.SetFloat("xinput", moveInput.x);
            animator.SetFloat("yinput", moveInput.y);
        }
    }

}
