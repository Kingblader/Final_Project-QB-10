using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;

    public void RecieveDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

