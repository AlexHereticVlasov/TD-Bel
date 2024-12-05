using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private float _health = 5;

    public event UnityAction<Enemy> Died;

    public void Init(Path path)
    {
        _movement.Init(path);
    }

    internal void TakeDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            //ToDo: Spawn particles, etc
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
