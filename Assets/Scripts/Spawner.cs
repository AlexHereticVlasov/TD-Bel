using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Path _path;
    [SerializeField] private float _rate = 1;

    public event UnityAction<Enemy> Spawned;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnSingleEnemy), 0, _rate);
    }

    private void SpawnSingleEnemy()
    {
        Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.Init(_path);
        Spawned?.Invoke(enemy);
    }
}
