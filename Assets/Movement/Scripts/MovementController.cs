using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour 
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float speed;

    private Animator animator;
    private Vector3 convertedInput;

    public void Awake()
    {
        animator = characterController.GetComponent<Animator>();
    }

    public void OnMovement(InputAction.CallbackContext ctx) 
    {
        var input = ctx.ReadValue<Vector2>();
        convertedInput = new Vector3(input.x, 0, input.y);
    }

    private void Update()
    {
        animator.SetFloat("speed", speed * convertedInput.magnitude);
        var resultVector = Time.deltaTime * speed * convertedInput;
        characterController.Move(resultVector);
    }
}
