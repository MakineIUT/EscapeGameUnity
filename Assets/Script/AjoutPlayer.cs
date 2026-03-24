using UnityEngine;
using UnityEngine.InputSystem;

// 1. Rename your class to avoid conflict with UnityEngine.InputSystem.PlayerInputManager
public class AjoutPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private bool zqsdJoined = false;
    private bool flechesJoined = false;

    void Update()
    {
        // 2. Use Keyboard.current (Capital K)
        if (Keyboard.current == null) return;

        // Check for ZQSD player join (B key)
        if (!zqsdJoined && Keyboard.current.bKey.wasPressedThisFrame)
        {
            // 3. Use PlayerInput.Instantiate to create the player
            var player = PlayerInput.Instantiate(playerPrefab,
                controlScheme: "ZQSD",
                pairWithDevice: Keyboard.current);
            
            if (spawnPoints.Length > 0)
            {
                player.transform.position = spawnPoints[0].position;
            }
            zqsdJoined = true;
        }

        // Check for Arrows player join (Space key)
        if (!flechesJoined && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(playerPrefab,
                controlScheme: "Fleches",
                pairWithDevice: Keyboard.current);
            
            if (spawnPoints.Length > 1)
            {
                player.transform.position = spawnPoints[1].position;
            }
            flechesJoined = true; 
        }

        // Check for Gamepad joins
        foreach (var gamePad in Gamepad.all)
        {
            if (gamePad.buttonSouth.wasPressedThisFrame)
            {
                // Note: You might want a way to prevent the same gamepad joining twice
                PlayerInput.Instantiate(playerPrefab,
                    controlScheme: "Gamepad",
                    pairWithDevice: gamePad);
            }
        }
    }
}