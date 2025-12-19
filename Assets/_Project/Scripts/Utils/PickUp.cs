using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PlayerInventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory = collision.GetComponent<PlayerInventory>();
            inventory.AddCoin(1);
            Destroy(gameObject);
        }
    }
}