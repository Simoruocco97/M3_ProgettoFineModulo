using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private int dropChance = 10;        // probabilità di drop

    private void Awake()
    {
        if (coin == null) { Debug.LogWarning($"Nessun gameobject assegnato al drop di {gameObject.name}"); }
    }

    private bool HasDropped()
    {
        return Random.Range(0, 100) < dropChance;
    }
   
    public void TryDrop()
    {
        if (HasDropped())
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }
}
