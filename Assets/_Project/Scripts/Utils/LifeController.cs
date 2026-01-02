using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private float hp = 100;
    private FlashOnDamage playerDamage;
    private SoundManager soundManager;
    private bool isDead = false;

    private void Awake()
    {
        if (soundManager == null) { soundManager = FindObjectOfType<SoundManager>(); }
        animator = GetComponentInChildren<Animator>();
        playerDamage = GetComponent<FlashOnDamage>();
        maxHp = Mathf.Min(maxHp, 999);
        hp = Mathf.Clamp(hp, 0, maxHp);
    }

    public float GetMaxHp() => maxHp;

    public float GetHp()
    {
        return hp;
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    public void SetHp(float value)
    {
        if (isDead) return;

        hp = Mathf.Clamp(value, 0, maxHp);

        if (hp <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        SetHp(hp - damage);
        Debug.Log($"{gameObject.name} ha subito {damage} danni. Vita: {hp}");

        if (gameObject.CompareTag("Enemy"))
        {
            soundManager.PlayEnemyDamageSound();
        }

        if (gameObject.CompareTag("Player"))
        {
            soundManager.PlayPlayerDamageSound();
        }

        if (playerDamage != null) playerDamage.FlashRed();
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log($"{gameObject.name} è morto");

        Collider2D col = GetComponent<Collider2D>();    //serve per non far slidare via l'enemy al contatto con il player
        if (col != null)
            col.isTrigger = true;

        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }

        if (gameObject.CompareTag("Enemy"))
        {
            EnemyDrop drop = GetComponent<EnemyDrop>();
            if (drop != null)
            {
                drop.TryDrop();
            }
            Destroy(gameObject, 1f);
        }
        else if (gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 1f);
            soundManager.StopBackgroundMusic();
            soundManager.PlayGameOverSound();
        }
    }
}
