using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Configuration")]
    public float interactionDistance = 3f;

    void Update()
    {
        // on lance un rayon invisible droit devant la caméra du joueur concerné à l'approche d'un objet
        //pour le viser 
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Ligne verte de debug visible dans l'éditeur/affichage
        Debug.DrawRay(transform.position, transform.forward * interactionDistance, Color.green);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                // vérifie si le joueur selectionné (celui qui prend l'objet) appuie sur SA touche assignée
                // comme c'est un mode multijoueur (flèches, touches et manette), au lieu de mettre touchkeyboard E par ex
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
    }
}