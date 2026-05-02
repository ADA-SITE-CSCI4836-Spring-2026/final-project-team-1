using UnityEngine;

public class FinishFix : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER WORKED with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER DETECTED → FINISH");

            Time.timeScale = 0f;
        }
    }
}