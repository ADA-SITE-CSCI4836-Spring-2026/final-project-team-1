using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointIndex; // 1, 2, or 3

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CheckpointManager.Instance.SetCheckpoint(transform.position);

        // Visual feedback — optional, disable renderer to show it's been hit
        GetComponent<Renderer>()?.material.SetColor("_Color", Color.green);
    }
}