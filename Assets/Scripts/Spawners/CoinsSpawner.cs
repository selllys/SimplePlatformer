using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    public int CoinsSpawned => _spawnPoints.Count;

    public void SpawnAll()
    {
        _spawnPoints.ForEach(spawnPoint => Instantiate(_prefab, spawnPoint.transform));
    }

    [ContextMenu("Fill Spawn Points")]
    private void FillSpawnPoints()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>().ToList();
    }
}