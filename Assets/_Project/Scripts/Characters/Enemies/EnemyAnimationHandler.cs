using UnityEngine;

public class EnemiesAnimationHandler : MonoBehaviour
{
    [SerializeField] private string verticalSpeedName = "vSpeed";
    [SerializeField] private string horizontalSpeedName = "hSpeed";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MovementAnimation(Vector2 speed)
    {
        animator.SetFloat(verticalSpeedName, speed.y);
        animator.SetFloat(horizontalSpeedName, speed.x);
    }

    public void PlayDamageAnimation()
    {
        animator.SetBool("isDamaged", true);
    }

    public void StopDamageAnimation()
    {
        animator.SetBool("isDamaged", false);
    }

    public void DeathAnimation()
    {
        animator.SetBool("isDead", true);
    }

    public void DeathAnimationEnd()
    {
        Destroy(gameObject);
    }
}
