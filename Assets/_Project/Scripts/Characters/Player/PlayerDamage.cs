using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void FlashRed()
    {
        sr.color = Color.red;      
        sr.color = Color.white;
    }
}
