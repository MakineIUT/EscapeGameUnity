using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        // var playerControllers = FindObjectsOfType<PlayerController>();
        var index = playerInput.playerIndex;
        // playerController = playerControllers.FirstOrDefault(m => m.GetPlayerIndex() == index);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
