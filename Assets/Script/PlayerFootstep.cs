using System.Collections;
using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    public AudioClip footStepsSFX;

    private PlayerController movement;
    void Start()
    {
        movement = GetComponent<PlayerController>();  
        StartCoroutine(PlayFootsteps());
    }

    IEnumerator PlayFootsteps()
    {
        while(true)
        {
            if (movement.moveInput.magnitude > 0.1f)
            {
               AudioManager.instance.PlaySFX(footStepsSFX); 
            }

            yield return new WaitForSeconds(0.35f);
        }
    }
}
