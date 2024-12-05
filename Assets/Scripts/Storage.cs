using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Storage : MonoBehaviour
{
    [SerializeField] private int _curencyAmount;
    [SerializeField] private Spawner _spawner;

    public event UnityAction<int> AmountChanged;

    private void OnEnable() => _spawner.Spawned += OnSpawned;

    private void OnDisable() => _spawner.Spawned -= OnSpawned;

    private void OnSpawned(Enemy enemy) => enemy.Died += OnDied;

    private void OnDied(Enemy enemy)
    {
        Add(50);
        enemy.Died -= OnDied;
    }

    public void Add(int amount)
    {
        _curencyAmount += amount;
        AmountChanged?.Invoke(_curencyAmount);
        Debug.Log(_curencyAmount);
    }

    public bool TryRemove(int amount)
    {
        if (_curencyAmount < amount) return false;

        _curencyAmount -= amount;
        AmountChanged?.Invoke(_curencyAmount);
        return true;
    }
}
