using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealh2 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthManager healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame

    void Update()
    {
        //Input Key on Player Damage
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(20);
        }
        
        //Game over less than 1 health
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }
    //Damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //Increase health method
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;

        // Ensure current health doesn't exceed max health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        healthBar.SetHealth(currentHealth);
    }

    public void DecraeseHealth(int amount)
    {
        currentHealth -= amount;

        // Ensure current health doesn't exceed max health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        healthBar.SetHealth(currentHealth);
    }
    // Grab Health
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            IncreaseHealth(5);
            Destroy(collision.gameObject);
        }
    }
    //Gameover Button 
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
