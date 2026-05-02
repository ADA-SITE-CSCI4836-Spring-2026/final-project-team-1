using UnityEngine;
using TMPro;

public class AgeDisplay : MonoBehaviour
{
    public TextMeshProUGUI ageText;
    private PlayerStats stats;

    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if (stats == null) return;

        int age = Mathf.FloorToInt(stats.age);
        ageText.text = "Age: " + age;

        // Color shifts from white to red as age increases
        float t = (stats.age - 20f) / 50f;
        ageText.color = Color.Lerp(Color.white, Color.red, t);
    }
}