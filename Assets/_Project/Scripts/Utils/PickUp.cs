using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PlayerInventory inventory;
    private SoundManager soundManager;

    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = FindObjectOfType<SoundManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory = collision.GetComponent<PlayerInventory>();
            inventory.AddCoin(1);
            soundManager.PlayCoinPickup();
            Destroy(gameObject);
        }
    }
}