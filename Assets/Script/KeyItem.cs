using UnityEngine;

public class KeyItem : MonoBehaviour, IInteractable
{
    [Header("Paramètres de l'objet")]
    public string keyName = "Clé Secrète";

    public void Interact()
    {
        // Pour visualiser les erreurs de bugs sur l'affichage unity 
        Debug.Log("Objet récupéré : " + keyName);
        
        
        // On neutralise l'objet de la scène une fois que le joueur a récup 
        Destroy(gameObject);
    }
}