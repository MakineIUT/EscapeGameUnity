using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class AjoutPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private bool zqsdJoined = false;
    private bool flechesJoined = false;
    
    // Use a list to track which gamepads are already in the game
    private List<Gamepad> joinedGamepads = new List<Gamepad>();

    void Update()
    {
        if (Keyboard.current == null) return;

        // 1. ZQSD Join (B Key)
        if (!zqsdJoined && Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnPlayer("ZQSD", Keyboard.current, 0);
            zqsdJoined = true;
        }

        // 2. Arrows Join (Space Key)
        if (!flechesJoined && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnPlayer("Fleches", Keyboard.current, 1);
            flechesJoined = true; 
        }

        // 3. MULTI-GAMEPAD JOIN
        foreach (var gamePad in Gamepad.all)
        {
            // Check if 'South' button (A on Xbox, X on PS) is pressed 
            // AND ensure this specific gamepad hasn't already joined
            if (gamePad.buttonSouth.wasPressedThisFrame && !joinedGamepads.Contains(gamePad))
            {
                int spawnIndex = 2 + joinedGamepads.Count; // Start gamepad spawns at index 2
                SpawnPlayer("Gamepad", gamePad, spawnIndex);
                
                joinedGamepads.Add(gamePad);
            }
        }
    }

    private void SpawnPlayer(string scheme, InputDevice device, int spawnIndex)
    {
        // PlayerInput.Instantiate automatically creates a unique InputUser
        // and pairs it with the specific device provided.
        var player = PlayerInput.Instantiate(playerPrefab,
            controlScheme: scheme,
            pairWithDevice: device);
        
        // Position the player
        if (spawnPoints.Length > spawnIndex)
        {
            player.transform.position = spawnPoints[spawnIndex].position;
        }
        else if (spawnPoints.Length > 0)
        {
            // Fallback to first spawn point if list is too short
            player.transform.position = spawnPoints[0].position;
        }

        Debug.Log($"Joined: {scheme} using {device.name}. User ID: {player.user.id}");
    }
}