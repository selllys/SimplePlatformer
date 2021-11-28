using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LootTable/Create", order = 51)]
public class LootTable : ScriptableObject
{
    [SerializeField] private List<Collectable> _prefabs;

    private Collectable RamdomPrefab => _prefabs[Random.Range(0, _prefabs.Count)];

    public Collectable CreateRandomItem()
    {
        return Instantiate<Collectable>(RamdomPrefab);
    }
}