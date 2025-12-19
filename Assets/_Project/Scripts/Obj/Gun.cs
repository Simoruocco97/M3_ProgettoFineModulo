using UnityEngine;
public class Gun : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float fireRate = 1f;           //più alto il valore, più lenta spara l'arma
    [SerializeField] private GameObject[] bulletPrefabs;    //creo un array per poter sparare tipi di bullet diversi
    private float lastFireTime;

    private void Awake()
    {
        lastFireTime = -fireRate;
    }

    private void Update()
    {
        if (Time.time >= lastFireTime + fireRate)
        {
            Shoot();
            lastFireTime = Time.time;
        }
    }

    private void Shoot()
    {
        Transform target = FindNearestEnemy();
        if (target == null) return;

        int randomIndex = Random.Range(0, bulletPrefabs.Length);        //scelta casuale del tipo di bullet
        GameObject selectedBullet = bulletPrefabs[randomIndex];

        GameObject bulletObj = Instantiate(selectedBullet, transform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetUp(target, damage);
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            return null;

        Transform nearest = enemies[0].transform;
        float nearestDist = (nearest.position - transform.position).sqrMagnitude;

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;

            float dist = (enemy.transform.position - transform.position).sqrMagnitude;
            if (dist < nearestDist)
            {
                nearestDist = dist;
                nearest = enemy.transform;
            }
        }
        return nearest;
    }
}