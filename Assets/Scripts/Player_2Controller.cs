using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_2Controller : MonoBehaviour
{
    // Movement tuning (Inspector)
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    // Input System Action (Inspector)
    [SerializeField] private InputAction moveAction;
    // Current input value
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    // Enable moveAction to make it read input
    moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read 2D Vector from moveAction
        moveInput = moveAction.ReadValue<Vector2>();
        // Go forward/backward local Z
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        // Rotate around local Y
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveInput.x * Math.Abs(moveInput.y));
    }
}
