using UnityEngine;
using TMPro;

public class Finishzone : MonoBehaviour
{
    [Header("UI Panel")]
    public GameObject finishPanel;
    public TextMeshProUGUI congratsText;
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI ratingText;

    private bool triggered = false;

    void Start()
    {
        if (finishPanel != null)
            finishPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        PlayerStats stats = other.GetComponentInParent<PlayerStats>();
        float finalAge = stats != null ? stats.age : 20f;

        ShowFinishScreen(finalAge);
    }

    void ShowFinishScreen(float age)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (finishPanel != null)
            finishPanel.SetActive(true);

        if (congratsText != null)
            congratsText.text = GetCongratsMessage(age);

        if (ageText != null)
            ageText.text = "You arrived at age " + Mathf.FloorToInt(age);

        if (ratingText != null)
            ratingText.text = GetRatingMessage(age);
    }

    string GetCongratsMessage(float age)
    {
        if (age < 30f) return "Untouched by time. Legendary.";
        if (age < 40f) return "You outran the clock.";
        if (age < 50f) return "Battered but victorious.";
        if (age < 60f) return "Time took its toll. You endured.";
        return "Ancient. But still standing.";
    }

    string GetRatingMessage(float age)
    {
        if (age < 30f) return "⭐⭐⭐ Flawless";
        if (age < 40f) return "⭐⭐ Swift";
        if (age < 50f) return "⭐ Survivor";
        if (age < 60f) return "Weathered";
        return "By a thread...";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}