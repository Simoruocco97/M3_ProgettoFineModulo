using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private string verticalSpeedName = "vSpeed";
    [SerializeField] private string horizontalSpeedName = "hSpeed";
    private Vector2 lastDir = Vector2.zero;
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void MovementAnimation(Vector2 dir)
    {
        if (dir != Vector2.zero)
        {
            lastDir = dir;
        }
        animator.SetFloat(horizontalSpeedName, lastDir.x);
        animator.SetFloat(verticalSpeedName, lastDir.y);

        bool isMoving;

        if (dir.x != 0f || dir.y != 0f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("isMoving", isMoving);
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
        Destroy(GetComponentInParent<PlayerController>().gameObject);
    }
}