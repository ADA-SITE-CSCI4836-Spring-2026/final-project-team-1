using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerStats stats = other.GetComponentInParent<PlayerStats>();
        if (stats != null)
            stats.OnDeath();
        else
            CheckpointManager.Instance.RespawnPlayer();
    }
}