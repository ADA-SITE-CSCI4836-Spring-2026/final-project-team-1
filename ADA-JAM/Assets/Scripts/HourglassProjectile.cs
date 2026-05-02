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
        transform.Rotate(0, 180f * Time.deltaTime, 0); // spin for visual flair
    }

    void OnTriggerEnter(Collider other)
{
    Debug.Log("Hourglass hit: " + other.gameObject.name);
    
    EnemyHealth enemy = other.GetComponent<EnemyHealth>();
    if (enemy != null)
    {
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }

    enemy = other.GetComponentInParent<EnemyHealth>();
    if (enemy != null)
    {
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
}