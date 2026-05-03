using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public static UpgradeMenu Instance;

    public GameObject panel;
    public float curveBoostAmount = 0.5f;

    private PlayerStats playerStats;

    void Awake()
{
    Instance = this;
    if (panel != null)
        panel.SetActive(false);
    else
        Debug.LogError("PANEL IS NULL IN AWAKE");
}

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

   public void Show()
{
    panel.SetActive(true);
    panel.transform.SetAsLastSibling();
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}

public void Hide()
{
    panel.SetActive(false);
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = false;
}

    public void ChooseSpeed()      { BoostCurve(playerStats.speedCurve);      Hide(); }
    public void ChooseStamina()    { BoostCurve(playerStats.staminaCurve);    Hide(); }
    public void ChoosePower()      { BoostCurve(playerStats.powerCurve);      Hide(); }
    public void ChooseResilience() { BoostCurve(playerStats.resilienceCurve); Hide(); }

    void BoostCurve(AnimationCurve curve)
    {
        for (int i = 0; i < curve.length; i++)
        {
            Keyframe k = curve[i];
            k.value += curveBoostAmount;
            curve.MoveKey(i, k);
        }
    }
}