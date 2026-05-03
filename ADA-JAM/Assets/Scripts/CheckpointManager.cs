using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private Vector3 currentCheckpoint;
    private bool hasCheckpoint = false;

    void Awake()
    {
        Instance = this;
    }

    public void SetCheckpoint(Vector3 position)
    {
        currentCheckpoint = position;
        hasCheckpoint = true;
        Debug.Log("Checkpoint set at: " + position);
    }

    public void RespawnPlayer()
{
    PlayerStats stats = FindObjectOfType<PlayerStats>();
    if (stats == null) return;

    // Save age before teleport
    float savedAge = stats.age;

    CharacterController cc = stats.GetComponent<CharacterController>();
    if (cc) cc.enabled = false;

    if (hasCheckpoint)
        stats.transform.position = currentCheckpoint + Vector3.up;

    if (cc) cc.enabled = true;

    // Restore age after teleport
    stats.age = savedAge;

    Debug.Log("Respawned. Age preserved: " + savedAge);
}
}