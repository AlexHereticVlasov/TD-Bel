using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;

    public void Init(Path path)
    {
        _movement.Init(path);
    }
}
