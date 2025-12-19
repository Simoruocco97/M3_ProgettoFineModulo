using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private LifeController life;
    private Rigidbody2D rb;
    private PlayerAnimationHandler animator;
    private Vector2 dir;

    private float horizontal;
    private float vertical;
    
    private Vector2 Direction
    {
        get { return new Vector2(horizontal, vertical); }
    }

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        life = GetComponent<LifeController>();
        animator = GetComponentInChildren<PlayerAnimationHandler>();
    }

    private void Update()
    {
        if (life != null && !life.IsAlive())
        {
            horizontal = 0f;
            vertical = 0f;
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        dir = Direction.normalized;
        animator.MovementAnimation(dir);
    }

    private void FixedUpdate()
    {
        if (life != null && !life.IsAlive())
        {
            return;
        }
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }
}
