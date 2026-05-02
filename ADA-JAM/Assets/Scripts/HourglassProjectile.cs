using UnityEngine;

public class HourglassProjectile : MonoBehaviour
{
    public float speed = 15f;
    public float damage = 25f;
    public float lifetime = 3f;

    private Vector3 direction;

    public void Launch(Vector3 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.Rotate(0, 180f * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.gameObject.name + " | tag: " + other.tag);

        // Skip the player itself
        if (other.CompareTag("Player")) return;

        // Check on hit object and all parents
        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            Debug.Log("Dealing damage to: " + enemy.gameObject.name);
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        Debug.Log("No EnemyHealth found on: " + other.gameObject.name);
    }
}