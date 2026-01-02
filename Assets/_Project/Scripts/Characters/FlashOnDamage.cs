using UnityEngine;

public class FlashOnDamage : MonoBehaviour
{
    [SerializeField] private float timer = 0.2f;
    private float saveTimer;
    private bool isFlashing = false;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        saveTimer = timer;
    }

    public void FlashRed()
    {
        timer = saveTimer;
        sr.color = Color.red;
        isFlashing = true;
    }

    private void Update()
    {
        if (isFlashing)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                sr.color = Color.white;
                isFlashing = false;
            }
        }
    }
}