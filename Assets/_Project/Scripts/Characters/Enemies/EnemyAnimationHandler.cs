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

    public void MovementAnimation(Vector2 dir)
    {
        bool isMoving;

        animator.SetFloat(verticalSpeedName, dir.y);
        animator.SetFloat(horizontalSpeedName, dir.x);

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

    //public void PlayDamageAnimation()
    //{
    //    animator.SetBool("isDamaged", true);
    //}

    //public void StopDamageAnimation()
    //{
    //    animator.SetBool("isDamaged", false);
    //}
}
