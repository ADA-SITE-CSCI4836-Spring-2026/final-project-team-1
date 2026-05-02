using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f) Die();
    }

    void Die()
    {
        // TODO: play death animation before destroying
        Destroy(gameObject);

        // Restore player age on kill
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        if (stats != null) stats.OnKill();
    }
}