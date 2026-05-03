using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class SkeletonAI : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float attackRange = 1.5f;
    public float attackDamage = 3f;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private float attackTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (player == null)
            player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
{
    if (player == null) return;

    float dist = Vector3.Distance(transform.position, player.position);
    attackTimer -= Time.deltaTime;

    if (dist <= attackRange)
    {
        agent.isStopped = true;
        animator.SetBool("isWalking", false);
        animator.ResetTrigger("isAttacking"); // clear any queued trigger

        if (attackTimer <= 0f)
        {
            attackTimer = attackCooldown;
            animator.SetTrigger("isAttacking");
            Attack();
        }
    }
    else if (dist <= chaseRange)
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
        animator.SetBool("isWalking", true);
        animator.ResetTrigger("isAttacking"); // prevent stab while chasing
    }
    else
    {
        agent.isStopped = true;
        animator.SetBool("isWalking", false);
        animator.ResetTrigger("isAttacking"); // prevent stab while idle
    }
}

    void Attack()
{
    PlayerStats stats = player.GetComponent<PlayerStats>();
    if (stats != null) stats.TakeHit();
}
}