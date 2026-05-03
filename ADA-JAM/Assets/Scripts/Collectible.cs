using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (UpgradeMenu.Instance != null)
                UpgradeMenu.Instance.Show();
            gameObject.SetActive(false);
        }
    }
}