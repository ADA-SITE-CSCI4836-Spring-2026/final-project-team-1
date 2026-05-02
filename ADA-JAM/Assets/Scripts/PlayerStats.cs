using StarterAssets;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Age")]
    public float age = 20f;
    public float maxAge = 70f;

    [Header("Stat Curves")]
    public AnimationCurve speedCurve;
    public AnimationCurve staminaCurve;
    public AnimationCurve powerCurve;
    public AnimationCurve resilienceCurve;

    [Header("Age Events")]
    public float hitAgeCost = 3f;
    public float killAgeRestore = 2f;

    private ThirdPersonController movement;

    void Start()
    {
        movement = GetComponent<ThirdPersonController>();
        SetupDefaultCurves();
    }

    void Update()
    {
        // Passive aging
        age += 0.05f * Time.deltaTime;

        if (age >= maxAge) GameOver();

        ApplyStats();
    }

    void ApplyStats()
    {
        if (movement != null)
            movement.MoveSpeed = speedCurve.Evaluate(age);
    }

    public void TakeHit()
    {
        float resilience = resilienceCurve.Evaluate(age) / 100f;
        age += hitAgeCost * (1f - resilience);
        age = Mathf.Clamp(age, 20f, maxAge);

        if (age >= maxAge) GameOver();
    }

    public void OnKill()
    {
        age -= killAgeRestore;
        age = Mathf.Clamp(age, 20f, maxAge);
    }

    void GameOver()
    {
        Debug.Log("GAME OVER - age reached 70");
        // TODO: load game over screen
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    void SetupDefaultCurves()
    {
        // Speed: fast when young, slow when old
        speedCurve = new AnimationCurve(
            new Keyframe(20, 4f),
            new Keyframe(35, 4f),
            new Keyframe(70, 1.5f)
        );

        // Stamina: degrades after 40
        staminaCurve = new AnimationCurve(
            new Keyframe(20, 1f),
            new Keyframe(40, 1f),
            new Keyframe(70, 0.3f)
        );

        // Power: grows with age
        powerCurve = new AnimationCurve(
            new Keyframe(20, 1f),
            new Keyframe(70, 3f)
        );

        // Resilience: grows with age
        resilienceCurve = new AnimationCurve(
            new Keyframe(20, 10f),
            new Keyframe(70, 60f)
        );
    }
}