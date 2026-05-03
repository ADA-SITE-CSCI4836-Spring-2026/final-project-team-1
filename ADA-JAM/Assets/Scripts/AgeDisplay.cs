using UnityEngine;
using TMPro;

public class AgeDisplay : MonoBehaviour
{
    public TextMeshProUGUI ageText;
    private PlayerStats stats;

    void Update()
{
    if (stats == null)
        stats = FindObjectOfType<PlayerStats>();
    if (stats == null) return;

    Debug.Log("AgeDisplay reading: " + stats.age); // temp debug
    ageText.text = "Age: " + Mathf.FloorToInt(stats.age);
    float t = (stats.age - 20f) / 50f;
    ageText.color = Color.Lerp(Color.white, Color.red, t);
}
}