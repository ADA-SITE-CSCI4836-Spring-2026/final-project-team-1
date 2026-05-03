using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    public Slider hpSlider;
    public Image fillImage;      // drag the Fill child of the slider here

    private PlayerStats stats;

    void Update()
    {
        if (stats == null)
            stats = FindObjectOfType<PlayerStats>();
        if (stats == null) return;

        hpSlider.value = stats.currentHealth;

        // Color shifts green → yellow → red
        float t = 1f - (stats.currentHealth / stats.maxHealth);
        fillImage.color = Color.Lerp(Color.green, Color.red, t);
    }
}