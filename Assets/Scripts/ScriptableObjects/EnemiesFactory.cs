using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemiesFactory/Create", order = 51)]
public class EnemiesFactory : ScriptableObject
{
    [SerializeField] private List<Enemy> _prefabs;
    [SerializeField] private LootTable _lootTable;

    private Enemy RamdomPrefab => _prefabs[Random.Range(0, _prefabs.Count)];

    public Enemy GetRandom()
    {
        Enemy enemy = Instantiate<Enemy>(RamdomPrefab);

        enemy.Died += DropItem;

        return enemy;
    }

    private void DropItem(Enemy enemy)
    {
        enemy.Died -= DropItem;

        Collectable item = _lootTable.CreateRandomItem();
        item.transform.position = enemy.transform.position;
    }
}