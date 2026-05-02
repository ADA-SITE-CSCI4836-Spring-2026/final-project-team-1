using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public GameObject coinPrefab;        // drag your coin prefab here
    
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
        // Drop coin at enemy position
        if (coinPrefab != null)
            Instantiate(coinPrefab, transform.position + Vector3.up, Quaternion.identity);

        // Restore player age
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        if (stats != null) stats.OnKill();

        Destroy(gameObject);
    }
}