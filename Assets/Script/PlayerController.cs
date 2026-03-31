using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 720f; // Degrees per second
    [SerializeField] private float vitesse = 5f;
    [SerializeField] private float  hauteurSaut= 1f;
    [SerializeField] private float gravite = -9.8f;

    

    private Animator animator;
    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        GetComponent<PlayerInput>();
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} -Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            animator.SetTrigger("Jump"); 
            velocity.y = Mathf.Sqrt(hauteurSaut * -2f * gravite);
        }
    }
    // Update is called once per frame
    void Update()
{
    // 1. Calculate movement direction relative to the world
    Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
    controller.Move(move * vitesse * Time.deltaTime);

    // 2. SMOOTH ROTATION LOGIC
    if (moveInput.sqrMagnitude > 0.01f) // Only rotate if moving
    {
        // Calculate the direction we want to look at
        Quaternion targetRotation = Quaternion.LookRotation(move);

        // Smoothly rotate the player toward that target
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, 
            targetRotation, 
            rotationSpeed * Time.deltaTime
        );
    }

    // 3. ANIMATION LOGIC
    if (animator != null)
    {
        animator.SetBool("IsRunning", moveInput.magnitude > 0.1f);
    }

    // 4. GRAVITY LOGIC
    velocity.y += gravite * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);
}
}
