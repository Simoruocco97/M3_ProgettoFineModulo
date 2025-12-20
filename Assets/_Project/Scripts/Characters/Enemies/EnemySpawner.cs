using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnTimer = 10f;
    private float saveTimer;

    private void Awake()
    {
        saveTimer = spawnTimer;
        spawnTimer = 0f;
    }

    private GameObject ChooseEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);        //scelta casuale del tipo di enemy
        GameObject selectedEnemy = enemies[randomIndex];
        return selectedEnemy;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) 
        {
            Instantiate(ChooseEnemy(), transform.position, Quaternion.identity);
            spawnTimer = saveTimer;
        }
    }
}