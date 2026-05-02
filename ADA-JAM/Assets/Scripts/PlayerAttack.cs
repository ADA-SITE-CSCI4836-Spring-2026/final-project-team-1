using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject hourglassPrefab;   // drag your hourglass prefab here
    public Transform firePoint;          // empty GameObject at player's hand
    public Animator animator;

    private PlayerStats stats;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Play punch animation
        animator.SetTrigger("Attack");

        if (hourglassPrefab == null || firePoint == null) return;

        // Fire in camera forward direction
        Camera cam = Camera.main;
        Vector3 dir = cam.transform.forward;

        GameObject proj = Instantiate(hourglassPrefab, firePoint.position, Quaternion.identity);
        HourglassProjectile hp = proj.GetComponent<HourglassProjectile>();
        if (hp != null) hp.Launch(dir);
    }
}