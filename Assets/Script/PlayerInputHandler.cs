using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public GameObject playerPrefab;
    PlayerController playerController;

    private void Awake()
    {
        if(playerPrefab != null)
        {
            playerController = playerPrefab.GetComponent<PlayerController>();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMove(InputAction.CallbackContext context)
    {
        playerController.OnMove(context);
    }

}
