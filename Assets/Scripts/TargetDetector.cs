using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{

    [SerializeField] private float _radius = 5;
    [SerializeField] private float _rate = 0.2f;

    public Enemy Target { get; private set; }

    private void Start() => InvokeRepeating(nameof(SeekTarget), 0, _rate);


    private void SeekTarget()
    {
        List<Enemy> enemies = GetEnemies();
        Target = FindTarget(enemies);
        //Debug.Log(Target?.transform.name);

    }

    private Enemy FindTarget(List<Enemy> enemies)
    {
        float maxDistance = float.MaxValue;
        Enemy closest = null;

        foreach (var enemy in enemies)
        {
            float distnce = Vector3.Distance(transform.position, enemy.transform.position);
            if (maxDistance > distnce)
            {
                maxDistance = distnce;
                closest = enemy;
            }
        }

        return closest;
    }

    private List<Enemy> GetEnemies()
    {
        var enemies = new List<Enemy>();
        var candidates = Physics.OverlapSphere(transform.position, _radius);

        foreach (var candidate in candidates)
        {
            if (candidate.TryGetComponent(out Enemy enemy))
            {
                enemies.Add(enemy);
            }
        }

        return enemies;
    }
}
