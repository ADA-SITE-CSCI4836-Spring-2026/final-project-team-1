using StarterAssets;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Age")]
    public float age = 20f;
    public float maxAge = 70f;

    [Header("Death Penalty")]
    private int deathCount = 0;
    private float baseDeathPenalty = 2f;
    private float maxDeathPenalty = 5f;

    [Header("Stat Curves")]
    public AnimationCurve speedCurve;
    public AnimationCurve staminaCurve;
    public AnimationCurve powerCurve;
    public AnimationCurve resilienceCurve;

    [Header("Health")]
public float maxHealth = 100f;
public float currentHealth = 100f;

    [Header("Age Rates")]
    public float passiveAgingRate = 0.5f;  // age per 10 seconds
    public float killAgeRestore = 2f;

    private ThirdPersonController movement;

    void Start()
    {
        movement = GetComponent<ThirdPersonController>();
        SetupDefaultCurves();
    }

    void Update()
{
    age += passiveAgingRate * Time.deltaTime * 0.1f;
    if (age >= maxAge) GameOver();
    ApplyStats();
    
    // Check for collectibles every frame - bypasses OnTriggerEnter WebGL bug
    Collider[] hits = Physics.OverlapSphere(transform.position, 1.5f);
    foreach (Collider hit in hits)
    {
        Collectible col = hit.GetComponent<Collectible>();
        if (col != null)
        {
            col.Collect();
        }
    }
}

    void ApplyStats()
    {
        if (movement != null)
            movement.MoveSpeed = speedCurve.Evaluate(age);
    }

    // No longer called by skeletons for age damage
    // Kept for compatibility but does nothing
    public void TakeHit()
{
    float damage = 10f; // per skeleton hit
    currentHealth -= damage;
    Debug.Log("Player hit! HP: " + currentHealth);

    if (currentHealth <= 0f)
    {
        currentHealth = maxHealth; // reset HP on death
        OnDeath();
    }
}

    public void OnKill()
    {
        age -= killAgeRestore;
        age = Mathf.Clamp(age, 20f, maxAge);
    }

    public void OnDeath()
{
    deathCount++;
    float penalty = Mathf.Min(baseDeathPenalty + (deathCount - 1), maxDeathPenalty);
    age += penalty;
    age = Mathf.Clamp(age, 20f, maxAge);
    currentHealth = maxHealth; // only health resets, NOT age

    Debug.Log("Death #" + deathCount + " | Age penalty: +" + penalty + " | New age: " + age);

    CheckpointManager.Instance.RespawnPlayer();
}

    void GameOver()
{
    Debug.Log("Age reached 70 - Game Over");
    UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
    );
}

    void SetupDefaultCurves()
    {
        speedCurve = new AnimationCurve(
            new Keyframe(20, 4f),
            new Keyframe(35, 4f),
            new Keyframe(70, 1.5f)
        );

        staminaCurve = new AnimationCurve(
            new Keyframe(20, 1f),
            new Keyframe(40, 1f),
            new Keyframe(70, 0.3f)
        );

        powerCurve = new AnimationCurve(
            new Keyframe(20, 1f),
            new Keyframe(70, 3f)
        );

        resilienceCurve = new AnimationCurve(
            new Keyframe(20, 10f),
            new Keyframe(70, 60f)
        );
    }

    
}