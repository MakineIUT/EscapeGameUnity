using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vitesse = 5f;
    [SerializeField] private float  hauteurSaut= 2f;
    [SerializeField] private float gravite = -9.8f;
    [SerializeField] private int playerIndex = 0;
    

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
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
            Debug.Log("Le perso doit sauter");
            velocity.y = Mathf.Sqrt(hauteurSaut * -2f * gravite);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * vitesse * Time.deltaTime);

        velocity.y += gravite * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
