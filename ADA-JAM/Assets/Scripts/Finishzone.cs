using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishZone : MonoBehaviour
{
    [Header("UI")]
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
        float finalAge = stats != null ? stats.age : 0f;

        ShowFinishScreen(finalAge);
    }

    void ShowFinishScreen(float age)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        finishPanel.SetActive(true);

        congratsText.text = "You made it.";

        ageText.text = "You arrived at age " + Mathf.FloorToInt(age);

        // Rating based on age
        if (age < 30f)
            ratingText.text = "Flawless. Time barely touched you.";
        else if (age < 40f)
            ratingText.text = "Swift. You outran the clock.";
        else if (age < 50f)
            ratingText.text = "Weathered but standing.";
        else if (age < 60f)
            ratingText.text = "Time took its toll. You endured.";
        else
            ratingText.text = "By a thread. Ancient but alive.";
    }
}