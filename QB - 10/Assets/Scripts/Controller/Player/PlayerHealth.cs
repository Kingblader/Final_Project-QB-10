using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int playerHealth;
    public int healAmount;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            healFromDamage();
            Debug.Log("I'm Healing!");
        }
    }

    public void takeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        if(playerHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void healFromDamage()
    {
        playerHealth = playerHealth + healAmount;

        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
    }
}
