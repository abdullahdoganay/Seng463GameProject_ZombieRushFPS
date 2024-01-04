using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    public void DeductHealth(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0)
        {
            KillPlayer();
            EndGame();
        }
    }


    public void AddHealth(int value)
    {
        currentHealth = currentHealth + value;
        healthBar.SetHealth(currentHealth);
        if (currentHealth >maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }

    private void KillPlayer()
    {
        print("Player dead");
    }
    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        healthBar.SetHealth(currentHealth);
    }

}
