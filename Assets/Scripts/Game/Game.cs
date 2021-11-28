using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CoinsSpawner _coinsSpawner;
    [SerializeField] private Transform _startPosition;

    private bool IsCompleted => _player.Coins == _coinsSpawner.CoinsSpawned;

    private void Awake()
    {
        _coinsSpawner.SpawnAll();
        ResetPlayer();
    }

    private void OnEnable()
    {
        _player.Died += ResetPlayer;
        _player.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _player.Died -= ResetPlayer;
        _player.CoinCollected -= OnCoinCollected;
    }

    private void ResetPlayer()
    {
        _player.transform.position = _startPosition.position;
        _player.RestoreHealth();
    }

    private void OnCoinCollected()
    {
        if (IsCompleted)
        {
            Debug.Log("All coins collected!");
        }
    }
}