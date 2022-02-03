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
    [SerializeField]
    private float turnTime;
    [SerializeField]
    private Transform followingCamera;

    private Animator animator;
    private Transform charTransform;


    private bool isMoving = false; 
    private float rotationVelocity;
    private Vector3 convertedInput;

    public void Awake()
    {
        animator = characterController.GetComponent<Animator>();
        charTransform = characterController.transform;
    }

    public void OnMovement(InputAction.CallbackContext ctx) 
    {
        var input = ctx.ReadValue<Vector2>();
        convertedInput = new Vector3(input.x, 0, input.y).normalized;
        isMoving = convertedInput.magnitude > 0.1f;

        animator.SetFloat("speed", speed * convertedInput.magnitude);
    }
    private void Update()
    {
        if (isMoving)
        {
            float targetAngle = Mathf.Atan2(convertedInput.x, convertedInput.z) * Mathf.Rad2Deg + followingCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(charTransform.eulerAngles.y, targetAngle, ref rotationVelocity, turnTime);
            charTransform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            Vector3 moveDirection = Quaternion.Euler(new Vector3(0, targetAngle, 0)) * Vector3.forward;

            characterController.Move(Time.deltaTime * speed * moveDirection);
        }
    }
}
