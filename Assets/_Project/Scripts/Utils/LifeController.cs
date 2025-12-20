using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int hp = 100;
    private FlashOnDamage playerDamage;
    private bool isDead = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerDamage = GetComponent<FlashOnDamage>();
        maxHp = Mathf.Min(maxHp, 999);
        hp = Mathf.Clamp(hp, 0, maxHp);
    }

    public int GetHp()
    {
        return hp;
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    public void SetHp(int value)
    {
        if (isDead) return;

        hp = Mathf.Clamp(value, 0, maxHp);

        if (hp <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        SetHp(hp - damage);
        Debug.Log($"{gameObject.name} ha subito {damage} danni. Vita: {hp}");

        if (playerDamage != null) playerDamage.FlashRed();
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log($"{gameObject.name} è morto");

        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }

        EnemyDrop drop = GetComponent<EnemyDrop>();
        if (drop != null)
            drop.TryDrop();

        Collider2D col = GetComponent<Collider2D>();    //serve per non far slidare via l'enemy al contatto con il player
        if (col != null)
            col.isTrigger = true;

        Destroy(gameObject, 1f);
    }
}
