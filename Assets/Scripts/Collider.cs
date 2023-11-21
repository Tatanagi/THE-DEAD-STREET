using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    // Start is called before the first frame update
    public int takeDamage = 5;
     
     
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealh2 playerHealth = collision.GetComponent<PlayerHealh2>();

            if (playerHealth != null)
            {
                playerHealth.DecraeseHealth(takeDamage);
                Destroy(gameObject);
            }
        }
    }
}
