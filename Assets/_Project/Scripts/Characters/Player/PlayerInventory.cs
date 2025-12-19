using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int coinCounter = 0;

    public void AddCoin(int coin)
    {
        coinCounter += coin;
        Debug.Log($"Moneta raccolta! Monete totali: {coinCounter}");
    }
}
