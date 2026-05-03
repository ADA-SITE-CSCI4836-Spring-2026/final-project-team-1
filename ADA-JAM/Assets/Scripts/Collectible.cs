using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool collected = false;

    public void Collect()
    {
        if (collected) return;
        collected = true;
        Debug.Log("Collected via OverlapSphere!");
        if (UpgradeMenu.Instance != null)
            UpgradeMenu.Instance.Show();
        gameObject.SetActive(false);
    }
}