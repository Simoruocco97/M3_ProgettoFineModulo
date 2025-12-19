using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float bulletLifeTime;
    private Transform target;
    private Rigidbody2D rb;
    private float bornTime;

    public void SetUp(Transform target, int damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        bornTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = ((Vector2)target.position - rb.position).normalized;
        rb.velocity = dir * speed;
    }

    private void Update()
    {
        if (Time.time > bornTime + bulletLifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Bullet collide con {collision.gameObject.name}");
        LifeController life = collision.gameObject.GetComponent<LifeController>();
        if (life != null)
        {
            life.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}