using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 20; 
    public AudioClip pickupSound; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealh2 playerHealth = collision.GetComponent<PlayerHealh2>();

            if (playerHealth != null)
            {
                playerHealth.IncreaseHealth(healthAmount);

                // Play the pickup sound
                PlayPickupSound();

                // Destroy the game object
                Destroy(gameObject);
            }
        }
    }

    private void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
    }
}