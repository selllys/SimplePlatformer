using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemiesFactory _enemiesFactory;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPoint = transform.position;

        Enemy enemy = _enemiesFactory.GetRandom();
        enemy.transform.position = spawnPoint;
    }
}