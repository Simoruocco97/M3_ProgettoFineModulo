using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyDmg = 1;
    [SerializeField] private float speed = 2f;

    private LifeController life;
    private EnemiesAnimationHandler anim;
    private Transform playerTransform;
    private Rigidbody2D rb;

    private void Awake()
    {
        life = GetComponent<LifeController>();
        anim = GetComponentInChildren<EnemiesAnimationHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
    }

    private void FixedUpdate()
    {
        if (playerTransform == null || !life.IsAlive()) return;

        Vector2 direction = (playerTransform.position - transform.position).normalized;

        if (rb != null)
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        if (anim != null)
            anim.MovementAnimation(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        LifeController playerLife = collision.gameObject.GetComponent<LifeController>();

        if (playerLife != null)
            playerLife.TakeDamage(enemyDmg);

        if (life != null)
            life.SetHp(0);
    }
}